using Apworks;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace CloudNotes.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the method extender.
    /// </summary>
    public static class MethodExtender
    {
        #region Private Static Fields
        private static readonly Regex Tags = new Regex(@"<[^>]+?>", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex NotOkCharacter = new Regex(@"[^\w;&#@.:/\\?=|%!() -]", RegexOptions.Compiled);
        #endregion

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

        /// <summary>
        /// Opens the web browser and navigates to the given url.
        /// </summary>
        /// <param name="s">The web address on which the navigator should open.</param>
        public static void Navigate(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                Process.Start(s);
            }
        }

        /// <summary>
        /// Removes all the HTML tags and bad characters from the given HTML string.
        /// </summary>
        /// <param name="html">The source HTML string.</param>
        /// <returns></returns>
        public static string RemoveHtmlTags(this string html)
        {
            html = HttpUtility.UrlDecode(html);
            html = HttpUtility.HtmlDecode(html);

            html = RemoveTag(html, "<!--", "-->");
            html = RemoveTag(html, "<script", "</script>");
            html = RemoveTag(html, "<style", "</style>");

            //replace matches of these regexes with space
            html = Tags.Replace(html, " ");
            html = NotOkCharacter.Replace(html, " ");
            html = SingleSpacedTrim(html);

            return html;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetImgSrcBase64FromHtml(this string html)
        {
            var matchesImgSrc = Regex.Matches(html, Constants.ImgSrcFormatPattern,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matchesImgSrc.Count == 0)
                return null;
            List<string> result = new List<string>();
            foreach (Match m in matchesImgSrc)
            {
                var href = m.Groups[1].Value;
                var pos = href.IndexOf("base64,", StringComparison.InvariantCultureIgnoreCase);
                pos += 7;
                result.Add(href.Substring(pos, href.Length - pos).Trim());
            }
            return result;
        } 
        #endregion

        #region Private Static Methods
        private static String RemoveTag(String html, String startTag, String endTag)
        {
            bool bAgain;
            do
            {
                bAgain = false;
                var startTagPos = html.IndexOf(startTag, 0, StringComparison.CurrentCultureIgnoreCase);
                if (startTagPos < 0) continue;
                var endTagPos = html.IndexOf(endTag, startTagPos + 1, StringComparison.CurrentCultureIgnoreCase);
                if (endTagPos <= startTagPos) continue;
                html = html.Remove(startTagPos, endTagPos - startTagPos + endTag.Length);
                bAgain = true;
            }
            while (bAgain);
            return html;
        }

        private static String SingleSpacedTrim(String inString)
        {
            var sb = new StringBuilder();
            var inBlanks = false;
            foreach (var c in inString)
            {
                switch (c)
                {
                    case '\r':
                    case '\n':
                    case '\t':
                    case ' ':
                        if (!inBlanks)
                        {
                            inBlanks = true;
                            sb.Append(' ');
                        }
                        continue;
                    default:
                        inBlanks = false;
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString().Trim();
        }
        #endregion
    }
}
