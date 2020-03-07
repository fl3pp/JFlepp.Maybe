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
        /// Transforms a <see cref="Maybe{T}" /> value by using a specified mapping function.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="mapping">A function to apply to the <see cref="Maybe{T}" /> value.</param>
        /// <returns>A <see cref="Maybe{T}" /> of the result of applying the mapping function, or None if the <see cref="Maybe{T}" /> is None.</returns>
        public static Maybe<TOut> Select<T, TOut>(this Maybe<T> input, Func<T, TOut> mapping)
        {
            throw new NotImplementedException();
        }
    }
}
