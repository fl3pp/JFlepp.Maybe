using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class CountTests
    {
        [TestMethod]
        // Reference: None |> Option.count |> Dump
        public void Count_WithNone_Returns0()
        {
            var input = Maybe.None<int>();

            var result = input.Count();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        // Reference: Some 10 |> Option.count |> Dump
        public void Count_WithSome_Returns1()
        {
            var input = Maybe.Some(10);

            var result = input.Count();

            Assert.AreEqual(1, result);
        }
    }
}
