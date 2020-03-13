using JFlepp.Functional.Unsafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void Select_WithSome_AppliesMapping()
        {
            var input = Maybe.Some(1);

            var result = input.Select(i => i.ToString());

            Assert.AreEqual("1", result.GetValue());
        }

        [TestMethod]
        public void Select_WithNone_ReturnsNone()
        {
            var input = Maybe.None<int>();

            var result = input.Select(i => i.ToString());

            Assert.IsTrue(result.IsNone);
        }
    }
}
