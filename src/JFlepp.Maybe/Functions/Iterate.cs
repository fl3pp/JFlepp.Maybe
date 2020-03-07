using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes a function for a <see cref="Maybe{T}" /> value if is Some.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="action">A function to apply to the <see cref="Maybe{T}" /> value.</param>
        public static void Iterate<T>(this Maybe<T> input, Action<T> action)
        {
            throw new NotImplementedException();
        }
    }
}
