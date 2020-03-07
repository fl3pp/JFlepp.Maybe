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
        /// <param name="initial">The initial state.</param>
        /// <param name="folder">A function to update the state data when given a value from an option.</param>
        /// <returns>The original state if the <see cref="Maybe{T}" /> is None, otherwise it returns the updated state with the folder and the <see cref="Maybe{T}" /> value.</returns>
        public static Maybe<TState> Fold<T, TState>(this Maybe<T> input, TState initial, Func<TState, T, TState> folder)
        {
            throw new NotImplementedException();
        }
    }
}
