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
        /// Executes and returns the some functor with the <see cref="Maybe{T}" /> value if there is some,
        /// executes and returns the none functor otherwise
        /// </summary>
        /// <typeparam name="TOut">The output type of the functors.</typeparam>
        /// <param name="some">The some functor.</param>
        /// <param name="none">The none functor.</param>
        /// <returns>The return of either the some or none functor.</returns>
        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none)
        {
            if (some is null) throw new ArgumentNullException(nameof(some));
            if (none is null) throw new ArgumentNullException(nameof(none));

            return IsSome ? some(value) : none();
        }

        /// <summary>
        /// Executes the some functor with the <see cref="Maybe{T}" /> value is there is some,
        /// executes the none functor otherwise.
        /// </summary>
        /// <param name="some">The some functor.</param>
        /// <param name="none">The none functor.</param>
        public void Match(Action<T> some, Action none)
        {
            if (some is null) throw new ArgumentNullException(nameof(some));
            if (none is null) throw new ArgumentNullException(nameof(none));

            if (IsSome) some(value); else none();
        }
    }
}
