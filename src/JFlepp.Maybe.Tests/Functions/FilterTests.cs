using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        // Reference: None |> Option.filter (fun s -> s = "3") |> Option.isNone |> Dump
        public void Filter_WithNoneAndPredicateNotMatches_ReturnsNone()
        {
            var input = Maybe.None<string>();

            var result = input.Filter(t => false);

            Assert.AreEqual(Maybe.None<string>(), result);
        }

        [TestMethod]
        // Reference: Some "3" |> Option.filter (fun s -> s = "3") |> Option.isNone |> Dump
        public void Filter_WithSomeAndPredicateMatches_ReturnsSome()
        {
            var input = Maybe.Some("3");

            var result = input.Filter(t => t == "3");

            Assert.AreEqual(input, result);
        }

        [TestMethod]
        // Reference: Some "4" |> Option.filter (fun s -> s = "3") |> Option.isNone |> Dump
        public void Filter_WithSomeAndPredicateNotMatches_ReturnsNone()
        {
            var input = Maybe.Some("4");

            var result = input.Filter(t => t == "3");

            Assert.AreEqual(Maybe.None<string>(), result);
        }
    }
}
