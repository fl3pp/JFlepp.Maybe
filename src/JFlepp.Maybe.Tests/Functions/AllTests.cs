using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class AllTests
    {
        
        [TestMethod]
        // Reference: None |> Option.forall (fun s -> false) |> Dump 
        public void All_WithNonePredicateNotMatches_ReturnsTrue()
        {
            var input = Maybe.None<string>();

            var result = input.All(s => false);

            Assert.IsTrue(result);
        }

        [TestMethod]
        // Reference: Some "test" |> Option.forall (fun s -> true) |> Dump
        public void All_WithSomePredicateMatches_ReturnsTrue()
        {
            var input = Maybe.Some("test");

            var result = input.All(s => true);

            Assert.IsTrue(result);
        }

        [TestMethod]
        // Reference: Some "test" |> Option.forall (fun s -> false) |> Dump
        public void All_WithSomePredicateNotMatches_ReturnsFalse()
        {
            var input = Maybe.Some("test");

            var result = input.All(s => false);

            Assert.IsFalse(result);
        }
    }
}
