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
        /// Evaluates the equivalent of <see cref="Enumerable.All{TSource}(IEnumerable{TSource}, Func{TSource, bool})" /> for a maybe.
        /// </summary>
        /// <param name="predicate">A function that evaluates to a Boolean when given a value from the option type.</param>
        /// <returns>true if the maybe is None, otherwise it returns the result of applying the predicate to the maybe value.</returns>
        public bool All(Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
