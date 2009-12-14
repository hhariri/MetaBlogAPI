using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Xml.Linq;
using DABE.Core.Repositories;
using DABE.Web.MetaBlog;

namespace DABE.Web.Controllers
{
    public class MetaBlogController: Controller
    {
        readonly IBlogRepository _blogRepository;

        public MetaBlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public ActionResult ProcessRequest(MetaBlogRequest metaBlogRequest)
        {
            Type type = GetType();

            var xml = type.InvokeMember(metaBlogRequest.MethodCall, BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod, null, this,
                              new object[] {metaBlogRequest.Params});
            

            return new ContentResult() {Content = xml.ToString(), ContentType = "text/xml"};
        }

        public XDocument getUsersBlogs(IList<XElement> request)
        {
            var metaBlogUserInfoRequest = new MetaBlogUserInfoRequest(request);

            var blogs =
                _blogRepository.GetAll().Where(x => x.User.Username == metaBlogUserInfoRequest.Username).ToList();


            return XmlRpcSerializer.ToXmlArrayResponse(MetaBlogFormat.ConvertBlogs(blogs));
        }

        public XDocument getCategories(IList<XElement> request)
        {
            var metaBlogGetCategoriesRequest = new MetaBlogGetCategoriesRequest(request);

            var blog = _blogRepository.GetAll().Where(x => x.Id.ToString() == metaBlogGetCategoriesRequest.BlogId).FirstOrDefault();

            return XmlRpcSerializer.ToXmlArrayResponse(MetaBlogFormat.ConvertCategories(blog.Categories.ToList()));

        }

    }
}