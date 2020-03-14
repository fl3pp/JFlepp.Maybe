using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class SingleOrTests
    {
        [TestMethod]
        public void SingleOr_WithSomeAndValue_ReturnsInput()
        {
            var input = Maybe.Some(1);

            var result = input.SingleOr(0);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SingleOr_WithNoneAndValue_ReturnsValue()
        {
            var value = 0;
            var input = Maybe.None<int>();

            var result = input.SingleOr(value);

            Assert.AreEqual(value, result);
        }
        
        [TestMethod]
        public void SingleOr_WithSomeAndThunk_ReturnsInputWithoutEvaluatingThunk()
        {
            var thunkEvaluated = false;
            var input = Maybe.Some(1);

            var result = input.SingleOr(() => { thunkEvaluated = true; return 0; });

            Assert.IsFalse(thunkEvaluated);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SingleOr_WithNoneAndThunk_EvaluatedAndReturnsThunk()
        {
            var input = Maybe.None<int>();

            var result = input.SingleOr(() => 0);

            Assert.AreEqual(0, result);
        }
    }
}
