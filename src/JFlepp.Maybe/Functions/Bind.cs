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
        public static Maybe<TOut> Bind<T, TOut>(this Maybe<T> input, Func<T, Maybe<TOut>> binder)
            => input.Match(v => binder(v), () => Maybe.None<TOut>());
    }
}
