using Microsoft.VisualStudio.TestTools.UnitTesting;
using OPWAPP2.Controllers;
using System.Web.Mvc;

namespace OPWAPP2TestProject
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FAQ()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.FAQ() as ViewResult;
            //Assert
            Assert.AreEqual("FAQ page for users",result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            //Arrange
            HomeController controller = new HomeController();
            //Act
            ViewResult result = controller.Contact() as ViewResult;
            //Assert
            Assert.AreEqual("OPWAPP contact page.", result.ViewBag.Message);
        }
    }
}
