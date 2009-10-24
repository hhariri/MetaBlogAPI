using System;
using System.Web;
using NHibernate;

namespace DABE.Core.Infrastructure
{
    public class HttpSessionStorage : ISessionStorage
    {
        const string CurrentSessionKey = "nhibernate.current_session";

        public HttpSessionStorage(HttpApplication app)
        {
            if (app != null)
            {
                app.EndRequest += Application_EndRequest;
            }
        }

        public ISession Session
        {
            get
            {
                HttpContext context = HttpContext.Current;
                ISession session = context.Items[CurrentSessionKey] as ISession;
                return session;
            }
            set
            {
                HttpContext context = HttpContext.Current;
                context.Items[CurrentSessionKey] = value;
            }
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            ISession session = Session;

            if (session != null)
            {
                session.Close();
                HttpContext context = HttpContext.Current;
                context.Items.Remove(CurrentSessionKey);
            }
        }
    }
}