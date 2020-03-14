using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFlepp.Functional;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class ValidationExtensionsTests
    {
        [TestMethod]
        public void ThrowIfNull_WithString_ReturnsInput()
        {
            var input = "test";

            var result = input.ThrowIfNull("test");

            Assert.AreSame(input, result);
        }

        [TestMethod]
        public void ThrowIfNull_WithNull_ThrowsException()
        {
            var input = (string)null;

            var result = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = input.ThrowIfNull("test");
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'test')", result.Message);
        }
    }
}
