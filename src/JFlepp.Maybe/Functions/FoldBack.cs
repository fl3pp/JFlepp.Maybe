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
        /// If the maybe is None, it returns the initial value of state.
        /// Otherwise, it returns the updated state, the result of applying the folder function with the maybe value and the initial state.
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="folder">A function to update the state data when given a value from an option.</param>
        /// <param name="state">The initial state.</param>
        /// <returns>If the maybe is None, it returns the initial value of state.
        /// Otherwise, it returns the updated state, the result of applying the folder function with the maybe value and the initial state.</returns>
        public TState FoldBack<TState>(Func<T, TState, TState> folder, TState state)
        {
            throw new NotImplementedException();
        }
        
    }
}
