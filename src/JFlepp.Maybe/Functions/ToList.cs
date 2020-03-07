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
        /// Convert the maybe to a list of length 0 or 1.
        /// </summary>
        /// <returns>The result list.</returns>
        public List<T> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
