using System.Collections.Generic;
using DABE.Core.Entities;

namespace DABE.Web.MetaBlog
{

    public class MetaBlogFormat
    {
        public static IList<Dictionary<string, object>> ConvertBlogs(IList<Blog> blogs)
        {
            var output = new List<Dictionary<string, object>>();
            

            foreach(var blog in blogs)
            {
                var entry = new Dictionary<string, object>();

                entry.Add("url", blog.Url);
                entry.Add("blogid", blog.Id);
                entry.Add("blogName", blog.Name);
                
                output.Add(entry);
            }

            return output;
        }
    }
}