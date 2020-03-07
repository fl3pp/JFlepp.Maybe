using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class BindTests
    {
        [TestMethod]
        // Reference: Some 1 |> Option.bind (fun s -> Some (s.ToString())) |> Dump
        public void Bind_WithSome_ReturnsOutputOfMapping()
        {
            var input = Maybe.Some(true);

            var result = input.Bind(b => Maybe.Some(b.ToString()));

            Assert.AreEqual(Maybe.Some("True"), result);
        }

        [TestMethod]
        // Reference: None |> Option.bind (fun s -> Some (s.ToString())) |> Option.isNone |> Dump
        public void Bind_WithNone_ReturnsNoneOfOutput()
        {
            var input = Maybe.None<bool>();

            var result = input.Bind(b => Maybe.Some(b.ToString()));

            Assert.AreEqual(Maybe.None<string>(), result);
        }
    }
}
