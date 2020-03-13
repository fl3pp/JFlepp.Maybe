using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class WhereTests
    {
        [TestMethod]
        public void Where_WithNoneAndPredicateNotMatches_ReturnsNone()
        {
            var input = Maybe.None<string>();

            var result = input.Where(t => false);

            Assert.AreEqual(Maybe.None<string>(), result);
        }

        [TestMethod]
        public void Where_WithSomeAndPredicateMatches_ReturnsSome()
        {
            var input = Maybe.Some("3");

            var result = input.Where(t => t == "3");

            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void Where_WithSomeAndPredicateNotMatches_ReturnsNone()
        {
            var input = Maybe.Some("4");

            var result = input.Where(t => t == "3");

            Assert.AreEqual(Maybe.None<string>(), result);
        }
    }
}
