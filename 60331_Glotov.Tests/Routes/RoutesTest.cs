using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _60331_Glotov.Tests.Routes
{
    [TestClass]
    public class RoutesTest
    {
        [TestMethod]
        public void DefaultRouteTest()
        {
            //Arrange
            //Макет Http - контекста
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(x => x.Request.AppRelativeCurrentExecutionFilePath).Returns("~/");
            //Создание коллекции маршрутов и регистрации маршрутов
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act
            //получение данных маршрута
            RouteData result = routes.GetRouteData(mockContext.Object);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }
    }
}
