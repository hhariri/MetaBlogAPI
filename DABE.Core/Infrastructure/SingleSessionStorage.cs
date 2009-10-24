using NHibernate;

namespace DABE.Core.Infrastructure
{
    public class SingleSessionStorage : ISessionStorage
    {
        private ISession _session;

        public ISession Session
        {
            get { return _session; }
            set { _session = value; }
        }

    }
}