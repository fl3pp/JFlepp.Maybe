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
        /// Invokes a function on a <see cref="Maybe{T}" /> that itself yields an option.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="predicate">A function that evaluates whether the value contained in the <see cref="Maybe{T}" /> should remain, or be filtered out.</param>
        /// <returns></returns>
        public static Maybe<T> Filter<T>(this Maybe<T> input, Predicate<T> predicate)
            => input.Match(v => predicate(v) ? input : Maybe.None<T>(), () => Maybe.None<T>());
    }
}
