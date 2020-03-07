using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    public partial struct Maybe<T>
    {
        /// <summary>
        /// Executes a function for an option value if is Some.
        /// </summary>
        /// <param name="action">A function to apply to the maybe value.</param>
        public void Iterate(Action<T> action)
        {
            throw new NotImplementedException();
        }
    }
}
