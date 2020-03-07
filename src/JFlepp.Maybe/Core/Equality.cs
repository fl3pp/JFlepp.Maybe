using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    public partial struct Maybe<T> : IEquatable<Maybe<T>>
    {
        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public override bool Equals(object obj) => obj is Maybe<T> otherMaybe ? Equals(otherMaybe) : false;

        /// <inheritdoc cref="object.Equals(object)"/>
        public bool Equals(Maybe<T> other)
        {
            if (IsNone) return other.IsNone;
            if (other.IsNone) return false;

            return value.Equals(other.value);
        }

        /// <inheritdoc cref="object.Equals(object)"/>
        public override int GetHashCode()
        {
            unchecked
            {
                return -1584136870 + EqualityComparer<T>.Default.GetHashCode(value);
            }
        }

        /// <summary>
        /// Checks if two <see cref="Maybe{T}" /> are equal. 
        /// </summary>
        /// <param name="left">The right <see cref="Maybe{T}" /> to compare.</param>
        /// <param name="right">The left <see cref="Maybe{T}" /> to compare.</param>
        /// <returns><see langword="true" /> if objects are equal, <see langword="false" /> otherwise.</returns>
        public static bool operator ==(Maybe<T> left, Maybe<T> right) => left.Equals(right);

        /// <summary>
        /// Checks if two <see cref="Maybe{T}" /> not equal. 
        /// </summary>
        /// <param name="left">The right <see cref="Maybe{T}" /> to compare.</param>
        /// <param name="right">The left <see cref="Maybe{T}" /> to compare.</param>
        /// <returns><see langword="true" /> if objects are not equal, <see langword="false" /> otherwise.</returns>
        public static bool operator !=(Maybe<T> left, Maybe<T> right) => !(left == right);
    }
}
