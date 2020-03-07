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
        /// Convert the maybe to an array of length 0 or 1.
        /// </summary>
        /// <returns>The result array.</returns>
        public T[] ToArray()
        {
            throw new NotImplementedException();
        }
    }
}
