using System;
using System.Linq;
using System.Web.Mvc;
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

        public ContentResult GetUsersBlogs(MetaBlogUserInfoRequest metaBlogUserInfoRequest)
        {
            var blogs =
                _blogRepository.GetAll().Where(x => x.User.Username == metaBlogUserInfoRequest.Username).ToList();            
            

            var xml = XmlRpcSerializer.ToXmlArrayResponse(MetaBlogFormat.ConvertBlogs(blogs));

            return new ContentResult() {Content = xml.ToString(), ContentType = "application/xml"};
        }
    }
}