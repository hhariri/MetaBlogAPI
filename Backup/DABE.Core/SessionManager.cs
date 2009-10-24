using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Driver;
using Environment=NHibernate.Cfg.Environment;

namespace DABE.Core
{
    public class SessionManager: IDisposable
    {
        private static ISessionFactory _sessionFactory;

        public SessionManager(Configuration configuration)
        {
            _sessionFactory = configuration.BuildSessionFactory();
#if DEBUG
            //            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
#endif
        }

        public static ISession Current
        {
            get
            {
                ISession session = _sessionFactory.GetCurrentSession();
                
                if (session == null)
                {
                    session = _sessionFactory.OpenSession();
                    CurrentSessionContext.Bind(session);
                }
                return session;
            }
        }

        public void Dispose()
        {
            var session = CurrentSessionContext.Unbind(_sessionFactory);
            session.Close();
        }
    }

}