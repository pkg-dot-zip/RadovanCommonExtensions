using System;
using System.Collections.Generic;
using System.Reflection;

namespace RadovanCommonExtensions.Extensions.Reflection
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Invokes the method with <paramref name="methodName"/> of <paramref name="type"/> on <paramref name="instance"/>. <br/>
        ///
        /// If the <paramref name="type"/> is <see langword="static"/> use <c>null!</c> for <paramref name="instance"/>.
        /// </summary>
        /// <param name="type">Type where the method <paramref name="methodName"/> is defined.</param>
        /// <param name="methodName">Name of the method to invoke. Use <see langword="nameof"/><c>(Method)</c> to avoid typos.</param>
        /// <param name="instance">Instance to invoke the method on. If the <paramref name="type"/> is <see langword="static"/> use <c>null!</c>.</param>
        /// <param name="parameters">Parameters to invoke the method with. Leave <c>null</c> if there are no parameters.</param>
        /// <returns></returns>
        public static object? InvokeType(this Type type, string methodName, object instance, object[]? parameters = null)
        {
            var methodToInvoke = type.GetMethod(methodName,
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                BindingFlags.NonPublic);

            if (methodToInvoke is null)
                throw new ArgumentException($"Method with name {methodName} in type {type.Name} does not exist.");
            return methodToInvoke.Invoke(instance, parameters);
        }


        /// <summary>
        /// Invokes the method with <paramref name="methodName"/> of <paramref name="type"/> on <paramref name="instance"/> using generic types <paramref name="genericTypes"/>. <br/>
        /// 
        /// If the <paramref name="type"/> is <see langword="static"/> use <c>null!</c> for <paramref name="instance"/>.
        /// </summary>
        /// <param name="type">Type where the method <paramref name="methodName"/> is defined.</param>
        /// <param name="methodName">Name of the method to invoke. Use <see langword="nameof"/><c>(Method)</c> to avoid typos.</param>
        /// <param name="genericTypes">The generic types to use. For <see cref="List{T}"/> this is &lt;T&gt;!</param>
        /// <param name="instance">Instance to invoke the method on. If the <paramref name="type"/> is <see langword="static"/> use <c>null!</c>.</param>
        /// <param name="parameters">Parameters to invoke the method with. Leave <c>null</c> if there are no parameters.</param>
        /// <returns></returns>
        public static object? InvokeTypeWithGenerics(this Type type, string methodName, Type[] genericTypes,
            object instance, object[]? parameters = null)
        {
            var methodToInvoke = type.GetMethod(methodName,
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                BindingFlags.NonPublic);

            if (methodToInvoke is null)
                throw new ArgumentException($"Method with name {methodName} in type {type.Name} does not exist.");
            return methodToInvoke.MakeGenericMethod(genericTypes).Invoke(instance, parameters);
        }
    }
}
