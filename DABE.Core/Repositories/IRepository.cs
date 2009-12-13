using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DABE.Core.Repositories
{
    public interface IRepository<T, TKey> where T: class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> query);
        T GetById(TKey id);
        void Save(T obj);
    }
}
