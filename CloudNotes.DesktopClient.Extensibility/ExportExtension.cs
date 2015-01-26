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

namespace CloudNotes.DesktopClient.Extensibility
{
    using CloudNotes.DesktopClient.Extensibility.Data;
    using CloudNotes.DesktopClient.Extensibility.Exceptions;
    using System.Windows.Forms;

    /// <summary>
    /// Represents that the derived classes are the extensions that are responsible for exporting
    /// the current note to a specific file format.
    /// </summary>
    public abstract class ExportExtension : Extension
    {
        #region Private Fields
        private string fileName;
        #endregion

        #region Protected Properties
        /// <summary>
        /// Gets the option dialog.
        /// </summary>
        /// <value>
        /// The option dialog.
        /// </value>
        protected virtual IExportOptionDialog OptionDialog
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Executes the current extension.
        /// </summary>
        /// <param name="shell">
        /// The <see cref="IShell"/> object on which the current extension will be executed.
        /// </param>
        /// <exception cref="ExportCancelledException">
        /// Throws when the <c>OptionDialog</c> is specified, but the dialog's returned result is
        /// <c>DialogResult.OK</c>
        /// </exception>
        protected override void DoExecute(IShell shell)
        {
            object options = null;
            if (this.OptionDialog != null)
            {
                var optionDialog = this.OptionDialog;
                var dialogResult = optionDialog.ShowDialog(shell.Owner);
                if (dialogResult == DialogResult.OK)
                {
                    options = optionDialog.Options;
                }
                else
                {
                    throw new ExportCancelledException();
                }
            }
            this.DoExport(this.fileName, shell.Note, options);
        }

        /// <summary>
        /// Performs the export.
        /// </summary>
        /// <param name="fileName">Name of the file to which the note will be exported.</param>
        /// <param name="note">The note that is being exported.</param>
        /// <param name="options">The options for the exporting.</param>
        /// <remarks>
        /// When the <c>OptionDialog</c> is not null, the <paramref name="options"/> value
        /// represents the options collected from the <c>OptionDialog</c>. Otherwise the options
        /// value will be null.
        /// </remarks>
        protected abstract void DoExport(string fileName, Note note, object options);
        #endregion

        #region Internal Methods
        /// <summary>
        /// Sets the name of the file that needs to be exported.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <remarks>
        /// This method will only be called in the CloudNotes Desktop Client main window, simply to
        /// specify the name of the file that needs to be exported. Once the file name has been
        /// specified, the <c>DoExecute</c> protected method will use this file name to save the
        /// note as another file format.
        /// </remarks>
        internal void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the file extension which represents the file format used for exporting.
        /// </summary>
        /// <value>Returns the file extension, e.g. *.txt, for text file.</value>
        /// <remarks>
        /// This value is the extension portion of the file filtering options available in the Save
        /// As dialog box.
        /// </remarks>
        public abstract string FileExtension { get; }
        /// <summary>
        /// Gets the file extension description which describes the file format used for exporting.
        /// </summary>
        /// <value>The file extension description, e.g. Text Files (*.txt), for text file.</value>
        /// <remarks>
        /// This value is the description portion of the file filtering options available in the
        /// Save As dialog box.
        /// </remarks>
        public abstract string FileExtensionDescription { get; }
        #endregion

    }
}
