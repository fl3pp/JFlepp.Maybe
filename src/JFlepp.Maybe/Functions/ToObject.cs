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
        /// Convert an <see cref="Maybe{T}" /> to a potentially null value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The result value, which is null if the input was None.</returns>
        /// <FSharp>
        /// let toObj value = match value with None -> null | Some x -> x
        /// // val toObj : value:'a option -> 'a when 'a : null
        /// </FSharp>
        /// <Implementation>
        /// object ToObject{T}(Maybe{T} input) => input.IsSome switch
        /// {
        ///     true => input.Value,
        ///     _ => null,
        /// }; 
        /// </Implementation>
        public static object ToObject<T>(this Maybe<T> input) => input.IsSome switch
        {
            true => input.Value,
            _ => null,
        }; 
    }
}
