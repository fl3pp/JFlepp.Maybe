using Microsoft.VisualStudio.TestTools.UnitTesting;
using static JFlepp.Functional.Maybe;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class FactoriesTests
    {
        [TestMethod]
        public void None_WithoutValue_ReturnsNoneValue()
        {
            var result = None<string>();

            Assert.IsTrue(result.IsNone);
        }

        [TestMethod]
        public void Some_WithValue_ConstructsSome()
        {
            var value = "test";
            var result = Some(value);

            Assert.IsTrue(result.IsSome);
        }
    }
}
