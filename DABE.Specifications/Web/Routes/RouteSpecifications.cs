using System.Web;
using System.Web.Routing;
using DABE.Web;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace DABE.Specifications.Web.Routes
{

    public class when_requesting_MetaBlog_url_without_action
    {
        Establish context = () =>
        {
            httpContext = new Mock<HttpContextBase>();
            routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);


            httpContext.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns("~/MetaBlog");
        };


        Because of = () =>
        {
            routeData = routes.GetRouteData(httpContext.Object);           
        };


        It should_redirect_to_ProcessRequest_action = () =>
        {
            routeData.Values["controller"].ShouldEqual("MetaBlog");
            routeData.Values["action"].ShouldEqual("ProcessRequest");
        };

        static RouteCollection routes;
        static RouteData routeData;
        static Mock<HttpContextBase> httpContext;
    }
}