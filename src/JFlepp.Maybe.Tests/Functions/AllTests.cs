using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class AllTests
    {
        
        [TestMethod]
        public void All_WithNonePredicateNotMatches_ReturnsTrue()
        {
            var input = Maybe.None<string>();

            var result = input.All(s => false);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void All_WithSomePredicateMatches_ReturnsTrue()
        {
            var input = Maybe.Some("test");

            var result = input.All(s => true);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void All_WithSomePredicateNotMatches_ReturnsFalse()
        {
            var input = Maybe.Some("test");

            var result = input.All(s => false);

            Assert.IsFalse(result);
        }
    }
}
