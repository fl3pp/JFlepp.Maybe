using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JFlepp.Functional.Tests.EqualityTestFixture;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class EqualityTests
    {
        [TestMethod]
        public void EqualityOperations_WithSameSomeMaybes_ReturnEquality() =>
            ExpectSomeMaybe("test").ToEqual().WithOtherSomeMaybe("test")
            .OnObjectEquals()
            .OnEqualityOperator()
            .OnInversedInequalityOperator()
            .OnEquatableEquals()
            .OnGetHashCode();

        [TestMethod]
        public void EqualityOperations_WithDifferentSomeMaybes_ReturnsInequality() =>
            ExpectSomeMaybe("test").ToNotEqual().WithOtherSomeMaybe("other")
            .OnObjectEquals()
            .OnEqualityOperator()
            .OnInversedInequalityOperator()
            .OnEquatableEquals()
            .OnGetHashCode();

        [TestMethod]
        public void Equals_WithSomeAndOtherNone_ReturnsInequality() =>
            ExpectSomeMaybe("test").ToNotEqual().WithOtherNoneMaybe()
            .OnEquatableEquals();

        [TestMethod]
        public void EqualsGetHashCode_WithNull_ReturnsInequality() =>
            ExpectSomeMaybe("test").ToNotEqual().WithOtherSomeMaybe("other")
            .OnObjectEquals()
            .OnGetHashCode();

        [TestMethod]
        public void EqualsGetHashCode_WithBaseObject_ReturnsInequality() =>
            ExpectSomeMaybe("test").ToNotEqual().WithOtherObject("other")
            .OnObjectEquals()
            .OnGetHashCode();
    }


    internal static class EqualityTestFixture
    {
        public static TesteeBuilder<T> ExpectSomeMaybe<T>(T data) => new TesteeBuilder<T>(new Maybe<T>(data));
        public static TesteeBuilder<T> ExpectNoneMaybe<T>() => new TesteeBuilder<T>(new Maybe<T>());

        public class TesteeBuilder<T>
        {
            private readonly Maybe<T> testee;
            public TesteeBuilder(Maybe<T> testee)
                => this.testee = testee;

            public ToEqualBuilder<T> ToEqual()
                => new ToEqualBuilder<T>(true, testee);

            public ToEqualBuilder<T> ToNotEqual()
                => new ToEqualBuilder<T>(false, testee);
        }

        public class ToEqualBuilder<T>
        {
            private bool shouldEqual;
            private readonly Maybe<T> testee;

            public ToEqualBuilder(bool shouldEqual, Maybe<T> testee)
                => (this.shouldEqual, this.testee) = (shouldEqual, testee);

            public EqualWithBuilder<T> WithNull()
                => new EqualWithBuilder<T>(shouldEqual, testee, null); 
            public EqualWithBuilder<T> WithOtherSomeMaybe(T otherValue)
                => new EqualWithBuilder<T>(shouldEqual, testee, new Maybe<T>(otherValue)); 
            public EqualWithBuilder<T> WithOtherNoneMaybe()
                => new EqualWithBuilder<T>(shouldEqual, testee, new Maybe<T>()); 
            public EqualWithBuilder<T> WithOtherObject(object other)
                => new EqualWithBuilder<T>(shouldEqual, testee, other); 
        }

        public class EqualWithBuilder<T>
        {
            private bool shouldEqual;
            private readonly Maybe<T> testee;
            private readonly object other;

            public EqualWithBuilder(bool shouldEqual, Maybe<T> testee, object other)
                => (this.shouldEqual, this.testee, this.other) = (shouldEqual, testee, other);

            public EqualWithBuilder<T> OnObjectEquals() => AssertAndReturnSelf(
                () => Assert.AreEqual(shouldEqual, testee.Equals(other)));
            public EqualWithBuilder<T> OnEquatableEquals() => AssertAndReturnSelf(
                () => Assert.AreEqual(shouldEqual, testee.Equals((Maybe<T>)other)));
            public EqualWithBuilder<T> OnEqualityOperator() => AssertAndReturnSelf(
                () => Assert.AreEqual(shouldEqual, testee == (Maybe<T>)other));
            public EqualWithBuilder<T> OnInversedInequalityOperator() => AssertAndReturnSelf(
                () => Assert.AreEqual(shouldEqual, !(testee != (Maybe<T>)other)));
            public EqualWithBuilder<T> OnGetHashCode() => AssertAndReturnSelf(
                () => Assert.AreEqual(shouldEqual, testee.GetHashCode() == other.GetHashCode()));

            private EqualWithBuilder<T> AssertAndReturnSelf(Action assert)
            {
                assert();
                return this;
            }
        }
    }
}
