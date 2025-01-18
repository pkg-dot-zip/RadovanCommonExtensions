using System;
using System.Collections.Generic;

namespace RadovanCommonExtensions.Extensions.Reflection
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Invokes the method with <paramref name="methodName"/> on <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">Instance to invoke the method on.</param>
        /// <param name="methodName">Name of the method to invoke. Use <see langword="nameof"/><c>(Method)</c> to avoid typos.</param>
        /// <param name="parameters">Parameters to invoke the method with. Leave <c>null</c> if there are no parameters.</param>
        /// <returns></returns>
        public static object? InvokeObj(this object obj, string methodName, object[]? parameters = null)
        {
            return obj.GetType().InvokeType(methodName, obj, parameters);
        }

        /// <summary>
        /// Invokes the method with <paramref name="methodName"/> on <paramref name="obj"/> using generic types <paramref name="genericTypes"/>.
        /// </summary>
        /// <param name="obj">Instance to invoke the method on.</param>
        /// <param name="methodName">Name of the method to invoke. Use <see langword="nameof"/><c>(Method)</c> to avoid typos.</param>
        /// <param name="genericTypes">The generic types to use. For <see cref="List{T}"/> this is &lt;T&gt;!</param>
        /// <param name="parameters">Parameters to invoke the method with. Leave <c>null</c> if there are no parameters.</param>
        /// <returns></returns>
        public static object? InvokeObjWithGenerics(this object obj, string methodName, Type[] genericTypes, object[]? parameters = null)
        {
            return obj.GetType().InvokeTypeWithGenerics(methodName, genericTypes, obj, parameters);
        }
    }
}
