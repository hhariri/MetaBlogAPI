using System;
using NHibernate;
using NHibernate.Cfg;

namespace DABE.Core.Infrastructure
{
    public class SessionManager: IDisposable
    {
        static ISessionFactory _sessionFactory;
        static ISessionStorage _sessionStorage;

        public SessionManager(Configuration configuration, ISessionStorage sessionStorage)
        {
            _sessionFactory = configuration.BuildSessionFactory();
            _sessionStorage = sessionStorage;
#if DEBUG
            //            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
#endif
        }

        public static ISession Current
        {
            get
            {
                ISession session = _sessionStorage.Session;
                
                if (session == null)
                {
                    session = _sessionFactory.OpenSession();
                    _sessionStorage.Session = session;
                }
                return session;
            }
        }

        public void Dispose()
        {
            Current.Close();
        }


    }
}