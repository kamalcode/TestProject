using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject;
using TestProject.Controllers;
using TestProject.DataAccessLayer;
using TestProject.Interfaces;

namespace TestProject.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {
        private IUnitOfWork _unitOfWork = null;
        [TestInitialize]
        public void Initialise()
        {
            _unitOfWork = new UnitOfWork();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            CarController controller = new CarController(_unitOfWork);

            // Act
            ViewResult result = controller.Index("","") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            CarController controller = new CarController(_unitOfWork);

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            CarController controller = new CarController(_unitOfWork);

            // Act
            ViewResult result = controller.Edit(0) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
