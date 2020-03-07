using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JFlepp.Functional.Maybe;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void Match_WithSome_ExecutesSomeWithValue()
        {
            var input = "test";
            var testee = Some(input);

            testee.Match(
                result => Assert.AreSame(input, result),
                () => Assert.Fail());
        }

        [TestMethod]
        public void Match_WithNone_ExecutesNone()
        {
            var testee = None<string>();

            var noneExecuted = false;
            testee.Match(
                result => Assert.Fail(),
                () => noneExecuted = true);

            Assert.IsTrue(noneExecuted);
        }

        [TestMethod]
        public void Match_WithSomeAndReturnValue_ExecutesAndReturnsSome()
        {
            var input = "in";
            var output = "out";
            var other = "other";
            var testee = Some(input);

            var result = testee.Match(
                value => value == input ? output : other,
                () => other);

            Assert.AreSame(output, result);
        }

        [TestMethod]
        public void Match_WithNoneAndReturnValue_ExecutesAndReturnsNone()
        {
            var output = "out";
            var other = "other";
            var testee = None<string>();

            var result = testee.Match(
                value => other,
                () => output);

            Assert.AreSame(output, result);
        }
    }
}
