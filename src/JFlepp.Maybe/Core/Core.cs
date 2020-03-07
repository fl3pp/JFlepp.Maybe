using System;
using System.Collections.Generic;

namespace JFlepp.Functional
{
    /// <summary>
    /// Representation of a maybe value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public partial struct Maybe<T>
    {
        private readonly T value;

        /// <summary>
        /// Constructs a some value using the given value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Thrown value is <see langword="null"/>.</exception>
        public Maybe(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            (this.value, IsSome) = (value, true);
        }

        /// <summary>
        /// Gets the type of the <see cref="Maybe" />. Returns <see langword="true" /> if is some, <see langword="false" /> otherwise.
        /// </summary>
        public bool IsSome { get; }

        /// <summary>
        /// Gets the type of the <see cref="Maybe" />. Returns <see langword="true" /> if is none, <see langword="false" /> otherwise.
        /// </summary>
        public bool IsNone => !IsSome;
    }
}
