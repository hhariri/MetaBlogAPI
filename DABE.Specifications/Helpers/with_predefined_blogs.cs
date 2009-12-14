using DABE.Core.Entities;
using DABE.Tests.Helpers;

namespace DABE.Specifications.Helpers
{
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

            var category1 = new Category()
                           {Blog = blog1, Description = "Description1", HtmlUrl = "htmlurl1", RssUrl = "rssurl1"};
            var category2 = new Category()
                           {Blog = blog1, Description = "Description2", HtmlUrl = "htmlurl2", RssUrl = "rssurl2"};
            var category3 = new Category()
                           {Blog = blog1, Description = "Description3", HtmlUrl = "htmlurl3", RssUrl = "rssurl3"};


            blog1.AddCategory(category1);
            blog1.AddCategory(category2);
            blog1.AddCategory(category3);

            Session.Save(user);
            Session.Save(blog1);
            Session.Save(blog2);
            Session.Save(blog3);

            
            blog1_id = blog1.Id;

        }
    }
}