using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void Any_WithNonePredicateMatches_ReturnsFalse()
        {
            var input = Maybe.None<string>();

            var result = input.Any(s => true);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Any_WithSomePredicateMatches_ReturnsTrue()
        {
            var input = Maybe.Some("test");

            var result = input.Any(s => true);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Any_WithSomePredicateNotMatches_ReturnsFalse()
        {
            var input = Maybe.Some("test");

            var result = input.Any(s => false);

            Assert.IsFalse(result);
        }
    }
}
