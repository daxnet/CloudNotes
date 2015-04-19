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
    /// <summary>
    ///     Represents the constants used by the CloudNotes solution.
    /// </summary>
    public static class Constants
    {
        #region Constants for Application

        /// <summary>
        ///     The Email Address validation regular expression.
        /// </summary>
        public const string EmailAddressFormatPattern =
            @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

        /// <summary>
        ///     The regular expression for extracting the Src value from an HTML Img tag.
        /// </summary>
        public const string HtmlImgSrcFormatPattern = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

        /// <summary>
        ///     The HTML title format pattern.
        /// </summary>
        public const string HtmlTitleFormatPattern = @"<title>\s*(.+?)\s*</title>";

        /// <summary>
        ///     The key of the setting that represents the relative package location URI on the server file system. (server
        ///     setting).
        /// </summary>
        public const string PackageLocationUriSettingKey = "cloudnotes:PackageLocationUri";

        /// <summary>
        ///     The key of the setting that represents the URL of the server that provides the packages. (client setting).
        /// </summary>
        public const string PackageServerSettingKey = "cloudnotes:PackageServer";

        /// <summary>
        ///     The key of the setting that represents the local storage information.
        /// </summary>
        public const string LocalStorageSettingKey = "cloudnotes:LocalStorage";

        /// <summary>
        ///     The name of the Desktop Client settings file.
        /// </summary>
        public const string DesktopClientSettingsFile = "settings.json";

        /// <summary>
        ///     The name of the profile file used by the login provider.
        /// </summary>
        public const string ProfileFileName = "cloudnotes.profile";

        /// <summary>
        ///     The name of the folder for storing the extensions.
        /// </summary>
        public const string ExtensionFolderName = "Extensions";

        /// <summary>
        ///     The extension file search pattern.
        /// </summary>
        public const string ExtensionFileSearchPattern = "*.dll";

        #endregion
    }
}