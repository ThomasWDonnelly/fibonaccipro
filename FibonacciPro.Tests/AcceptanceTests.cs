using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace FibonacciPro.Tests
{
    [TestClass]
    public class AcceptanceTests
    {

        [TestMethod]
        public void n_equals_1_returns_first_number()
        {
            //Arrange
            var expectedOutput = "0";

            //Act
            var results = FibPro("1");

            //Assert
            Assert.AreEqual(expectedOutput, results);
        }

        [TestMethod]
        public void n_equals_2_returns_first_two_numbers()
        {
            //Arrange
            var expectedOutput = "0 1";
            
            //Act
            var results = FibPro("2");

            //Assert
            Assert.AreEqual(results, expectedOutput);
        }

        [TestMethod]
        public void n_equals_3_returns_first_three_numbers()
        {
            //Arrange
            var expectedOutput = "0 1 1";

            //Act
            var results = FibPro("3");

            //Assert
            Assert.AreEqual(results, expectedOutput);
        }

        [TestMethod]
        public void n_equals_4_returns_first_four_numbers()
        {
            //Arrange
            var expectedOutput = "0 1 1 2";

            //Act
            var results = FibPro("4");

            //Assert
            Assert.AreEqual(results, expectedOutput);
        }

        /// <summary>
        /// Invokes FibPro and returns a string of the standard output
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string FibPro(string args)
        {
            var process = Process.Start(new ProcessStartInfo()
            {
                Arguments = args,
                CreateNoWindow = true,
                FileName = "fibpro.exe",
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            });

            process.WaitForExit();

            return process.StandardOutput.ReadToEnd();
        }
    }
}
