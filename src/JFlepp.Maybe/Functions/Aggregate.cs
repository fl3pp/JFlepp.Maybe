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
        /// Applies the supplied function with the supplied initial state and the value of the <see cref="Maybe{T}" /> if is Some.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="seed">The initial state.</param>
        /// <param name="func">A function to update the state data when given a value from an option.</param>
        /// <returns>The original state if the <see cref="Maybe{T}" /> is None, otherwise it returns the updated state with the folder and the <see cref="Maybe{T}" /> value.</returns>
        /// <FSharp>
        /// let fold{'T,'State} folder (state:'State) (option: option{'T}) = match option with None -> state | Some x -> folder state x
        /// // val fold :
        /// //   folder:('State -> 'T -> 'State) ->
        /// //     state:'State -> option:'T option -> 'State
        /// </FSharp>
        /// <Implementation>
        /// TState Aggregate{T, TState}(Maybe{T} input, TState state, Func{TState, T, TState} folder) => input.IsNone switch
        /// {
        ///     true => folder(state, input.Value),
        ///     _ => state,
        /// };
        /// </Implementation>
        public static TResult Aggregate<T, TResult>(this Maybe<T> input, TResult seed, Func<TResult, T, TResult> func) => input.IsSome switch
        {
            true => func.ThrowIfNull(nameof(func))(seed, input.Value),
            _ => seed,
        };
    }
}
