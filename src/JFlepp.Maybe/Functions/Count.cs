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
        /// Evaluates the equivalent of <see cref="Enumerable.Count{TSource}(IEnumerable{TSource})" /> for a <see cref="Maybe{T}" />.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <returns>A zero if the <see cref="Maybe{T}" /> is None, a one otherwise.</returns>
        public static int Count<T>(this Maybe<T> input)
        {
            throw new NotImplementedException();
        }
    }
}
