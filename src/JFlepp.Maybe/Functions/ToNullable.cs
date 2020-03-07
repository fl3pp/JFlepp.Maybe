using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    public static partial class Maybe
    {
        /// <summary>
        /// Convert the option to a Nullable value.
        /// </summary>
        /// <typeparam name="T">the value type of the maybe.</typeparam>
        /// <returns><see langword="null" /> if the maybe is None, the value otherwise.</returns>
        public static T? ToNullableStruct<T>(this Maybe<T> input) where T : struct
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert the option to a Nullable value.
        /// </summary>
        /// <typeparam name="T">the value type of the maybe.</typeparam>
        /// <returns><see langword="null" /> if the maybe is None, the value otherwise.</returns>
        public static T ToNullableReference<T>(this Maybe<T> input) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
