using Apworks;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CloudNotes.Infrastructure
{
    /// <summary>
    /// Represents the method extender.
    /// </summary>
    public static class MethodExtender
    {
        #region String Extender
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// Casts the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="mapping">The mapping.</param>
        /// <returns></returns>
        public static PagedResult<U> CastPagedResult<T, U>(this PagedResult<T> source, Func<T, U> mapping)
            // ReSharper restore InconsistentNaming
        {
            return new PagedResult<U>(source.TotalRecords,
                source.TotalPages, source.PageSize, source.PageNumber,
                source.Data.Select(mapping).ToList());
        }

        /// <summary>
        /// Determines whether the source string is a valid Base64 encoded value.
        /// </summary>
        /// <param name="s">The source string to be checked.</param>
        /// <returns>True if it is a valid Base64 encoded value, otherwise, false.</returns>
        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }

        public static void Navigate(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                Process.Start(s);
            }
        }
        #endregion
    }
}
