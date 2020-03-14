using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    public partial struct Maybe<T> : IEquatable<Maybe<T>>
    {
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public override bool Equals(object obj) => obj is Maybe<T> otherMaybe ? Equals(otherMaybe) : false;

        /// <summary>
        /// Indicates whether the current maybes value is equal to another maybes value.
        /// </summary>
        /// <param name="other">Another maybe to compare with this object.</param>
        /// <returns>true if the current maybe is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Maybe<T> other)
        {
            if (IsNone) return other.IsNone;
            if (other.IsNone) return false;

            return Value.Equals(other.Value);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return -1584136870 + EqualityComparer<T>.Default.GetHashCode(Value);
            }
        }

        /// <summary>
        /// Checks if two <see cref="Maybe{T}" /> are equal. 
        /// </summary>
        /// <param name="left">The left <see cref="Maybe{T}" /> to compare.</param>
        /// <param name="right">The right <see cref="Maybe{T}" /> to compare.</param>
        /// <returns><see langword="true" /> if objects are equal, <see langword="false" /> otherwise.</returns>
        public static bool operator ==(Maybe<T> left, Maybe<T> right) => left.Equals(right);

        /// <summary>
        /// Checks if two <see cref="Maybe{T}" /> are not equal. 
        /// </summary>
        /// <param name="left">The left <see cref="Maybe{T}" /> to compare.</param>
        /// <param name="right">The right <see cref="Maybe{T}" /> to compare.</param>
        /// <returns><see langword="true" /> if objects are not equal, <see langword="false" /> otherwise.</returns>
        public static bool operator !=(Maybe<T> left, Maybe<T> right) => !(left == right);
    }
}
