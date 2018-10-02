using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject;
using TestProject.Controllers;

namespace TestProject.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CarController controller = new CarController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            CarController controller = new CarController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            CarController controller = new CarController();

            // Act
            ViewResult result = controller.Edit(0) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
