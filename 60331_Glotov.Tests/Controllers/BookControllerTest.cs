using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _60331_Glotov.Controllers;
using _60331_Glotov.Models;
using _60331_Glotov.DAL;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;

namespace _60331_Glotov.Tests.Controllers
{
    [TestClass()]
    public class BookControllerTest
    {
        [TestMethod()]
        public void PagingTest()
        {
            //Arrange
            //Макет репозитория
            Mock<IRepository<Book>> mock = new Mock<IRepository<Book>>();
            mock.Setup(x => x.GetAll()).Returns(new List<Book> {
                                                                    new Book { BookId = 1 },
                                                                    new Book { BookId = 2 },
                                                                    new Book { BookId = 3 },
                                                                    new Book { BookId = 4 },
                                                                    new Book { BookId = 5 }
                                                                });
            //создание объекта контроллера
            BookController controller = new BookController(mock.Object);
            //Макет для получения HttpContext HttpRequest
            Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Request).Returns(request.Object);
            //Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;
            ////Для имитации запросов ajax
            //NameValueCollection valueCollection = new NameValueCollection();
            //valueCollection.Add("X-Request-With", "XMLHttpRequest");
            //valueCollection.Add("Accept", "apllication/json");
            //request.Setup(x => x.Headers).Returns(valueCollection);

            //Act
            //Вызов метода List
            ViewResult view = controller.List(null, 2) as ViewResult;

            //Assert
            Assert.IsNotNull(view, "Представление получено");
            Assert.IsNotNull(view.Model, "Модель получена");
            PageListViewModel<Book> model = view.Model as PageListViewModel<Book>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].BookId);
            Assert.AreEqual(5, model[1].BookId);
        }

        [TestMethod()]
        public void CategoryTest()
        {
            //Arrange
            //Макет репозитория
            Mock<IRepository<Book>> mock = new Mock<IRepository<Book>>();
            mock.Setup(x => x.GetAll()).Returns(new List<Book> {
                                                                    new Book { BookId = 1, CategoryName = "1" },
                                                                    new Book { BookId = 2, CategoryName = "2" },
                                                                    new Book { BookId = 3, CategoryName = "1" },
                                                                    new Book { BookId = 4, CategoryName = "2"  },
                                                                    new Book { BookId = 5, CategoryName = "2" }
                                                                });
            //создание объекта контроллера
            BookController controller = new BookController(mock.Object);
            //Макет для получения HttpContext HttpRequest
            Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Request).Returns(request.Object);
            //Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            //Act
            //Вызов метода List
            ViewResult view = controller.List("1", 1) as ViewResult;

            //Assert
            Assert.IsNotNull(view, "Представление получено");
            Assert.IsNotNull(view.Model, "Модель получена");
            PageListViewModel<Book> model = view.Model as PageListViewModel<Book>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].BookId);
            Assert.AreEqual(3, model[1].BookId);
        }
    }
}
