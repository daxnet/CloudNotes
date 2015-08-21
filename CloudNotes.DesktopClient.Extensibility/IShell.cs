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
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Represents that the implemented classes are CloudNotes Desktop Client shells.
    /// </summary>
    public interface IShell
    {
        /// <summary>
        /// Gets the text of the current shell.
        /// </summary>
        /// <value>The text of the current shell.</value>
        /// <remarks>Usually this is the text of the CloudNotes Desktop Client main form.</remarks>
        string Text { get; }
        /// <summary>
        /// Returns the <see cref="Task"/> object on which the note importing is being executed.
        /// </summary>
        /// <param name="note">The note that is going to be imported.</param>
        /// <param name="rethrow">Specifies whether the exceptions related to the application should be thrown
        /// to the upper level.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> object which executes the importing of the specified <see cref="Note"/>.
        /// </returns>
        /// <exception cref="CloudNotes.DesktopClient.Extensibility.Exceptions.NoteAlreadyExistsException">
        /// Throws when there is already a note that has the same title as the note being imported.
        /// </exception>
        Task ImportNote(Note note, bool rethrow = false);
        /// <summary>
        /// Gets the currently selected note in the shell.
        /// </summary>
        /// <value>
        /// The note that is currently selected.
        /// </value>
        Note Note { get; }
        /// <summary>
        /// Gets the owner value, usually it refers to the current instance of CloudNotes Desktop
        /// Client main form.
        /// </summary>
        /// <value>The owner.</value>
        IWin32Window Owner { get; }
        /// <summary>
        /// Gets the title of all the existing notes for current user.
        /// </summary>
        /// <value>
        /// The title of all the existing notes.
        /// </value>
        IEnumerable<string> ExistingNotesTitle { get; }

        /// <summary>
        /// Inserts the HTML to the currently opened document.
        /// </summary>
        /// <param name="html">The HTML to be inserted.</param>
        void InsertHtml(string html);

        /// <summary>
        /// Gets a <see cref="System.Boolean"/> value which indicating whether the current shell has an active document.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current shell has an active document; otherwise, <c>false</c>.
        /// </value>
        bool HasActiveDocument { get; }

        /// <summary>
        /// Gets or sets the status text.
        /// </summary>
        /// <value>
        /// The status text.
        /// </value>
        string StatusText { get; set; }
    }
}
