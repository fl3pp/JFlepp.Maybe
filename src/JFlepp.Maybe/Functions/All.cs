using System;
using System.Collections.Generic;
using System.Linq;

namespace JFlepp.Functional
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Evaluates the equivalent of <see cref="Enumerable.All{TSource}(IEnumerable{TSource}, Func{TSource, bool})" /> for a <see cref="Maybe{T}" />.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="predicate">A function that evaluates to a <see langword="bool" /> when given a value from the <see cref="Maybe{T}" />.</param>
        /// <returns><see langword="true" /> if the maybe is None, otherwise it returns the result of applying the predicate to the <see cref="Maybe{T}" /> value.</returns>
        /// <FSharp>
        /// let forall predicate option = match option with None -> true | Some x -> predicate x
        /// // val forall : predicate:('a -> bool) -> option:'a option -> bool
        /// </FSharp>
        /// <Implementation>
        /// bool All{T}(Maybe{T} input, Predicate{T} predicate) => input.IsNone switch
        /// {
        ///     true => predicate(input.Value),
        ///     _ => true,
        /// };
        /// </Implementation>
        public static bool All<T>(this Maybe<T> input, Predicate<T> predicate) => input.IsNone switch
        {
            true => predicate.ThrowIfNull(nameof(predicate))(input.Value),
            _ => true,
        };
    }
}
