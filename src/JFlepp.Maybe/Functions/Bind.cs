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
        /// Invokes a function on an optional value that itself yields an option.
        /// </summary>
        /// <typeparam name="TOut">The return type of the binder.</typeparam>
        /// <param name="binder">A function that takes the value of type T from a maybe and transforms it into a maybe containing a value of type 'TOut'.</param>
        /// <returns>A maybe of the output type of the binder.</returns>
        public TOut Bind<TOut>(Func<T, TOut> binder)
        {
            throw new NotImplementedException();
        } 
    }
}
