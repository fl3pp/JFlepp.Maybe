using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    /// <summary>
    /// Provides functions for creating <see cref="Maybe{T}" />s.
    /// </summary>
    public static partial class Maybe
    {
        /// <summary>
        /// Creates a new none instance of <see cref="Maybe{T}" />.
        /// </summary>
        /// <typeparam name="T">The value type of the <see cref="Maybe{T}" />.</typeparam>
        /// <returns>A new none instance of <see cref="Maybe{T}" />.</returns>
        public static Maybe<T> None<T>() => new Maybe<T>();

        /// <summary>
        /// Creates a new some instance of <see cref="Maybe{T}" />.
        /// </summary>
        /// <param name="value">The value of the <see cref="Maybe{T}" />.</param>
        /// <typeparam name="T">The value type of the <see cref="Maybe{T}" />.</typeparam>
        /// <returns>A new some instance of <see cref="Maybe{T}" />.</returns>
        public static Maybe<T> Some<T>(T value) => new Maybe<T>(value);
    }
}
