using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class ToArrayTests
    {
        [TestMethod]
        public void ToArray_WithSome_ReturnsOneItemArray()
        {
            var input = Maybe.Some(1);

            var result = input.ToArray();

            CollectionAssert.AreEqual(new[] { 1 }, result);
        }

        [TestMethod]
        public void ToArray_WithNone_ReturnsEmptyArray()
        {
            var input = Maybe.None<int>();

            var result = input.ToArray();

            CollectionAssert.AreEqual(Array.Empty<int>(), result);
        }
    }
}
