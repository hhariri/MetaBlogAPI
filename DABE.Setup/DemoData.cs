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