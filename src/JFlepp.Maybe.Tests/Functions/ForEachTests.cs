using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Tests
{
    [TestClass]
    public class ForEachTests
    {
        [TestMethod]
        public void ForEach_WithSome_ExecutesAction()
        {
            var input = Maybe.Some(1);

            var hasBeenExecuted = false;
            input.ForEach(v => hasBeenExecuted = true);

            Assert.IsTrue(hasBeenExecuted);
        }

        [TestMethod]
        public void ForEach_WithNone_ExecutesAction()
        {
            var input = Maybe.None<int>();

            var hasBeenExecuted = false;
            input.ForEach(v => hasBeenExecuted = true);

            Assert.IsTrue(hasBeenExecuted);
        }
    }
}
