using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DABE.Core;
using DABE.Web.Controllers;
using Machine.Specifications;


namespace DABE.Tests.Web
{
    public class when_displaying_home_page
    {
        Establish context = () =>
        {
            postController = new PostController();
        };

        Because of = () =>
        {
            viewResult = postController.Index() as ViewResult;
        };

        It should_display_top_x_entries =() =>
        {
            viewResult.ViewName.ShouldEqual(String.Empty);
            viewResult.ViewData.Model.ShouldBeOfType(typeof(IList<Post>));
        };

        static ViewResult viewResult;
        static PostController postController;
    }

    public class when_clicking_on_a_post_title
    {
        It should_display_the_blog_entry;
    }
}