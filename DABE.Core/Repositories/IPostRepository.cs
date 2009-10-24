using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DABE.Core.Entities;
using DABE.Core.Queries;
using NHibernate;

namespace DABE.Core.Repositories
{
    public interface IPostRepository
    {
        ICriteria GetPosts();
        ICriteria GetPosts(Query query);
        Post GetPostById(long id);
    }
}