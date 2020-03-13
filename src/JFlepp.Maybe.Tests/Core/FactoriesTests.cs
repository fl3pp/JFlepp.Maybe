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

        [TestMethod]
        public void FromObject_WithValue_ReturnsSome()
        {
            var input = 1;

            var result = FromObject(input);

            Assert.IsTrue(result.IsSome);
        }

        [TestMethod]
        public void FromObject_WithNullReference_ReturnsNone()
        {
            var input = (string)null;

            var result = FromObject(input);

            Assert.IsFalse(result.IsSome);
        }
    }
}
