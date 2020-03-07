# Maybe and FSharp Option comparison

The type `JFlepp.Functional.Maybe` type is intended to be used as a direct substition for the FSharp option type.

## Function comparison table

These are the functions implemented as similar as they are in FSharp.   

FSharp | Maybe | Description
------ | ----- | -----------
`Option.bind: ('T -> 'U option) -> 'T option -> 'U option` | `Maybe<T>: Maybe<TOut> Bind<TOut>(Func<T, Maybe<TOut>> functor)` | Invokes a function on an optional value that itself yields an option.
`Option.count: 'T option -> int` | `Maybe<T>: int Count()` | Returns zero if the option is None, a one otherwise.
`Option.exists: ('T -> bool) -> 'T option -> bool` | `Maybe<T>: bool Any(Predicate<T> predicate)` | Evaluates the equivalent of `List.exists` (`IEnumerable.Any`) for an option.
`Option.filter: ('T -> bool) -> option:'T option -> 'T option` | `Maybe<T>: Maybe<T> Filter(Predicate<T> predicate)` | Invokes a function on a maybe that itself yields an option.
`Option.fold: ('State -> 'T -> 'State) -> 'State -> 'T option -> 'State` | `Maybe<T>: Maybe<TState> Fold<TState>(TState initial, Func<TState, T, TState> folder)` | Applies the supplied function with the supplied initial state and the value of the maybe if is Some.
`Option.foldBack:  ('T -> 'State -> 'State) -> 'T option -> 'State -> 'State` | `Maybe<T>: TState FoldBack<TState>(Func<T, TState, TState> folder, TState state)` | If the option is None, it returns the initial value of state. Otherwise, it returns the updated state, the result of applying the folder function with the option value and the initial state.
`Option.forall: ('T -> bool) -> 'T option -> bool` | `Maybe<T>: bool All(Predicate<T> predicate)` | Evaluates the equivalent of `List.forall` (`IEnumerable.All`) for an option.
`Option.iter: ('T -> unit) -> 'T option -> unit` | `Maybe<T>: Iterate(Action<T> action)` | Executes a function for an option value.
`Option.map: ('T -> 'U) -> 'T option -> 'U option` | `Maybe<T>: Maybe<TOut> Select<TOut>(Func<T, TOut> mapping)` | Transforms an option value by using a specified mapping function.
`Option.toArray: 'T option -> 'T []` | `Maybe<T>: T[] ToArray()` | Convert the option to an array of length 0 or 1.
`Option.toList: 'T option -> 'T list` | `Maybe<T>: List<T> ToList()` | Convert the option to a list of length 0 or 1.

_Note: While the `Option` functions are provided in a module, the maybe methods are provided as extension methods on the `Maybe<T>` type. Out of reasons for easier presentation, the definitions are shown as they were provided on the `Maybe<T>` type itself._

Functions from the Option module not ported as they were are implemented in the `Maybe<T>` type itself:

- `Option.get: 'T option -> 'T`, _Gets the value associated with the option._ 
- `Option.isNone: 'T option -> bool`, _Returns true if the option is None._
- `Option.isSome: 'T option -> bool`, _Returns true if the option is Some._


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

While it does behave the same way the option type does (returns value or throws `NullReferenceException`), the method is being hidden in order to prevent misuse, respectively to enforce usage of the appropriate functions likely not known by an classic OO programmer.

#### ToNullable

As the `Maybe<T>` type is not able to differentiate between value and reference types, two methods are available to provide the functionality of `Option.toNullable`:

~~~ cs
public class Maybe<T>
{
  ...
  
  public static T? ToNullableStruct<T>(this Maybe<T> input) where T : struct 
  public static T ToNullableReference<T>(this Maybe<T> input) where T : class

  ...
}
~~~

Both variants behave exactly as the `Option.toNullable` counterpart.

#### Creation

As the FSharp implementation of `option` is able to use a discriminated union, there are some substantial differences in creation.

Instead of comparing the definitions 1 to 1, im going to compare how the functions can be used.

Description | FSharp | Maybe
----------- | ------ | -----
Some creation | `Some "string"` | `Some("String")` |  
None creation | `None` | `None<T>()` | Add `using static JFlepp.Functional.Maybe`

_Note: All maybe examples include the `using static JFlepp.Functional.Maybe` using declaration._


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

Example of the functionality with F# language features:

~~~ fs
let stopIfNeeded sign =
  match sign with
  | Some _ -> printfn "Stopping"
  | None -> printfn "Driving"

(Message "Stop") |> Some |> stopIfNeeded // Stopping
None |> stopIfNeeded                     // Driving
~~~

with the maybe library in C#:

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
