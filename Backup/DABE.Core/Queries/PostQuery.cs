using System;
using DABE.Core.Entities;
using NHibernate;
using NHibernate.Context;

namespace DABE.Core.Queries
{
    public class PostQuery
    {
        public ICriteria Execute()
        {
            return SessionManager.Current.CreateCriteria<Post>();
        }
    }
}