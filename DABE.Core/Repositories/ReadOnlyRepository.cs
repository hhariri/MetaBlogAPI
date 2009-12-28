using System;
using System.Linq;
using System.Linq.Expressions;
using DABE.Core.Infrastructure;
using NHibernate.Linq;

namespace DABE.Core.Repositories
{
    public class ReadOnlyRepository<T, TKey>: IReadOnlyRepository<T, TKey> where T: class
    {
        // TODO: Change this to use Stateless Session
        public IQueryable<T> GetAll()
        {
            return    from item in SessionManager.Current.Linq<T>()
                      select item;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> query)
        {
            var qry = from item in SessionManager.Current.Linq<T>()
                      select item;

            qry = qry.Where<T>(query);

            return qry;
        }

        public T GetById(TKey id)
        {
            return SessionManager.StatelessCurrent.Get<T>(id);
        }
    }
}