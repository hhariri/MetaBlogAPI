using System;
using DABE.Core.Entities;
using DABE.Tests.Helpers;
using NHibernate;

namespace DABE.Specifications.Helpers
{
    public class with_predefined_posts: InMemoryDatabase
    {
        static protected long post1_id;
        static protected string post1_title;

        public override void SetupData()
        {
            post1_title = "First Post";

            var post1 = new Post { Title = post1_title };
            var post2 = new Post {Title = "A second post"};
            
            Session.Save(post1);
            Session.Save(post2);

            post1_id = post1.Id;

        }

    }
}