using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional.Unsafe
{
    /// <summary>
    /// Provides unsafe extensions for <see cref="Maybe{T}" />s.
    /// </summary>
    public static class MaybeExtensions
    {
        /// <summary>
        /// Gets the value of the maybe if is some.
        /// </summary>
        /// <typeparam name="T">The value type of the <see cref="Maybe{T}" />.</typeparam>
        /// <param name="maybe">The <see cref="Maybe{T}" /> to get the value from.</param>
        /// <returns>The value of the <see cref="Maybe{T}" /> if is some.</returns>
        /// <exception cref="NullReferenceException">If the maybe is none.</exception>
        public static T GetValue<T>(this Maybe<T> maybe) => maybe.Match(s => s, () => throw new NullReferenceException());
    }
}
