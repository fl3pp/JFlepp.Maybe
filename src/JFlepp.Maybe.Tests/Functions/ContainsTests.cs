using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class ContainsTests
    {
        [TestMethod]
        public void Contains_WithNone_ReturnsFalse()
        {
            var input = Maybe.None<int>();

            var result = input.Contains(1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_WithSomeAndOtherValue_ReturnsFalse()
        {
            var input = Maybe.Some(0);

            var result = input.Contains(1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_WithSomeAndSameValue_ReturnsTrue()
        {
            var input = Maybe.Some(0);

            var result = input.Contains(0);

            Assert.IsTrue(result);
        }
    }
}
