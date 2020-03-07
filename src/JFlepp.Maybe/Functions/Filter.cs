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
        /// Invokes a function on a maybe that itself yields an option.
        /// </summary>
        /// <param name="predicate">A function that evaluates whether the value contained in the maybe should remain, or be filtered out.</param>
        /// <returns></returns>
        public Maybe<T> Filter(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
