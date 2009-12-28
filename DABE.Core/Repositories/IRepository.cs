using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DABE.Core.Repositories
{
    public interface IRepository<T, TKey>: IReadOnlyRepository<T, TKey> where T: class
    {
        void Save(T obj);
    }
}
