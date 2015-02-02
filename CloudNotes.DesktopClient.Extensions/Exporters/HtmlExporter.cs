// =======================================================================================================
//
//    ,uEZGZX  LG                             Eu       iJ       vi                                              
//   BB7.  .:  uM                             8F       0BN      Bq             S:                               
//  @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
// ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
// v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
// .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//  @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//   ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//     iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
//
//
// Copyright 2014-2015 daxnet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =======================================================================================================

namespace CloudNotes.DesktopClient.Extensions.Exporters
{
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensibility.Data;
    using CloudNotes.DesktopClient.Extensions.Properties;
    using CloudNotes.Infrastructure;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Represents the extension that exports the current note to an external HTML file.
    /// </summary>
    [Extension("62E24485-80EF-4D03-9DE7-8140071AE7B3", "HtmlExporter")]
    public sealed class HtmlExporter : ExportExtension
    {
        #region Protected Methods

        /// <summary>
        /// Performs the export.
        /// </summary>
        /// <param name="fileName">Name of the file to which the note will be exported.</param>
        /// <param name="note">The note that is being exported.</param>
        /// <param name="options">The options for the exporting.</param>
        /// <remarks>
        /// When the <c>OptionDialog</c> is not null, the <paramref name="options" /> value
        /// represents the options collected from the <c>OptionDialog</c>. Otherwise the options
        /// value will be null.
        /// </remarks>
        protected override void DoExport(string fileName, Note note, object options)
        {
            var content = HtmlUtilities.ReplaceFileSystemImages(note.Content);
            File.WriteAllText(fileName, content, Encoding.UTF8);
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the file extension which represents the file format used for exporting.
        /// </summary>
        /// <value>
        /// Returns the file extension, e.g. *.txt, for text file.
        /// </value>
        /// <remarks>
        /// This value is the extension portion of the file filtering options available in the Save
        /// As dialog box.
        /// </remarks>
        public override string FileExtension
        {
            get { return "*.html"; }
        }

        /// <summary>
        /// Gets the file extension description which describes the file format used for exporting.
        /// </summary>
        /// <value>
        /// The file extension description, e.g. Text Files (*.txt), for text file.
        /// </value>
        /// <remarks>
        /// This value is the description portion of the file filtering options available in the
        /// Save As dialog box.
        /// </remarks>
        public override string FileExtensionDescription
        {
            get { return Resources.HtmlFileFilterDescription; }
        }

        /// <summary>
        /// Gets the manufacture of the extension.
        /// </summary>
        /// <value>
        /// The manufacture of the extension.
        /// </value>
        public override string Manufacture
        {
            get { return "daxnet"; }
        }

        /// <summary>
        /// Gets the display name of the extension.
        /// </summary>
        /// <value>
        /// The display name of the extension.
        /// </value>
        public override string DisplayName
        {
            get { return Resources.HtmlExporterDisplayName; }
        }

        /// <summary>
        /// Gets the description of the extension.
        /// </summary>
        /// <value>
        /// The description of the extension.
        /// </value>
        public override string Description
        {
            get { return Resources.HtmlExporterDescription; }
        }
        #endregion

    }
}
