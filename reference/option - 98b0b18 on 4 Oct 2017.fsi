// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace Microsoft.FSharp.Core

    open System
    open Microsoft.FSharp.Core
    open Microsoft.FSharp.Collections
    open Microsoft.FSharp.Core.Operators
    open Microsoft.FSharp.Collections

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    /// <summary>Basic operations on options.</summary>
    module Option =
        /// <summary>Returns true if the option is not None.</summary>
        /// <param name="option">The input option.</param>
        /// <returns>True if the option is not None.</returns>
        [<CompiledName("IsSome")>]
        val inline isSome: option:'T option -> bool

        /// <summary>Returns true if the option is None.</summary>
        /// <param name="option">The input option.</param>
        /// <returns>True if the option is None.</returns>
        [<CompiledName("IsNone")>]
        val inline isNone: option:'T option -> bool

        /// <summary>Gets the value of the option if the option is <c>Some</c>, otherwise returns the specified default value.</summary>
        /// <param name="value">The specified default value.</param>
        /// <param name="option">The input option.</param>
        /// <returns>The option if the option is Some, else the default value.</returns>
        /// <remarks>Identical to the built-in <see cref="defaultArg"/> operator, except with the arguments swapped.</remarks>
        [<CompiledName("DefaultValue")>]
        val defaultValue: value:'T -> option:'T option -> 'T

        /// <summary>Gets the value of the option if the option is <c>Some</c>, otherwise evaluates <paramref name="defThunk"/> and returns the result.</summary>
        /// <param name="defThunk">A thunk that provides a default value when evaluated.</param>
        /// <param name="option">The input option.</param>
        /// <returns>The option if the option is Some, else the result of evaluating <paramref name="defThunk"/>.</returns>
        /// <remarks><paramref name="defThunk"/> is not evaluated unless <paramref name="option"/> is <c>None</c>.</remarks>
        [<CompiledName("DefaultWith")>]
        val defaultWith: defThunk:(unit -> 'T) -> option:'T option -> 'T

        /// <summary>Returns <paramref name="option"/> if it is <c>Some</c>, otherwise returns <paramref name="ifNone"/>.</summary>
        /// <param name="ifNone">The value to use if <paramref name="option"/> is <c>None</c>.</param>
        /// <param name="option">The input option.</param>
        /// <returns>The option if the option is Some, else the alternate option.</returns>
        [<CompiledName("OrElse")>]
        val orElse: ifNone:'T option -> option:'T option -> 'T option

        /// <summary>Returns <paramref name="option"/> if it is <c>Some</c>, otherwise evaluates <paramref name="ifNoneThunk"/> and returns the result.</summary>
        /// <param name="ifNoneThunk">A thunk that provides an alternate option when evaluated.</param>
        /// <param name="option">The input option.</param>
        /// <returns>The option if the option is Some, else the result of evaluating <paramref name="ifNoneThunk"/>.</returns>
        /// <remarks><paramref name="ifNoneThunk"/> is not evaluated unless <paramref name="option"/> is <c>None</c>.</remarks>
        [<CompiledName("OrElseWith")>]
        val orElseWith: ifNoneThunk:(unit -> 'T option) -> option:'T option -> 'T option

        /// <summary>Gets the value associated with the option.</summary>
        /// <param name="option">The input option.</param>
        /// <returns>The value within the option.</returns>
        /// <exception href="System.ArgumentException">Thrown when the option is None.</exception>
        [<CompiledName("GetValue")>]
        val get: option:'T option -> 'T

        /// <summary><c>count inp</c> evaluates to <c>match inp with None -> 0 | Some _ -> 1</c>.</summary>
        /// <param name="option">The input option.</param>
        /// <returns>A zero if the option is None, a one otherwise.</returns>
        [<CompiledName("Count")>]
        val count: option:'T option -> int

        /// <summary><c>fold f s inp</c> evaluates to <c>match inp with None -> s | Some x -> f s x</c>.</summary>
        /// <param name="folder">A function to update the state data when given a value from an option.</param>
        /// <param name="state">The initial state.</param>
        /// <param name="option">The input option.</param>
        /// <returns>The original state if the option is None, otherwise it returns the updated state with the folder
        /// and the option value.</returns>
        [<CompiledName("Fold")>]
        val fold<'T,'State> : folder:('State -> 'T -> 'State) -> state:'State -> option:'T option -> 'State

        /// <summary><c>fold f inp s</c> evaluates to <c>match inp with None -> s | Some x -> f x s</c>.</summary>
        /// <param name="folder">A function to update the state data when given a value from an option.</param>
        /// <param name="option">The input option.</param>
        /// <param name="state">The initial state.</param>
        /// <returns>The original state if the option is None, otherwise it returns the updated state with the folder
        /// and the option value.</returns>
        [<CompiledName("FoldBack")>]
        val foldBack<'T,'State> : folder:('T -> 'State -> 'State) -> option:'T option -> state:'State -> 'State

        /// <summary><c>exists p inp</c> evaluates to <c>match inp with None -> false | Some x -> p x</c>.</summary>
        /// <param name="predicate">A function that evaluates to a boolean when given a value from the option type.</param>
        /// <param name="option">The input option.</param>
        /// <returns>False if the option is None, otherwise it returns the result of applying the predicate
        /// to the option value.</returns>
        [<CompiledName("Exists")>]
        val exists: predicate:('T -> bool) -> option:'T option -> bool

        /// <summary><c>forall p inp</c> evaluates to <c>match inp with None -> true | Some x -> p x</c>.</summary>
        /// <param name="predicate">A function that evaluates to a boolean when given a value from the option type.</param>
        /// <param name="option">The input option.</param>
        /// <returns>True if the option is None, otherwise it returns the result of applying the predicate
        /// to the option value.</returns>
        [<CompiledName("ForAll")>]
        val forall: predicate:('T -> bool) -> option:'T option -> bool

        /// <summary>Evaluates to true if <paramref name="option"/> is <c>Some</c> and its value is equal to <paramref name="value"/>.</summary>
        /// <param name="value">The value to test for equality.</param>
        /// <param name="option">The input option.</param>
        /// <returns>True if the option is <c>Some</c> and contains a value equal to <paramref name="value"/>, otherwise false.</returns>
        [<CompiledName("Contains")>]
        val inline contains: value:'T -> option:'T option -> bool when 'T : equality

        /// <summary><c>iter f inp</c> executes <c>match inp with None -> () | Some x -> f x</c>.</summary>
        /// <param name="action">A function to apply to the option value.</param>
        /// <param name="option">The input option.</param>
        /// <returns>Unit if the option is None, otherwise it returns the result of applying the predicate
        /// to the option value.</returns>
        [<CompiledName("Iterate")>]
        val iter: action:('T -> unit) -> option:'T option -> unit

        /// <summary><c>map f inp</c> evaluates to <c>match inp with None -> None | Some x -> Some (f x)</c>.</summary>
        /// <param name="mapping">A function to apply to the option value.</param>
        /// <param name="option">The input option.</param>
        /// <returns>An option of the input value after applying the mapping function, or None if the input is None.</returns>
        [<CompiledName("Map")>]
        val map: mapping:('T -> 'U) -> option:'T option -> 'U option

        /// <summary><c>map f option1 option2</c> evaluates to <c>match option1, option2 with Some x, Some y -> Some (f x y) | _ -> None</c>.</summary>
        /// <param name="mapping">A function to apply to the option values.</param>
        /// <param name="option1">The first option.</param>
        /// <param name="option2">The second option.</param>
        /// <returns>An option of the input values after applying the mapping function, or None if either input is None.</returns>
        [<CompiledName("Map2")>]
        val map2: mapping:('T1 -> 'T2 -> 'U) -> 'T1 option -> 'T2 option -> 'U option

        /// <summary><c>map f option1 option2 option3</c> evaluates to <c>match option1, option2, option3 with Some x, Some y, Some z -> Some (f x y z) | _ -> None</c>.</summary>
        /// <param name="mapping">A function to apply to the option values.</param>
        /// <param name="option1">The first option.</param>
        /// <param name="option2">The second option.</param>
        /// <param name="option3">The third option.</param>
        /// <returns>An option of the input values after applying the mapping function, or None if any input is None.</returns>
        [<CompiledName("Map3")>]
        val map3: mapping:('T1 -> 'T2 -> 'T3 -> 'U) -> 'T1 option -> 'T2 option -> 'T3 option -> 'U option

        /// <summary><c>bind f inp</c> evaluates to <c>match inp with None -> None | Some x -> f x</c></summary>
        /// <param name="binder">A function that takes the value of type T from an option and transforms it into
        /// an option containing a value of type U.</param>
        /// <param name="option">The input option.</param>
        /// <returns>An option of the output type of the binder.</returns>
        [<CompiledName("Bind")>]
        val bind: binder:('T -> 'U option) -> option:'T option -> 'U option

        /// <summary><c>flatten inp</c> evaluates to <c>match inp with None -> None | Some x -> x</c></summary>
        /// <param name="option">The input option.</param>
        /// <returns>An option of the output type of the binder.</returns>
        /// <remarks><c>flatten</c> is equivalent to <c>bind id</c>.</remarks>
        [<CompiledName("Flatten")>]
        val flatten: option:'T option option -> 'T option

        /// <summary><c>filter f inp</c> evaluates to <c>match inp with None -> None | Some x -> if f x then Some x else None</c>.</summary>
        /// <param name="predicate">A function that evaluates whether the value contained in the option should remain, or be filtered out.</param>
        /// <param name="option">The input option.</param>
        /// <returns>The input if the predicate evaluates to true; otherwise, None.</returns>
        [<CompiledName("Filter")>]
        val filter: predicate:('T -> bool) -> option:'T option -> 'T option

        /// <summary>Convert the option to an array of length 0 or 1.</summary>
        /// <param name="option">The input option.</param>
        /// <returns>The result array.</returns>
        [<CompiledName("ToArray")>]
        val toArray: option:'T option -> 'T[]

        /// <summary>Convert the option to a list of length 0 or 1.</summary>
        /// <param name="option">The input option.</param>
        /// <returns>The result list.</returns>
        [<CompiledName("ToList")>]
        val toList: option:'T option -> 'T list


        /// <summary>Convert the option to a Nullable value.</summary>
        /// <param name="option">The input option.</param>
        /// <returns>The result value.</returns>
        [<CompiledName("ToNullable")>]
        val toNullable: option:'T option -> Nullable<'T>

        /// <summary>Convert a Nullable value to an option.</summary>
        /// <param name="value">The input nullable value.</param>
        /// <returns>The result option.</returns>
        [<CompiledName("OfNullable")>]
        val ofNullable: value:Nullable<'T> -> 'T option 

        /// <summary>Convert a potentially null value to an option.</summary>
        /// <param name="value">The input value.</param>
        /// <returns>The result option.</returns>
        [<CompiledName("OfObj")>]
        val ofObj: value: 'T -> 'T option  when 'T : null

        /// <summary>Convert an option to a potentially null value.</summary>
        /// <param name="value">The input value.</param>
        /// <returns>The result value, which is null if the input was None.</returns>
        [<CompiledName("ToObj")>]
        val toObj: value: 'T option -> 'T when 'T : null
