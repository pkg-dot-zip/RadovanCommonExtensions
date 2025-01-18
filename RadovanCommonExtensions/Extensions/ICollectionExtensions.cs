using System.Collections.Generic;

namespace RadovanCommonExtensions.Extensions
{
    /// <summary>
    /// Contains extension methods for <seealso cref="ICollection{T}"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Returns <c>true</c> if this <see cref="ICollection{T}"/> contains no elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <see cref="ICollection{T}"/>.</typeparam>
        /// <param name="list">List to check <see cref="IsEmpty{T}"/> for.</param>
        /// <returns><c>True</c> if this list contains no elements. <c>False</c> if this list does contain any element.</returns>
        public static bool IsEmpty<T>(this ICollection<T> list) => list.Count == 0;

        /// <summary>
        /// Adds all of the <paramref name="elements"/> to the end of the <paramref name="collection"/>.
        /// Useful since <seealso cref="List{T}.AddRange"/> is only available in the implementation <seealso cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"><see langword="type"/> of <paramref name="elements"/>.</typeparam>
        /// <param name="collection">Collection to add the <paramref name="elements"/> to.</param>
        /// <param name="elements">Elements to add to <paramref name="collection"/>.</param>
        public static void AddAll<T>(this ICollection<T> collection, params T[] elements)
        {
            collection.AddAll(elements as IEnumerable<T>);
        }

        /// <summary>
        /// Adds all of the <paramref name="elements"/> to the end of the <paramref name="collection"/>.
        /// Useful since <seealso cref="List{T}.AddRange"/> is only available in the implementation <seealso cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"><see langword="type"/> of <paramref name="elements"/>.</typeparam>
        /// <param name="collection">Collection to add the <paramref name="elements"/> to.</param>
        /// <param name="elements">Elements to add to <paramref name="collection"/>.</param>
        public static void AddAll<T>(this ICollection<T> collection, IEnumerable<T> elements)
        {
            foreach (var element in elements) collection.Add(element);
        }
    }
}
