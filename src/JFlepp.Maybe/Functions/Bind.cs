using System;

namespace JFlepp.Functional
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Invokes a function on a <see cref="Maybe{T}"/> value that itself yields an option.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="binder">A function that takes the value of type T from a <see cref="Maybe{T}"/> and transforms it into a <see cref="Maybe{T}"/> containing a value of type 'TOut'.</param>
        /// <returns>A maybe of the output type of the binder.</returns>
        /// <FSharp>
        /// let bind binder option = match option with None -> None | Some x -> binder x
        /// // val bind : binder:('a -> 'b option) -> option:'a option -> 'b option
        /// </FSharp>
        /// <Imlementation>
        /// Maybe{TOut} Bind{T, TOut}(Maybe{T} input, Func{T, Maybe{TOut}} binder) => input.IsSome switch
        /// {
        ///     true => binder(input.Value),
        ///     _ => None{TOut}(),
        /// };
        /// </Imlementation>
        public static Maybe<TOut> Bind<T, TOut>(this Maybe<T> input, Func<T, Maybe<TOut>> binder) => input.IsSome switch
        {
            true => binder.ThrowIfNull(nameof(binder))(input.Value),
            _ => Maybe.None<TOut>(),
        };
    }
}
