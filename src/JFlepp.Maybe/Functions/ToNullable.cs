using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    /// <summary>
    /// Provides extensions for struct <see cref="Maybe{T}" />s.
    /// </summary>
    public static partial class MaybeStructExtensions
    {
        /// <summary>
        /// Convert the <see cref="Maybe{T}" /> to a Nullable value.
        /// </summary>
        /// <returns><see langword="null" /> if the <see cref="Maybe{T}" /> is None, the value otherwise.</returns>
        /// <FSharp>
        /// let toNullable option = match option with None -> System.Nullable() | Some v -> System.Nullable(v)
        /// // val toNullable :
        /// //  option:'a option -> System.Nullable{'a}
        /// //      when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
        /// </FSharp>
        /// <Implementation>
        /// T? ToNullable{T}(Maybe{T} input) where T : struct => input.IsSome switch
        /// {
        ///     true => input.Value,
        ///     _ => null,
        /// };
        /// </Implementation>
        public static T? ToNullable<T>(this Maybe<T> input) where T : struct => input.IsSome switch
        {
            true => input.Value,
            _ => null,
        };
    }

    /// <summary>
    /// Provides extensions for reference <see cref="Maybe{T}" />s.
    /// </summary>
    public static partial class MaybeReferenceExtensions
    {
        /// <summary>
        /// Convert the <see cref="Maybe{T}" /> to a Nullable value.
        /// </summary>
        /// <returns><see langword="null" /> if the <see cref="Maybe{T}" /> is None, the value otherwise.</returns>
        /// <FSharp>
        /// let toNullable option = match option with None -> System.Nullable() | Some v -> System.Nullable(v)
        /// // val toNullable :
        /// //  option:'a option -> System.Nullable{'a}
        /// //      when 'a : (new : unit -> 'a) and 'a : struct and 'a :> System.ValueType
        /// </FSharp>
        /// <Implementation>
        /// T? ToNullable{T}(Maybe{T} input) where T : class => input.IsSome switch
        /// {
        ///     true => input.Value,
        ///     _ => null,
        /// };
        /// </Implementation>
        public static T ToNullable<T>(this Maybe<T> input) where T : class => input.IsSome switch
        {
            true => input.Value,
            _ => null,
        };
    }
}
