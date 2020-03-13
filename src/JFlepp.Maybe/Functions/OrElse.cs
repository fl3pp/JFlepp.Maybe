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
        /// Returns <paramref name="input"/> if it is <c>Some</c>, otherwise returns <paramref name="ifNone"/>.
        /// </summary>
        /// <param name="input">The input option.</param>
        /// <param name="ifNone">The value to use if <paramref name="input"/> is <c>None</c>.</param>
        /// <returns>The input if the maybe is Some, else the alternate value.</returns>
        /// <FSharp>
        /// let orElse ifNone option = match option with None -> ifNone | Some _ -> option
        /// // val orElse : ifNone:'a option -> option:'a option -> 'a option
        /// </FSharp>
        /// <Implementation>
        /// Maybe{T} OrElse{T}(Maybe{T} input, T ifNone) => input.IsSome switch
        /// {
        ///     true => input,
        ///     _ => Maybe.Some(ifNone),
        /// };
        /// </Implementation>
        public static Maybe<T> OrElse<T>(this Maybe<T> input, T ifNone) => input.IsSome switch
        {
            true => input,
            _ => Maybe.Some(ifNone),
        };

        /// <summary>
        /// Returns <paramref name="input"/> if it is <c>Some</c>, otherwise evaluates <paramref name="ifNoneThunk"/> and returns the result.
        /// </summary>
        /// <param name="input">The input option.</param>
        /// <param name="ifNoneThunk">A thunk that provides an alternate option when evaluated.</param>
        /// <returns>The input if the maybe is Some, else the alternate value.</returns>
        /// <remarks><paramref name="ifNoneThunk"/> is not evaluated unless <paramref name="input"/> is <c>None</c>.</remarks>
        /// <FSharp>
        /// let orElseWith ifNoneThunk option = match option with None -> ifNoneThunk () | Some _ -> option
        /// // val orElseWith : ifNoneThunk:(unit -> 'a option) -> option:'a option -> 'a option
        /// </FSharp>
        /// <Implementation>
        /// Maybe{T} OrElse{T}(Maybe{T} input, Func{T} ifNoneThunk) => input.IsSome switch
        /// {
        ///     true => input,
        ///     _ => Maybe.Some(ifNoneThunk()),
        /// };
        /// </Implementation>
        public static Maybe<T> OrElse<T>(this Maybe<T> input, Func<T> ifNoneThunk) => input.IsSome switch
        {
            true => input,
            _ => Maybe.Some(ifNoneThunk.ThrowIfNull(nameof(ifNoneThunk))()),
        };
    }
}
