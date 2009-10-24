using NHibernate;

namespace DABE.Core.Infrastructure
{
    public interface ISessionStorage
    {
        ISession Session { get; set; }
    }
}