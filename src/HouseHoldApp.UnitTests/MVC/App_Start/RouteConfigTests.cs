using System.Web;
using System.Web.Routing;
using HouseHoldApp.MVC;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.App_Start
{
    [TestFixture]
    public class RouteConfigTests
    {
        [TestCase]
        public void RouteHasDefaultActionWhenUrlWithoutAction()
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/Account/Register");

            RouteData routeData = routes.GetRouteData(httpContextMock.Object);
            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Account", routeData.Values["Controller"]
                , "Expected a different controller");
            Assert.AreEqual("Register", routeData.Values["action"]
                , "Expected a different action");
        }
    }
}
