//  =======================================================================================================
// 
//     ,uEZGZX  LG                             Eu       iJ       vi                                              
//    BB7.  .:  uM                             8F       0BN      Bq             S:                               
//   @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
//  ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
//  v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
//  .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//   @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//    ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//      iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
// 
// 
//  Copyright 2014-2015 daxnet
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  =======================================================================================================

namespace CloudNotes.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using HtmlAgilityPack;

    /// <summary>
    ///     Represents the static class that provides the utility methods for manipulating the HTML texts.
    /// </summary>
    public static class HtmlUtilities
    {
        #region Private Static Fields

        private static readonly Regex Tags = new Regex(@"<[^>]+?>", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex NotOkCharacter = new Regex(@"[^\w;&#@.:/\\?=|%!() -]", RegexOptions.Compiled);

        #endregion

        #region Private Static Methods

        /// <summary>
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetImgSrcBase64FromHtml(string html)
        {
            var matchesImgSrc = Regex.Matches(html, Constants.HtmlImgSrcFormatPattern,
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (matchesImgSrc.Count == 0)
                return null;
            var result = new List<string>();
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
            } while (bAgain);
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

        #region Public Static Methods

        /// <summary>
        ///     Extracts the document title from HTML.
        /// </summary>
        /// <param name="html">The HTML text from which the document title should be extracted.</param>
        /// <returns>HTML document title.</returns>
        public static string ExtractTitle(string html)
        {
            var m = Regex.Match(html, Constants.HtmlTitleFormatPattern);
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            return null;
        }

        /// <summary>
        ///     Replaces the images that refers to a file system image in HTML with the embedded Base64 image data.
        /// </summary>
        /// <param name="html">The HTML from which the images should be processed.</param>
        /// <returns>The HTML in which the images have been translated to the embedded Base64 image data.</returns>
        public static string ReplaceFileSystemImages(string html)
        {
            var matches = Regex.Matches(
                html,
                @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>",
                RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                var src = match.Groups[1].Value;
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

        /// <summary>
        ///     Replaces the images that refers to a images on the web in HTML with the embedded Base64 image data asynchronously.
        /// </summary>
        /// <param name="html">The HTML from which the images should be processed.</param>
        /// <param name="baseUri">
        ///     The host name of the remote server, with the Uri schema and port number, on which the image would
        ///     exist.
        /// </param>
        /// <param name="parentUri">The parent Uri.</param>
        /// <param name="token">The <see cref="CancellationToken" /> object which accepts a task cancel signal.</param>
        /// <param name="reportProgress">The action which reports the processing progress.</param>
        /// <returns>The HTML in which the images have been translated to the embedded Base64 image data.</returns>
        public static async Task<string> ReplaceWebImagesAsync(string html, string baseUri, string parentUri,
            CancellationToken token,
            Action<int, int> reportProgress = null)
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
                try
                {
                    token.ThrowIfCancellationRequested();

                    if (reportProgress != null)
                    {
                        reportProgress(++i, count);
                    }
                    var src = match.Groups[1].Value;
                    src = src.Trim('\"');
                    try
                    {
                        var fileName = Path.GetTempFileName();
                        if (!Uri.IsWellFormedUriString(src, UriKind.Absolute))
                        {
                            if (src.StartsWith("/"))
                            {
                                if (!string.IsNullOrEmpty(baseUri))
                                {
                                    src = string.Format("{0}/{1}", baseUri.TrimEnd('/'), src.TrimStart('/'));
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(parentUri))
                                {
                                    src = string.Format("{0}{1}", parentUri.EndsWith("/") ? parentUri : parentUri + "/",
                                        src);
                                }
                            }
                        }
                        await webClient.DownloadFileTaskAsync(new Uri(src), fileName);
                        Image.FromFile(fileName); // tries to resolve the image.
                        var length = src.Length;
                        var pos = src.LastIndexOf('.');
                        src = string.Format(
                            "'data:image/{0};base64,{1}'",
                            src.Substring(pos + 1, length - pos - 1),
                            Convert.ToBase64String(File.ReadAllBytes(fileName)));
                        html = html.Replace(match.Groups[1].Value, src);
                    }
                    catch
                    {
                    }
                }
                catch (OperationCanceledException)
                {
                    return null;
                }
            }
            return html;
        }

        /// <summary>
        ///     Extract the description from the HTML.
        /// </summary>
        /// <param name="html">The HTML from which the description will be extracted.</param>
        /// <returns>The description of the HTML.</returns>
        public static string ExtractDescription(string html)
        {
            var plainText = RemoveHtmlTags(html);
            return plainText.Substring(0, plainText.Length < 100 ? plainText.Length : 100);
        }

        /// <summary>
        ///     Extract the thumbnail image from the HTML.
        /// </summary>
        /// <param name="html">The HTML from which the thumbnail image will be extracted.</param>
        /// <returns>The Base64 string which represents the thumbnail image.</returns>
        public static string ExtractThumbnailBase64(string html)
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
        ///     Removes all the HTML tags and bad characters from the given HTML string.
        /// </summary>
        /// <param name="html">The source HTML string.</param>
        /// <returns>The plain text.</returns>
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

        public static string Tidy(string html, string path = "//body")
        {
            var doc = new HtmlDocument();
            doc.OptionFixNestedTags = true;
            // If you wish it to be xhtml like (does not suffice to 
            // enforce w3c xhtml validity).
            doc.OptionOutputAsXml = false;
            
            doc.LoadHtml(html);

            var body = doc.DocumentNode.SelectSingleNode(path);
            var cleanedHtml = (body != null)
                ? body.InnerHtml
                : doc.DocumentNode.InnerHtml;

            // cleanedHtml = HtmlEntity.DeEntitize(cleanedHtml);
            cleanedHtml = RemoveTag(cleanedHtml, "<!--", "-->");
            cleanedHtml = RemoveTag(cleanedHtml, "<script", "</script>");
            cleanedHtml = RemoveTag(cleanedHtml, "<style", "</style>");
            cleanedHtml = RemoveTag(cleanedHtml, "<form", "/>");
            cleanedHtml = RemoveTag(cleanedHtml, "<input", "/>");
            cleanedHtml = RemoveTag(cleanedHtml, "<form", "</form>");
            
            return cleanedHtml.Trim();
        }
        #endregion
    }
}