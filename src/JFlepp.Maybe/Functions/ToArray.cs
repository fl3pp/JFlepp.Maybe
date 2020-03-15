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
        /// Convert the <see cref="Maybe{T}" /> to an array of length 0 or 1.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <returns>The result array.</returns>
        /// <FSharp>
        /// let toArray option = match option with  None -> [| |] | Some x -> [| x |]
        /// // val toArray : option:'a option -> 'a []
        /// </FSharp>
        /// <Implementation>
        /// T[] ToArray{T}(Maybe{T} input) => input.IsSome switch
        /// {
        ///     true => new[] { input.Value },
        ///     _ => Array.Empty{T}(),
        /// };
        /// </Implementation>
        public static T[] ToArray<T>(this Maybe<T> input) => input.IsSome switch
        {
            true => new[] { input.Value },
            _ => new T[0],
        };
    }
}
