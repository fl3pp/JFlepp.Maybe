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
        /// Executes a function for a <see cref="Maybe{T}" /> value if is Some.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="action">A function to apply to the <see cref="Maybe{T}" /> value.</param>
        /// <FSharp>
        /// let iter action option = match option with None -> () | Some x -> action x
        /// // val iter : action:('a -> unit) -> option:'a option -> unit
        /// </FSharp>
        /// <Implementation>
        /// void ForEach{T}(this Maybe{T} input, Action{T} action)
        /// {
        ///     if (input.IsSome) action(input.Value);
        /// }
        /// </Implementation>
        public static void ForEach<T>(this Maybe<T> input, Action<T> action)
        {
            if (input.IsSome) action.ThrowIfNull(nameof(action))(input.Value);
        }
    }
}
