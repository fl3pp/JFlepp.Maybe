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
        /// Evaluates the equivalent of <see cref="Enumerable.Count{TSource}(IEnumerable{TSource})" /> for a maybe.
        /// </summary>
        /// <returns>A zero if the option is None, a one otherwise.</returns>
        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
