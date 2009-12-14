using System;
using DABE.Core.Entities;
using NHibernate;

namespace DABE.Setup
{
    static class DemoData
    {
        public static void SetupData(ISession session)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                var user = new User() { Username = "user" };

                session.Save(user);

                for (int i = 0; i < 10; i++)
                {
                    var blog = new Blog() { Name = String.Format("Blog{0}", i), User = user };

                    var category1 = new Category() { Blog = blog, Description = "Description1", HtmlUrl = "htmlurl1", RssUrl = "rssurl1" };
                    var category2 = new Category() { Blog = blog, Description = "Description2", HtmlUrl = "htmlurl2", RssUrl = "rssurl2" };
                    var category3 = new Category() { Blog = blog, Description = "Description3", HtmlUrl = "htmlurl3", RssUrl = "rssurl3" };


                    blog.AddCategory(category1);
                    blog.AddCategory(category2);
                    blog.AddCategory(category3);

                    session.Save(blog);

                    for (int j = 0; j < 1000; j++)
                    {
                        var post = new Post() { Date = DateTime.Now, Title = String.Format("Blog{0}Post{1}", i, j) };

                        post.Blog = blog;
                        session.Save(post);
                    }
                }   
                transaction.Commit();
                
            }
        }
    }
}