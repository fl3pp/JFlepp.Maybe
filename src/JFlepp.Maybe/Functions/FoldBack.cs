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
        /// If the <see cref="Maybe{T}" /> is None, it returns the initial value of state.
        /// Otherwise, it returns the updated state, the result of applying the folder function with the <see cref="Maybe{T}" /> value and the initial state.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="folder">A function to update the state data when given a value from a <see cref="Maybe{T}" />.</param>
        /// <param name="state">The initial state.</param>
        /// <returns>If the <see cref="Maybe{T}" /> is None, it returns the initial value of state.
        /// Otherwise, it returns the updated state, the result of applying the folder function with the <see cref="Maybe{T}" /> value and the initial state.</returns>
        public static TState FoldBack<T, TState>(this Maybe<T> input, Func<T, TState, TState> folder, TState state)
        {
            throw new NotImplementedException();
        }
        
    }
}
