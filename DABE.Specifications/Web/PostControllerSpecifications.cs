using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DABE.Core.Controllers;
using DABE.Core.Entities;
using DABE.Core.Repositories;
using DABE.Specifications.Helpers;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;
using DABE.Web.Controllers;

namespace DABE.Tests.Web
{
    public class when_displaying_home_page: with_predefined_posts
    {
        Establish context = () =>
        {
            var postRepository = new PostRepository();
    
            postController = new PostController(postRepository);
        };

        Because of = () =>
        {
            viewResult = postController.Index() as ViewResult;
        };

        It should_display_posts = () =>
        {
            viewResult.ViewName.ShouldEqual(String.Empty);
            viewResult.ViewData.Model.ShouldBeOfType(typeof(List<Post>));
        };

        static ViewResult viewResult;
        static PostController postController;
    
    }


    public class when_clicking_on_a_post_title: with_predefined_posts
    {
        Establish context = () =>
        {
            postController = new PostController(new PostRepository());
        };

        Because of = () =>
        {
            viewResult = postController.Get(post1_title) as ViewResult;
        };

        It should_display_the_blog_entry = () =>
        {
            viewResult.ViewName.ShouldEqual(String.Empty);
            viewResult.ViewData.Model.ShouldBeOfType(typeof (Post));
        };

        static ViewResult viewResult;
        static PostController postController;
    }
}