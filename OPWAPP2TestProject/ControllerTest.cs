using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using OPWAPP2;
using OPWAPP2.Controllers;

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
