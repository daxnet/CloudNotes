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
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Apworks;

    /// <summary>
    ///     Represents the method extender.
    /// </summary>
    public static class MethodExtender
    {
        #region String Extender

        // ReSharper disable InconsistentNaming
        /// <summary>
        ///     Casts the specified source.
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
        ///     Determines whether the source string is a valid Base64 encoded value.
        /// </summary>
        /// <param name="s">The source string to be checked.</param>
        /// <returns>True if it is a valid Base64 encoded value, otherwise, false.</returns>
        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length%4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        /// <summary>
        ///     Opens the web browser and navigates to the given url.
        /// </summary>
        /// <param name="s">The web address on which the navigator should open.</param>
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