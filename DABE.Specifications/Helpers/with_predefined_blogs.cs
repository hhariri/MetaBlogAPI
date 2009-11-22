using System;
using DABE.Core.Entities;
using DABE.Tests.Helpers;

namespace DABE.Specifications.Helpers
{
    public class with_large_amounts_of_predefined_data: InMemoryDatabase
    {
        public override void SetupData()
        {
            var user = new User() {Username = "user"};
            
            Session.Save(user);

            for (int i = 0; i < 10; i++)
            {
                var blog = new Blog() {Name = String.Format("Blog{0}", i), User = user};

                Session.Save(blog);

                for (int j = 0; j < 1000; j++)
                {
                    var post = new Post() { Date = DateTime.Now, Title = String.Format("Blog{0}Post{1}", i, j) };

                    post.Blog = blog;
                    Session.Save(post);
                }
            }
        }
    }

    public class with_predefined_blogs: InMemoryDatabase
    {
        protected static long blog1_id;
        protected static string blog1_name = "blog1_name";
        protected static string blog2_name = "blog2_name";
        protected static string blog3_name = "blog3_name";
        protected static string blog1_username = "test_user";

        public override void SetupData()
        {
            blog1_name = "First Post";

            var user = new User() {Username = blog1_username};

            var blog1 = new Blog { Name = blog1_name, User = user };
            var blog2 = new Blog { Name = blog2_name };
            var blog3 = new Blog { Name = blog3_name, User = user};

            Session.Save(user);
            Session.Save(blog1);
            Session.Save(blog2);
            Session.Save(blog3);

            
            blog1_id = blog1.Id;

        }
    }
}