using System;

namespace JFlepp.Functional
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Gets the value of the maybe if the option is <c>Some</c>, otherwise returns the specified default value.
        /// </summary>
        /// <param name="input">The input maybe.</param>
        /// <param name="or">The specified default value.</param>
        /// <returns>The option if the option is Some, else the default value.</returns>
        /// <FSharp>
        /// let defaultValue value option = match option with None -> value | Some v -> v
        /// // val defaultValue : value:'a -> option:'a option -> 'a
        /// </FSharp>
        /// <Implementation>
        /// T SingleOr{T}(this Maybe{T} input, T or) => input.IsSome switch
        /// {
        ///     true => input.Value,
        ///     _ => or,
        /// };
        /// </Implementation>
        public static T SingleOr<T>(this Maybe<T> input, T or) => input.IsSome switch
        {
            true => input.Value,
            _ => or,
        };

        /// <summary>
        /// Gets the value of the option if the maybe is <c>Some</c>, otherwise evaluates <paramref name="or"/> and returns the result.
        /// </summary>
        /// <param name="input">The input maybe.</param>
        /// <param name="or">A thunk that provides a default value when evaluated.</param>
        /// <returns>The option if the option is Some, else the result of evaluating <paramref name="or"/>.</returns>
        /// <FSharp>
        /// let defaultWith defThunk option = match option with None -> defThunk () | Some v -> v
        /// // val defaultWith : defThunk:(unit -> 'a) -> option:'a option -> 'a
        /// </FSharp>
        /// <Implementation>
        /// T SingleOr{T}(Maybe{T} input, Func{T} or) => input.IsSome switch
        /// {
        ///     true => input.Value,
        ///     _ => or.ThrowIfNull(nameof(or))(),
        /// };
        /// </Implementation>
        public static T SingleOr<T>(this Maybe<T> input, Func<T> or) => input.IsSome switch
        {
            true => input.Value,
            _ => or.ThrowIfNull(nameof(or))(),
        };
    }
}
