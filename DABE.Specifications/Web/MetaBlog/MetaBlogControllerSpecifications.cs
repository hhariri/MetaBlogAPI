using System.Web.Mvc;
using DABE.Core.Repositories;
using DABE.Specifications.Helpers;
using DABE.Web.Controllers;
using DABE.Web.MetaBlog;
using Machine.Specifications;

namespace DABE.Specifications.Web.MetaBlog
{
    //public class when_requesting_users_blogs_of_valid_user: with_predefined_blogs
    //{
    //    Establish context = () =>
    //    {
    //        metaBlogUserInfoRequest = new MetaBlogUserInfoRequest()
    //                                      {
    //                                          AppKey = "C6CE3FFB3174106584CBB250C0B0519BF4E294",
    //                                          Username = blog1_username,
    //                                          Password = "pass"
    //                                      };

    //        metaBlogController = new MetaBlogController(new BlogRepository());

    //    };

    //    Because of = () =>
    //    {
    //        response = metaBlogController.GetUsersBlogs(metaBlogUserInfoRequest) as ContentResult;
    //    };

    //    It should_return_list_of_users_blogs = () =>
    //    {
    //        response.ShouldNotBeNull();
    //    };

    //    static MetaBlogController metaBlogController;
    //    static MetaBlogUserInfoRequest metaBlogUserInfoRequest;
    //    static ContentResult response;
    //}
}