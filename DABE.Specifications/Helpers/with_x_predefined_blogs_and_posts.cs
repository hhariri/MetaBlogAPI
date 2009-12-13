using System;
using DABE.Core.Entities;
using DABE.Tests.Helpers;

namespace DABE.Specifications.Helpers
{
    public class with_x_predefined_blogs_and_posts: InMemoryDatabase
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
}