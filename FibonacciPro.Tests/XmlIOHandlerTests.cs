using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FibonacciPro.ConsoleApplication.IO;
using System.IO;

namespace FibonacciPro.Tests
{
    [TestClass]
    public class XmlIOHandlerTests
    {
        [TestMethod]
        public void handler_can_accept_xml_input()
        {

            //Arrange
            var handler = new XmlIOHandler("input.xml");
            var expectedResult = 22;

            //Act
            var result = handler.GetNumber();

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void handler_throws_argument_exception_when_given_invalid_path()
        {

            //Arrange
            var handler = new XmlIOHandler("does-not-exist.xml");

            //Act
            try {
                var result = handler.GetNumber();
                Assert.Fail("did not throw ArgumentException with path paramater");
            }

            //Assert
            catch (ArgumentException ex) {
                Assert.AreEqual("path", ex.ParamName);
            }
        }

        [TestMethod]
        public void handler_throws_application_exception_when_given_invalid_markup()
        {

            //Arrange
            var path = "invalid-markup-input.xml";
            var handler = new XmlIOHandler(path);
            if (!File.Exists(path))
            {
                Assert.Inconclusive("invalid-markup-input.xml file was not present to test with");
            }
            //Act
            try
            {
                var result = handler.GetNumber();
                Assert.Fail("did not throw ArgumentException with path paramater");
            }

            //Assert
            catch (ApplicationException ex)
            {
                Assert.IsTrue(true); //Pass!
            }
        }

        [TestMethod]
        public void handler_throws_application_exception_when_given_invalid_schema()
        {

            //Arrange
            var path = "invalid-schema-elements-input.xml";
            var handler = new XmlIOHandler(path);
            if (!File.Exists(path))
            {
                Assert.Inconclusive("invalid-schema-elements-input.xml file was not present to test with");
            }
            //Act
            try
            {
                var result = handler.GetNumber();
                Assert.Fail("did not throw ArgumentException with path paramater");
            }

            //Assert
            catch (ArgumentException ex)
            {
                Assert.AreEqual("path", ex.ParamName);
            }
        }
    }
}
