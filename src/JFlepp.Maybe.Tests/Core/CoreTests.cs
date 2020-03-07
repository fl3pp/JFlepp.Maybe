using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Construct_WithDefaultConstructor_ReturnsNone()
        {
            var testee = new Maybe<string>();

            var result = testee.IsNone;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Construct_WithValue_ReturnsSome()
        {
            var testee = new Maybe<string>("test");

            var result = testee.IsSome;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Construct_WithNullValue_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = new Maybe<string>(null);
            });
        }

        [TestMethod]
        public void Construct_WithSome_IsNoneReturnsFalseIsSomeReturnsTrue()
        {
            var testee = new Maybe<string>("Test");

            var isSomeResult = testee.IsSome;
            var isNoneResult = testee.IsNone;

            Assert.IsTrue(isSomeResult);
            Assert.IsFalse(isNoneResult);
        }

        [TestMethod]
        public void Construct_WithNone_IsNoneReturnsTrueIsSomeReturnsFalse()
        {
            var testee = new Maybe<string>();

            var isSomeResult = testee.IsSome;
            var isNoneResult = testee.IsNone;

            Assert.IsFalse(isSomeResult);
            Assert.IsTrue(isNoneResult);
        }
    }
}
