using System;
using DABE.Core.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace DABE.Core.Queries
{
    public class PostQuery : Query
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string Title { get; set; }

        public override ICriteria ExecuteQuery(ISession session)
        {
            var criteria = session.CreateCriteria<Post>();

            if (!String.IsNullOrEmpty(Title))
            {
                criteria.Add(Restrictions.Eq("Title", Title));
            }
            if (FromDate != null)
            {
                criteria.Add(Restrictions.Ge("Date", FromDate));
            }
            if (ToDate != null)
            {
                criteria.Add(Restrictions.Le("Date", ToDate));
            }
            return criteria;
        }
    }
}