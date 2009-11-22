using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DABE.Core.Repositories
{
    public interface IRepository<T, TKey> where T: class
    {
        IList<T> GetAll();
        IList<T> GetAll(Expression<Func<T, bool>> query);
        T GetById(TKey id);
        void Save(T obj);
    }
}
