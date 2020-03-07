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
        /// Evaluates the equivalent of <see cref="Enumerable.Any{TSource}(IEnumerable{TSource}, Func{TSource, bool})" /> for a <see cref="Maybe{T}"/>.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <param name="predicate">A function that evaluates to a Boolean when given a value from the <see cref="Maybe{T}"/>.</param>
        /// <returns>Returns false if the <see cref="Maybe{T}"/> is None, otherwise it returns the result of applying the predicate to the <see cref="Maybe{T}"/> value.</returns>
        public static bool Any<T>(this Maybe<T> input, Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
