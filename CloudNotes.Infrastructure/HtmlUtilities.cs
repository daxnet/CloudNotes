
namespace CloudNotes.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web;

    public static class HtmlUtilities
    {
        #region Private Static Fields
        private static readonly Regex Tags = new Regex(@"<[^>]+?>", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex NotOkCharacter = new Regex(@"[^\w;&#@.:/\\?=|%!() -]", RegexOptions.Compiled);
        #endregion

        public static string ReplaceFileSystemImages(string html)
        {
            var matches = Regex.Matches(
                html,
                @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>",
                RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                if (File.Exists(src))
                {
                    var ext = Path.GetExtension(src);
                    if (ext.Length > 0)
                    {
                        ext = ext.Substring(1);
                        src = string.Format(
                            "'data:image/{0};base64,{1}'",
                            ext,
                            Convert.ToBase64String(File.ReadAllBytes(src)));
                        html = html.Replace(match.Groups[1].Value, src);
                    }
                }
            }
            return html;
        }

        public static async Task<string> ReplaceWebImagesAsync(string html, Action<int, int> reportProgress = null)
        {
            var matches = Regex.Matches(
                   html,
                   @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>",
                   RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            var webClient = new WebClient();

            var i = 0;
            var count = matches.Count;
            foreach (Match match in matches)
            {
                if (reportProgress!=null)
                {
                    reportProgress(++i, count);
                }
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                try
                {
                    var fileName = Path.GetTempFileName();
                    await webClient.DownloadFileTaskAsync(new Uri(src), fileName);
                    var length = src.Length;
                    var pos = src.LastIndexOf('.');
                    src = string.Format(
                            "'data:image/{0};base64,{1}'",
                            src.Substring(pos + 1, length - pos - 1),
                            Convert.ToBase64String(File.ReadAllBytes(fileName)));
                    html = html.Replace(match.Groups[1].Value, src);
                }
                catch
                { }
            }
            return html;

        }

        /// <summary>
        /// Extract the description from the html.
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ExtractDescription(string html)
        {
            var plainText = RemoveHtmlTags(html);
            return plainText.Substring(0, plainText.Length < 100 ? plainText.Length : 100);
        }

        /// <summary>
        /// Extract the thumbnail image from the html.
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ExtractThumbnailImageBase64(string html)
        {
            var imageBase64List = GetImgSrcBase64FromHtml(html);
            string result = null;
            if (imageBase64List != null && imageBase64List.Any())
            {
                result = imageBase64List.First();
            }
            return result;
        }
       

        /// <summary>
        /// Removes all the HTML tags and bad characters from the given HTML string.
        /// </summary>
        /// <param name="html">The source HTML string.</param>
        /// <returns></returns>
        public static string RemoveHtmlTags(string html)
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

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetImgSrcBase64FromHtml(string html)
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
                if (pos == -1)
                    continue;
                pos += 7;
                result.Add(href.Substring(pos, href.Length - pos).Trim());
            }
            return result;
        }

        private static String RemoveTag(string html, string startTag, string endTag)
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
