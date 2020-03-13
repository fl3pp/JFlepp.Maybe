using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class ToObjectTests
    {
        [TestMethod]
        public void ToObject_WithValueNone_ReturnsNull()
        {
            var input = Maybe.None<int>();

            var result = input.ToObject();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ToObject_WithReferenceValue_ReturnsValue()
        {
            var value = "test";
            var input = Maybe.Some(value);

            var result = input.ToObject();

            Assert.AreEqual(value, result);
        }
    }
}
