# Maybe and FSharp Option comparison table

The type `JFlepp.Functional.Maybe` type is intended to be used as a direct substition for the FSharp option type.

## Usage Comparison

These are the functions implemented nearly exactly as they are in FSharp.   


_Look up the MSDN documentation (link at the bottom) for more informations about the functions in F#._

## Special cases

#### Direct value access

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

While it does behave the same way the option type does (returns value or throws `NullReferenceException`), the method is being hidden in order to prevent misuse, respectively instead of an appropriate function likely not known by an OO-only programmer.

#### Creation

As the FSharp implementation of `option` is able to use a discriminated union, there are some substantial differences in creation.

Instead of comparing the definitions 1 to 1, im going to compare how the functions can be used.

Description | FSharp | Maybe
----------- | ------ | -----
Some creation | `Some "string"` | `Some("String")` |  
None creation | `None` | `None<T>()` | Add `using static JFlepp.Functional.Maybe`

_Note: All maybe examples include the `using static JFlepp.Functional.Maybe` using declaration._


_Example of the same functionality with F# language features:_

~~~ fs
let getIntIf3 str =
  if str = "3" then Some (Int32.Parse str)
  else None
~~~

_and the maybe library in C#:_

~~~ cs
using static JFlepp.Functional.Maybe;

Maybe<int> GetIntIf3(string str) => str == "3"
  ? Some(int.Parse(str))
  : None<int>();
~~~

#### Matching

FSharp provides pattern matching as a language feature, while csharp doesn't.

To overcome this obstacle, there are two methods available on the `Maybe<T>` type that try to copy the functionality one would get from fsharp pattern matching.

~~~ cs
struct Maybe<T>
{
    ...

    TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none);

    void Match(Action<T> some, Action none);

    ...
}
~~~

_Example of the same functionality with F# language features:_

~~~ fs
let stopIfNeeded sign =
  match sign with
  | Some _ -> printfn "Stopping"
  | None -> printfn "Driving"

(Message "Stop") |> Some |> stopIfNeeded // Stopping
None |> stopIfNeeded                     // Driving
~~~

_and the maybe library in C#:_

~~~ cs
void StopIfNeeded(Maybe<StopSign> sign) => sign.Match(
  s => Console.WriteLine("Stopping"),
  () => Console.WriteLine("Driving"));

var sign = Some(new StopSign());
StopIfNeeded(sign);                   // Stopping
	
var noSign = None<StopSign>();
StopIfNeeded(noSign);                 // Driving
~~~

## References

- MSDN: https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.option-module-%5Bfsharp%5D?f=255&MSPPError=-2147217396  
- FSharp.Core on NuGet: https://www.nuget.org/packages/FSharp.Core/
