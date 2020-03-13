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
        /// Evaluates the equivalent of <see cref="Enumerable.Count{TSource}(IEnumerable{TSource})" /> for a <see cref="Maybe{T}" />.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <returns>A zero if the <see cref="Maybe{T}" /> is None, a one otherwise.</returns>
        /// <FSharp>
        /// count option = match option with None -> 0 | Some _ -> 1
        /// // val count : option:'a option -> int
        /// </FSharp>
        /// <Implementation>
        /// int Count{T}(Maybe{T} input) => input.IsSome switch
        /// {
        ///     true => 1,
        ///     _ => 0,
        /// };
        /// </Implementation>
        public static int Count<T>(this Maybe<T> input) => input.IsSome switch
        {
            true => 1,
            _ => 0,
        };
    }
}
