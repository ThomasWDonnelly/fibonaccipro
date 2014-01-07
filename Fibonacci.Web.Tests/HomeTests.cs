using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonacci.Web.Controllers;
using MvcContrib.TestHelper;

namespace Fibonacci.Web.Tests
{
    [TestClass]
    public class HomeTests
    {

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void Index_returns_index_view()
        {
            //Arrange
            var controller = new HomeController(null);

            //Act
            var result = controller.Index();

            //Assert
            result.AssertViewRendered();
        }
    }
}
