using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class OrElseTests
    {
        [TestMethod]
        public void OrElse_WithSome_ReturnsInput()
        {
            var input = Maybe.Some("some");

            var result = input.OrElse("test");

            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void OrElse_WithNone_ReturnsElse()
        {
            var elseValue = "test";
            var input = Maybe.None<string>();

            var result = input.OrElse(elseValue);

            Assert.IsTrue(result.IsSome);
            Assert.AreEqual(Maybe.Some(elseValue), result);
        }
        
        [TestMethod]
        public void OrElse_WithSomeAndThunk_ReturnsInputNotEvaluatesThunk()
        {
            var thunkEvaluated = false;
            var input = Maybe.Some("some");

            var result = input.OrElse(() => { thunkEvaluated = true; return ""; });

            Assert.IsFalse(thunkEvaluated);
            Assert.AreEqual(input, result);
        }

        [TestMethod]
        public void OrElse_WithNoneAndThunk_EvaluatesAndReturnsThunk()
        {
            var elseValue = "test";
            var input = Maybe.None<string>();

            var result = input.OrElse(() => elseValue);

            Assert.AreEqual(Maybe.Some(elseValue), result);
        }
    }
}
