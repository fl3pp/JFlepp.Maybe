using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class ToNullableTests
    {
        [TestMethod]
        public void ToNullable_WithReferenceSome_ReturnsValue()
        {
            var input = Maybe.Some("test");

            var result = input.ToNullable();

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ToNullable_WithReferenceNone_ReturnsNull()
        {
            var input = Maybe.None<string>();

            var result = input.ToNullable();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ToNullable_WithValueSome_ReturnsValue()
        {
            var input = Maybe.Some(1);

            var result = input.ToNullable();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ToNullable_WithValueNone_ReturnsNull()
        {
            var input = Maybe.None<int>();

            var result = input.ToNullable();

            Assert.IsNull(result);
        }
    }
}
