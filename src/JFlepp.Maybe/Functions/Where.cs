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
        /// <FSharp>
        /// let filter predicate option = match option with None -> None | Some x -> if predicate x then Some x else None
        /// // val filter : predicate:('a -> bool) -> option:'a option -> 'a option
        /// </FSharp>
        /// <Implementation>
        /// Maybe{T} Where{T}(Maybe{T} input, Predicate{T} predicate) => input.IsSome switch
        /// {
        ///     true => predicate(input.Value) ? input : None{T}(),
        ///     _ => None{T}(),
        /// };
        /// </Implementation>
        public static Maybe<T> Where<T>(this Maybe<T> input, Predicate<T> predicate) => input.IsSome switch
        {
            true => predicate.ThrowIfNull(nameof(predicate))(input.Value) ? input : Maybe.None<T>(),
            _ => Maybe.None<T>(),
        };
    }
}
