using JFlepp.Functional.Unsafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class UnsafeTests
    {
        [TestMethod]
        public void GetValue_WithValue_ReturnsValue()
        {
            var value = "some";
            var some = Maybe.Some(value);

            var result = some.GetValue();

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void GetValue_WithoutValue_ThrowsException()
        {
            var testee = Maybe.None<string>();

            Assert.ThrowsException<NullReferenceException>(() =>
            {
                testee.GetValue();
            });
        }
    }
}
