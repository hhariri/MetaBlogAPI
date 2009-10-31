using System;
using System.Web.Mvc;
using DABE.Core.Entities;
using DABE.Core.Queries;
using DABE.Core.Repositories;


namespace DABE.Web.Controllers
{
    public class PostController: BaseController
    {
        readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public ActionResult Index()
        {

            var posts = _postRepository.GetPosts()
                .List<Post>();

            return View(posts);
        }

        public ActionResult Get(string title)
        {
            var postQuery = new PostQuery {Title = title};

            var post = _postRepository.GetPosts(postQuery)
                .UniqueResult<Post>();

            return View(post);
        }

    }
}