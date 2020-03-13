using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class AggregateTests
    {
        [TestMethod]
        public void Aggregate_WithSome_AppliesFunc()
        {
            var input = Maybe.Some(1);

            var result = input.Aggregate("The value is: ", (state, value) => state + value);

            Assert.AreEqual("The value is: 1", result);
        }

        [TestMethod]
        public void Aggregate_WithNone_ReturnsSeed()
        {
            var state = "untouched";
            var input = Maybe.None<int>();

            var result = input.Aggregate(state, (state, value) => state + value);

            Assert.AreEqual(state, result);
        }
    }
}
