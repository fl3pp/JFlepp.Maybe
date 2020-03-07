    [<DefaultAugmentation(false)>]
    [<DebuggerDisplay("Some({Value})")>]
    [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
    [<CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId="Option")>]
    [<StructuralEquality; StructuralComparison>]
    [<CompiledName("FSharpOption`1")>]
    type Option<'T> = 
        | None :       'T option
        | Some : Value:'T -> 'T option 

        [<CompilationRepresentation(CompilationRepresentationFlags.Instance)>]
        member x.Value = match x with Some x -> x | None -> raise (new System.InvalidOperationException("Option.Value"))

        [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
        member x.IsNone = match x with None -> true | _ -> false

        [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
        member x.IsSome = match x with Some _ -> true | _ -> false

        [<DebuggerBrowsable(DebuggerBrowsableState.Never)>]
        static member None : 'T option = None

        static member Some (value) : 'T option = Some(value)

        static member op_Implicit (value) : 'T option = Some(value)

        override x.ToString() = 
           // x is non-null, hence Some
           "Some("^anyToStringShowingNull x.Value^")"

    and 'T option = Option<'T> 