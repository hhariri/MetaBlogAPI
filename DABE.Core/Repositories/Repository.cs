using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DABE.Core.Infrastructure;
using NHibernate.Linq;

namespace DABE.Core.Repositories
{
    public class Repository<T, TKey>: IRepository<T, TKey> where T: class
    {
        public IList<T> GetAll()
        {
            return SessionManager.Current.CreateCriteria<T>().List<T>();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> query)
        {
            var qry = from item in SessionManager.Current.Linq<T>()
                    select item;

            qry = qry.Where<T>(query);

            return qry.ToList();

        }

        public T GetById(TKey id)
        {
            return SessionManager.Current.Get<T>(id);
        }

        public void Save(T obj)
        {
            throw new NotImplementedException();
        }
    }
}