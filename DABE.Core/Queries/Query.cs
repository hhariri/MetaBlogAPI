using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DABE.Core.Queries
{
    public abstract class Query
    {
        public abstract ICriteria ExecuteQuery(ISession session);
    }
}