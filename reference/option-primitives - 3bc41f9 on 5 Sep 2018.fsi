    /// <summary>The type of optional values. When used from other CLI languages the
    /// empty option is the <c>null</c> value. </summary>
    ///
    /// <remarks>Use the constructors <c>Some</c> and <c>None</c> to create values of this type.
    /// Use the values in the <c>Option</c> module to manipulate values of this type,
    /// or pattern match against the values directly.
    ///
    /// <c>None</c> values will appear as the value <c>null</c> to other CLI languages.
    /// Instance methods on this type will appear as static methods to other CLI languages
    /// due to the use of <c>null</c> as a value representation.</remarks>
    [<DefaultAugmentation(false)>]
    [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
    [<StructuralEquality; StructuralComparison>]
    [<CompiledName("FSharpOption`1")>]
    type Option<'T> =

        /// <summary>The representation of "No value"</summary>
        | None :       'T option

        /// <summary>The representation of "Value of type 'T"</summary>
        /// <param name="Value">The input value.</param>
        /// <returns>An option representing the value.</returns>
        | Some : Value:'T -> 'T option 

        /// <summary>Create an option value that is a 'None' value.</summary>
        static member None : 'T option

        /// <summary>Create an option value that is a 'Some' value.</summary>
        /// <param name="value">The input value</param>
        /// <returns>An option representing the value.</returns>
        static member Some : value:'T -> 'T option

        /// <summary>Implicitly converts a value into an optional that is a 'Some' value.</summary>
        /// <param name="value">The input value</param>
        /// <returns>An option representing the value.</returns>
        static member op_Implicit : value:'T -> 'T option

        [<CompilationRepresentation(CompilationRepresentationFlags.Instance)>]
        /// <summary>Get the value of a 'Some' option. A NullReferenceException is raised if the option is 'None'.</summary>
        member Value : 'T

        /// <summary>Return 'true' if the option is a 'Some' value.</summary>
        member IsSome : bool

        /// <summary>Return 'true' if the option is a 'None' value.</summary>
        member IsNone : bool
