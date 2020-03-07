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
        /// Transforms a maybe value by using a specified mapping function.
        /// </summary>
        /// <typeparam name="TOut">The output type of the mapping.</typeparam>
        /// <param name="mapping">A function to apply to the option value.</param>
        /// <returns>An option of the result of applying the mapping function, or None if the maybe is None.</returns>
        public Maybe<TOut> Select<TOut>(Func<T, TOut> mapping)
        {
            throw new NotImplementedException();
        }
    }
}
