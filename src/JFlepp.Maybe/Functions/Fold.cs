using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    public partial struct Maybe<T>
    {
        /// <summary>
        /// Applies the supplied function with the supplied initial state and the value of the maybe if is Some.
        /// </summary>
        /// <typeparam name="TState">The output of the fold.</typeparam>
        /// <param name="initial">The initial state.</param>
        /// <param name="folder">A function to update the state data when given a value from an option.</param>
        /// <returns>The original state if the maybe is None, otherwise it returns the updated state with the folder and the maybe value.</returns>
        public Maybe<TState> Fold<TState>(TState initial, Func<TState, T, TState> folder)
        {
            throw new NotImplementedException();
        }
    }
}
