# Maybe API docs

This is the API documentation for the JFlepp.Maybe library. Please note that the implementations do not show the actual implementation, but rather a reference to look up the behavior.

## _Type:_ Maybe<T>

Representation of a maybe value.

### _Method:_ Construct

Constructs a some value using the given value.

_Parameters_

- `value`: The value of the maybe.

_Exceptions_

- `System.ArgumentNullException`: Thrown value is `null`.

_Maybe_

~~~ cs
public Maybe(T value)
{
	if (value == null) throw new ArgumentNullException(nameof(value));
	(Value, IsSome) = (value, true);
}
~~~

### _Property:_ IsSome

Gets the type of the `Maybe`. Returns `true` if is some, `false` otherwise.

### _Property:_ IsNone

Gets the type of the `Maybe`. Returns `true` if is none, `false` otherwise.

### _Method:_ Equals(System.Object)

Indicates whether the current object is equal to another object of the same type.

_Parameters_

- `obj`: An object to compare with this object.

_Returns:_ `true` if the current object is equal to the other parameter; otherwise, `false`.

_Maybe implementation_

~~~ cs
bool Equals(object obj) => obj is Maybe<T> otherMaybe ? Equals(otherMaybe) : false;
~~~

### _Method:_ GetHashCode()

Serves as the default hash function.

_Returns:_ A hash code for the current object.

_Maybe implementation_

~~~ cs
int GetHashCode()
{
	unchecked
	{
		return -1584136870 + EqualityComparer<T>.Default.GetHashCode(Value);
	}
}
~~~

### _Method:_ Equals(Maybe<T>)

Indicates whether the current maybes value is equal to another maybes value.

_Parameters_

- `other`: Another maybe to compare with this object.

_Returns:_ `true` if the current maybe is equal to the other parameter; otherwise, `false`.

_Maybe implementation_

~~~ cs
bool Equals(Maybe<T> other)
{
	if (IsNone) return other.IsNone;
	if (other.IsNone) return false;

	return Value.Equals(other.Value);
}
~~~

### _Operator:_ Maybe<T> == Maybe<T>

Checks if two `Maybe<T>`s are equal.

_Parameters_

- `right`: The right `Maybe<T>` to compare.
- `left`: The left`Maybe<T>` to compare.

_Returns:_ `true` if objects are equal, `false` otherwise.

_Maybe implementation_

~~~ cs
bool operator ==(Maybe<T> left, Maybe<T> right) => left.Equals(right);
~~~

### _Operator:_ Maybe<T> != Maybe<T>

Checks if two `Maybe<T>`s are not equal.

_Parameters_

- `right`: The right `Maybe<T>` to compare.
- `left`: The left`Maybe<T>` to compare.

_Returns:_ `true` if objects are not equal, `false` otherwise.

_Maybe implementation_

~~~ cs
bool operator !=(Maybe<T> left, Maybe<T> right) => !(left == right);
~~~

## _Type:_ Maybe
	
Provides functions for creating `Maybe<T>`s.

### _Method:_ None<T>()

Creates a new none instance of `Maybe<1>`

_Returns:_ A new none instance of `Maybe<T>`

### _Method:_ Some<T>(T value)

Creates a new some instance of `Maybe<T>`.

_Parameters_

- `value`: The value of the `Maybe<T>`.

_Returns:_ A new some instance of `Maybe<T>`.

### _Method:_ FromObject<T>(T value)

Convert a potentially null value to an option.

_Parameters_

- `value`: The input value.

_Returns:_ The result option.

_FSharp implementation_

~~~ fs
let ofObj value = match value with null -> None | _ -> Some value
// val ofObj : value:'a -> 'a option when 'a : null
~~~

_Maybe implementation_

~~~ cs
Maybe<T> OfObject<T>(T value) => (value == null) switch
{
	true => Some(value),
	_ => None<T>(),
};
~~~
	
## _Type:_ MaybeExtensions

Provides extension methods for working with the `Maybe<T>` type.

### _Method:_ Aggregate<T, TState>(Maybe<T> input, TState state, Func<TState, T, TState> folder)

Applies the supplied function with the supplied initial state and the value of the `Maybe<T>` if is Some.

_Parameters_

- `input`: The input `Maybe<T>`.
- `seed`: The initial state.
- `func`: A function to update the state data when given a value from an option.

_Returns:_ The original state if the `Maybe` is `None`, otherwise it returns the updated state with the folder and the `Maybe<T>` value.

_FSharp implementation_

~~~ fs
let fold{'T,'State} folder (state:'State) (option: option{'T}) = match option with None -> state | Some x -> folder state x
// val fold :
//   folder:('State -> 'T -> 'State) ->
//     state:'State -> option:'T option -> 'State	
~~~

_Maybe implementation_

~~~ cs
TState Aggregate<T, TState>(Maybe<T> input, TState state, Func<TState, T, TState> folder) => input.IsNone switch
{
	true => folder(state, input.Value),
	_ => state,
};
~~~

### _Method:_ All<T>(Maybe<T> input, Predicate<T> predicate)

Evaluates the equivalent of `System.Linq.Enumerable.All` for a `Maybe<T>`.

_Parameters_

- `input`: The input `Maybe<T>`.
- `predicate`: A function that evaluates to a `bool` when given a value from the `Maybe<T>`.

_Returns:_ `true` if the maybe is `None`, otherwise it returns the result of applying the predicate to the `Maybe<T>` value.

_FSharp implementation_

~~~ fs
let forall predicate option = match option with None -> true | Some x -> predicate x
// val forall : predicate:('a -> bool) -> option:'a option -> bool
~~~

_Maybe implementation_

~~~ cs
bool All<T>(Maybe<T> input, Predicate<T> predicate) => input.IsNone switch
{
	true => predicate(input.Value),
	_ => true,
};
~~~

### _Method:_ Any<T>(Maybe<T> input, Predicate<T> predicate)

Evaluates the equivalent of `System.Linq.Enumerable.Any` for a `Maybe<T>`.

_Parameters_

- `input`: The input `Maybe<T>`.
- `predicate`: A function that evaluates to a Boolean when given a value from the `Maybe<T>`.

_Returns:_ Returns false if the `Maybe<T>` is `None`, otherwise it returns the result of applying the predicate to the `Maybe<T>`s value.</returns>

_FSharp implementation_

~~~ fs
let exists predicate option = match option with None -> false | Some x -> predicate x
// val exists : predicate:('a -> bool) -> option:'a option -> bool
~~~

_Maybe implementation_

~~~ cs
bool Any<T>(Maybe<T> input, Predicate<T> predicate) => input.IsSome switch
{
   true => predicate(input.Value),
   _ => false,
};
~~~

### _Method:_ Bind<T, TOut>(Maybe<T> input, Func<T, Maybe<TOut>> binder)

Invokes a function on a `Maybe<T>` value that itself yields an option.

_Parameters_

- `input`: The input `Maybe<T>`.
- `binder`: A function that takes the value of type T from a `Maybe<T>` and transforms it into a `Maybe<T>` containing a value of type `TOut`.

_Returns:_ A maybe of the output type of the binder.

_FSharp implementation_

~~~ fs
let bind binder option = match option with None -> None | Some x -> binder x
// val bind : binder:('a -> 'b option) -> option:'a option -> 'b option
~~~

_Maybe implementation_

~~~ cs
Maybe<TOut> Bind<T, TOut>(Maybe<T> input, Func<T, Maybe<TOut>> binder) => input.IsSome switch
{
	true => binder(input.Value),
	_ => None{TOut}(),
};
~~~

### _Method:_ Contains<T>(Maybe<T> input, T value)

Evaluates to true if `input` is `Some` and its value is equal to `value`.

_Parameters_

- `input`: The input maybe.
- `value`: The value to test for equality.

_Returns:_ `true` if the `Maybe<T>` is `Some` and contains a value equal to `value`, otherwise `false`.

_FSharp implementation_

~~~ fs
let inline contains value option = match option with None -> false | Some v -> v = value
// let inline contains value option = match option with None -> false | Some v -> v = value
~~~

_Maybe implementation_

~~~ cs
bool Contains<T>(Maybe<T> input, T value) => input.IsSome switch
{
	true => input.Value.Equals(value),
	_ => false,
};
~~~

### _Method:_ Count<T>(Maybe<T> input)

Evaluates the equivalent of `System.Linq.Enumerable.Count` for a `Maybe<T>`.

_Parameters_

- `input`: The input `Maybe<T>`.

_Returns:_ A zero if the `Maybe<T>` is None, a one otherwise.</returns>

_FSharp implementation_

~~~ fs
count option = match option with None -> 0 | Some _ -> 1
// val count : option:'a option -> int
~~~

_Maybe implementation_

~~~ cs
int Count<T>(Maybe<T> input) => input.IsSome switch
{
	true => 1,
	_ => 0,
};
~~~
	
### _Method:_ ForEach<T>(Maybe<T> input, Action<T> action)

Executes a function for a `Maybe` value if is `Some`.

_Parameters_

- `input`: The input `Maybe<T>`.
- `action`: A function to apply to the `Maybe` value.

_FSharp implementation_

~~~ fs
let iter action option = match option with None -> () | Some x -> action x
// val iter : action:('a -> unit) -> option:'a option -> unit
~~~

_Maybe implementation_

~~~ cs
void ForEach<T>(Maybe<T> input, Action<T> action)
{
	if (input.IsSome) action(input.Value);
}
~~~

	
### _Method:_ OrElse<T>(Maybe<T> input, T ifNone)

Returns `input` if it is `Some`, otherwise returns `ifNone`.

_Parameters_

- `input`: The input option.
- `ifNone`: The value to use if `input` is `None`.

_Returns:_ The input if the maybe is `Some`, else the alternate value.

_FSharp implementation_

~~~ fs
let orElse ifNone option = match option with None -> ifNone | Some _ -> option
// val orElse : ifNone:'a option -> option:'a option -> 'a option
~~~

_Maybe implementation_

~~~ cs
Maybe<T> OrElse<T>(Maybe<T> input, T ifNone) => input.IsSome switch
{
	true => input,
	_ => Maybe.Some(ifNone),
};
~~~


### _Method:_ OrElse<T>(Maybe<T> input, Func<T> ifNoneThunk)

Returns `input` if it is `Some`, otherwise evaluates `ifNoneThunk` and returns the result.

`ifNoneThunk` is not evaluated unless `input` is `None`.

_Parameters_

- `input`: The input option.
- `ifNoneThunk`: A thunk that provides an alternate option when evaluated.

_Returns:_ The input if the maybe is `Some`, else the alternate value.


_FSharp implementation_

~~~ fs
let orElseWith ifNoneThunk option = match option with None -> ifNoneThunk () | Some _ -> option
// val orElseWith : ifNoneThunk:(unit -> 'a option) -> option:'a option -> 'a option
~~~

_Maybe implementation_

~~~ cs
Maybe<T> OrElse<T>(Maybe<T> input, Func<T> ifNoneThunk) => input.IsSome switch
{
	true => input,
	_ => Maybe.Some(ifNoneThunk()),
};
~~~


### _Method:_ Select<T, TOut>(Maybe<T> input, Func<T, TOut> mapping)


Transforms a `Maybe<T>` value by using a specified mapping function.

_Parameters_

- `input`: The input `Maybe<T>`.
- `mapping`: A function to apply to the `Maybe<T>` value.

_Returns:_ A `Maybe<T>` of the result of applying the mapping function, or `None` if the `Maybe<T>` is `None`.

_FSharp implementation_

~~~ fs
let map mapping option = match option with None -> None | Some x -> Some (mapping x)
// val map : mapping:('a -> 'b) -> option:'a option -> 'b option
~~~

_Maybe implementation_

~~~ cs
Maybe<TOut> Select<T, TOut>(Maybe<T> input, Func<T, TOut> mapping) => input.IsSome switch
{
	true => Some(mapping(input.Value)),
	_ => None{TOut}()
};
~~~


### _Method:_ SingleOr<T>(Maybe<T> input, T or)

Gets the value of the maybe if the option is `Some`, otherwise returns the specified default value.

_Parameters_

- `input`: The input maybe.
- `or`: The specified default value.

_Returns:_ The option if the option is Some, else the default value.

_FSharp implementation_

~~~ fs
let defaultValue value option = match option with None -> value | Some v -> v
// val defaultValue : value:'a -> option:'a option -> 'a
~~~

_Maybe implementation_

~~~ cs
T SingleOr<T>(Maybe<T> input, T or) => input.IsSome switch
{
	true => input.Value,
	_ => or,
};
~~~


### _Method:_ SingleOr<T>(Maybe<T> input, Func<T> or)

Gets the value of the option if the maybe is `Some`, otherwise evaluates `or` and returns the result.

_Parameters_

- `input`: The input maybe.
- `or`: A thunk that provides a default value when evaluated.

_Returns:_ The maybe if the maybe is `Some`, else the result of evaluating `or`.

_FSharp implementation_

~~~ fs
let defaultWith defThunk option = match option with None -> defThunk () | Some v -> v
// val defaultWith : defThunk:(unit -> 'a) -> option:'a option -> 'a
~~~

_Maybe implementation_

~~~ cs
T SingleOr<T>(Maybe<T> input, Func<T> or) => input.IsSome switch
{
	true => input.Value,
	_ => or.ThrowIfNull(nameof(or))(),
};
~~~


### _Method:_ ToArray<T>(Maybe<T> input)

Convert the `Maybe<T>` to an array of length 0 or 1.

_Parameters_

- `input`: The input `Maybe<T>`.

_Returns:_ The result array.

_FSharp implementation_

~~~ fs
let toArray option = match option with  None -> [| |] | Some x -> [| x |]
// val toArray : option:'a option -> 'a []
~~~

_Maybe implementation_

~~~ cs
T[] ToArray<T>(Maybe<T> input) => input.IsSome switch
{
	true => new[] { input.Value },
	_ => Array.Empty{T}(),
};
~~~


### _Method:_ ToList<T>(Maybe<T> input)

Convert the `Maybe<T>` to a list of length `0` or `1`.

_Parameters_

- `input`: The input `Maybe<T>`.

_Returns:_ The result list.

_FSharp implementation_

~~~ fs
let toList option = match option with  None -> [ ] | Some x -> [ x ]
// let toList option = match option with  None -> [ ] | Some x -> [ x ]
~~~

_Maybe implementation_

~~~ cs
List<T> ToList<T>(Maybe<T> input) => input.IsSome switch
{
	true => new List{T} { input.Value },
	_ => new List{T}(),
};
~~~


### _Method:_ ToObject<T>(Maybe<T> input)

Convert an `Maybe<T>` to a potentially null value.

_Parameters_

- `input` The input value.

_Returns:_ The result value, which is null if the input was `None`.

_FSharp implementation_

~~~ fs
let toObj value = match value with None -> null | Some x -> x
// val toObj : value:'a option -> 'a when 'a : null
~~~

_Maybe implementation_

~~~ cs
object ToObject<T>(Maybe<T> input) => input.IsSome switch
{
	true => input.Value,
	_ => null,
}; 
~~~


### _Method:_ Where<T>(Maybe<T> input, Predicate<T> predicate)

Invokes a function on a `Maybe<T>` that itself yields an option.

_Parameters_

- `input`: The input `Maybe<T>`.
- `predicate` A function that evaluates whether the value contained in the `Maybe<T>` should remain, or be filtered out.

_Returns:_ The input if the predicate evaluates to `true`; otherwise, `None`.

_FSharp implementation_

~~~ fs
let filter predicate option = match option with None -> None | Some x -> if predicate x then Some x else None
// val filter : predicate:('a -> bool) -> option:'a option -> 'a option
~~~

_Maybe implementation_

~~~ cs
Maybe<T> Where<T>(Maybe<T> input, Predicate<T> predicate) => input.IsSome switch
{
	true => predicate(input.Value) ? input : None{T}(),
	_ => None{T}(),
};
~~~


## _Type:_ MaybeStructExtensions

Provides extensions for struct `Maybe`s.

### _Method:_ ToNullable<T>(Maybe<T> input)

Convert the `Maybe<T>` to a Nullable value.

_Returns:_ `null` if the `Maybe<T>` is `None`, the value otherwise.

_FSharp implementation_

~~~ fs
let toNullable option = match option with None -> System.Nullable() | Some v -> System.Nullable(v)
// val toNullable :
//  option:'a option -> System.Nullable{'a}
//      when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
~~~

_Maybe implementation_

~~~ cs
T? ToNullable<T>(Maybe<T> input) where T : struct => input.IsSome switch
{
	true => input.Value,
	_ => null,
};
~~~


## _Type:_ MaybeReferenceExtensions

Provides extensions for reference `Maybe`s.

### _Method:_ ToNullable<T>(Maybe<T> input)

Convert the `Maybe<T>` to a Nullable value.

_Returns:_ `null` if the `Maybe<T>` is `None`, the value otherwise.

_FSharp implementation_

~~~ fs
let toNullable option = match option with None -> System.Nullable() | Some v -> System.Nullable(v)
// val toNullable :
//  option:'a option -> System.Nullable{'a}
//      when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
~~~

_Maybe implementation_

~~~ cs
T ToNullable<T>(Maybe<T> input) where T : class => input.IsSome switch
{
	true => input.Value,
	_ => null,
};
~~~


## _Type:_ Unsafe.MaybeExtensions

Provides unsafe extensions for `Maybe<T>`s.

### _Method:_ GetValue<T>(Maybe<T> input)

Gets the value of the maybe if is `Some`.

_Parameters_

- `input`: The `Maybe<T>` to get the value from.

_Returns:_ The value of the `Maybe<T>` if is `Some`.

_Exceptions_

- `System.NullReferenceException`: If the maybe is `None`.

_FSharp implementation_

~~~ fs
let get option = match option with None -> invalidArg "option" (SR.GetString(SR.optionValueWasNone)) | Some x -> x
// val get: option:'T option -> 'T
~~~

_Maybe implementation_

~~~ cs
T GetValue<T>(Maybe<T> input) => input.IsSome switch
{
	true => input.Value,
	_ => throw new NullReferenceException(),
};
~~~
