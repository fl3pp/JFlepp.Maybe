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
        /// Evaluates to true if <paramref name="input"/> is <c>Some</c> and its value is equal to <paramref name="value"/>.
        /// </summary>
        /// <param name="input">The input maybe.</param>
        /// <param name="value">The value to test for equality.</param>
        /// <returns>True if the <see cref="Maybe{T}" /> is <c>Some</c> and contains a value equal to <paramref name="value"/>, otherwise false.</returns>
        /// <FSharp>
        /// let inline contains value option = match option with None -> false | Some v -> v = value
        /// // let inline contains value option = match option with None -> false | Some v -> v = value
        /// </FSharp>
        /// <Implementation>
        /// bool Contains{T}(Maybe{T} input, T value) => input.IsSome switch
        /// {
        ///     true => input.Value.Equals(value),
        ///     _ => false,
        /// };
        /// </Implementation>
        public static bool Contains<T>(this Maybe<T> input, T value) => input.IsSome switch
        {
            true => input.Value.Equals(value),
            _ => false,
        };
    }
}
