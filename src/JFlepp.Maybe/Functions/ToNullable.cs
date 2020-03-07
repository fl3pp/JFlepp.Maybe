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
        /// Convert the <see cref="Maybe{T}" /> to a Nullable value.
        /// </summary>
        /// <returns><see langword="null" /> if the <see cref="Maybe{T}" /> is None, the value otherwise.</returns>
        public static T? ToNullableStruct<T>(this Maybe<T> input) where T : struct
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert the <see cref="Maybe{T}" /> to a Nullable value.
        /// </summary>
        /// <returns><see langword="null" /> if the <see cref="Maybe{T}" /> is None, the value otherwise.</returns>
        public static T ToNullableReference<T>(this Maybe<T> input) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
