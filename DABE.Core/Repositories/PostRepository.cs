using System;
using DABE.Core.Entities;
using DABE.Core.Infrastructure;
using DABE.Core.Queries;
using NHibernate;

namespace DABE.Core.Repositories
{
    public class PostRepository: IPostRepository
    {
        public ICriteria GetPosts()
        {
            return SessionManager.Current.CreateCriteria<Post>();
        }

        public ICriteria GetPosts(Query query)
        {
            return query.ExecuteQuery(SessionManager.Current);
        }

        public Post GetPostById(long id)
        {
            return SessionManager.Current.Get<Post>(id);
        }
    }
}