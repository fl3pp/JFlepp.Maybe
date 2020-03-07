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
        /// Convert the <see cref="Maybe{T}" /> to a list of length 0 or 1.
        /// </summary>
        /// <param name="input">The input <see cref="Maybe{T}"/>.</param>
        /// <returns>The result list.</returns>
        public static List<T> ToList<T>(this Maybe<T> input)
        {
            throw new NotImplementedException();
        }
    }
}
