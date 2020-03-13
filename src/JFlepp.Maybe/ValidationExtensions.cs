using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    internal static class Validation
    {
        public static T ThrowIfNull<T>(this T value, string name)
            => value ?? throw new ArgumentNullException(name);
    }
}
