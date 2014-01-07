using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonacci.Web.Controllers;
using MvcContrib.TestHelper;
using FakeItEasy;
using Fibonacci.Lib.Calculators;

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

        [TestMethod]
        public void Index_invokes_fibonacci_application_when_passed_an_input()
        {
            //Arrange
            var calculator = A.Fake<IFibonacciCalculator>();
            var controller = new HomeController(calculator);

            //Act
            controller.Index(new Models.IndexViewModel() { InputValue = 5 });

            //Assert
            A.CallTo(() => calculator.Calculate(5)).MustHaveHappened();
        }
    }
}
