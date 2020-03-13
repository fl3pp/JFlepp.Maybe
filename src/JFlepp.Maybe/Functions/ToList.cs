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
        /// Convert the <see cref="Maybe{T}" /> to a list of length 0 or 1.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <returns>The result list.</returns>
        /// <FSharp>
        /// let toList option = match option with  None -> [ ] | Some x -> [ x ]
        /// // let toList option = match option with  None -> [ ] | Some x -> [ x ]
        /// </FSharp>
        /// <Implementation>
        /// List{T} ToList{T}(Maybe{T} input) => input.IsSome switch
        /// {
        ///     true => new List{T} { input.Value },
        ///     _ => new List{T}(),
        /// };
        /// </Implementation>
        public static List<T> ToList<T>(this Maybe<T> input) => input.IsSome switch
        {
            true => new List<T> { input.Value },
            _ => new List<T>(),
        };
    }
}
