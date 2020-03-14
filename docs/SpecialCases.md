# Maybe examples

## Direct value access

While the F# option type provides easy access to the value through the `Value` property, the Maybe library hides the direct value access in a separete namespace on a separate extension method.

~~~ fs
namespace JFlepp.Functional.Unsafe
{
    public static class MaybeExtensions
    {
        public static T GetValue<T>(this Maybe<T> maybe);
    }
}
~~~

While it does behave the same way the option type does (returns value or throws `NullReferenceException`), the method is being hidden in order to prevent misuse, respectively to enforce usage of the appropriate functions likely not known by an classic OO programmer.

## Creation

As the FSharp implementation of `option` is able to use a discriminated union, there are some substantial differences between F# and the maybe library in creation.

Description | FSharp | Maybe
----------- | ------ | -----
Some creation | `Some "string"` | `Maybe.Some("String")`
None creation | `None` | `Maybe.None<T>()`

_Tipp: Add the `using static JFlepp.Functional.Maybe` using declaration if you create lot's of maybes in a file._


Example of the functionality with F# language features:

~~~ fs
let getIntIf3 str =
  if str = "3" then Some (Int32.Parse str)
  else None
~~~

with the maybe library in C#:

~~~ cs
using static JFlepp.Functional.Maybe;

Maybe<int> GetIntIf3(string str) => str == "3"
  ? Some(int.Parse(str))
  : None<int>();
