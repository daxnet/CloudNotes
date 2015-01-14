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

namespace CloudNotes.DesktopClient.Extensibility.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents that the inherited classes are data access proxies that
    /// can provide the data source to the desktop client.
    /// </summary>
    public abstract class DataAccessProxy : IDisposable
    {
        #region Private Fields
        private readonly ClientCredential credential;
        #endregion

        #region Cctor
        /// <summary>
        /// Finalizes an instance of the <see cref="DataAccessProxy"/> class.
        /// </summary>
        ~DataAccessProxy()
        {
            this.Dispose(false);
        }
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessProxy"/> class.
        /// </summary>
        /// <param name="credential">The client credential used for consuming the data access functionalities.</param>
        public DataAccessProxy(ClientCredential credential)
        {
            this.credential = credential;
        }
        #endregion

        #region Protected Properties
        /// <summary>
        /// Gets the client credential used for consuming the data access functionalities.
        /// </summary>
        protected ClientCredential Credential
        {
            get { return this.credential; }
        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected abstract void Dispose(bool disposing);
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the notes asynchronously.
        /// </summary>
        /// <param name="deleted">True if the method should return the notes that are marked as deleted. False will return all the
        /// notes available.</param>
        /// <returns>The <see cref="Task"/> that returns a list of retrieved notes.</returns>
        public abstract Task<IEnumerable<Note>> GetNotesAsync(bool deleted = false);
        /// <summary>
        /// Creates the note asynchronously.
        /// </summary>
        /// <param name="note">The note object to be created.</param>
        /// <returns>The <see cref="Task"/> that returns the <see cref="Guid"/> value which represents the ID of the note that is newly created.</returns>
        public abstract Task<Guid> CreateNoteAsync(Note note);
        /// <summary>
        /// Updates the note asynchronously.
        /// </summary>
        /// <param name="note">The note to be updated.</param>
        /// <returns>The <see cref="Task"/> that is responsible for updating the note.</returns>
        public abstract Task UpdateNoteAsync(Note note);
        /// <summary>
        /// Marks the note as deleted asynchronously.
        /// </summary>
        /// <param name="id">The ID of the note to be marked as deleted.</param>
        /// <returns>The <see cref="Task"/> that is responsible for marking the note as deleted.</returns>
        public abstract Task MarkDeleteAsync(Guid id);
        /// <summary>
        /// Deletes the note asynchronously.
        /// </summary>
        /// <param name="id">The ID of the note to be deleted.</param>
        /// <returns>The <see cref="Task"/> that is responsible for deleting the note.</returns>
        public abstract Task DeleteAsync(Guid id);
        /// <summary>
        /// Empties the trash bin asynchronously.
        /// </summary>
        /// <returns>The <see cref="Task"/> that is responsible for empty the trash bin.</returns>
        public abstract Task EmptyTrashAsync();
        /// <summary>
        /// Restores the note from the trash bin asynchronously.
        /// </summary>
        /// <param name="id">The ID of the note to be restored.</param>
        /// <returns>The <see cref="Task"/> that is responsible for restoring the note from the trash bin.</returns>
        public abstract Task RestoreAsync(Guid id);
        /// <summary>
        /// Gets the note asynchronously.
        /// </summary>
        /// <param name="id">The ID of the note to be retrieved.</param>
        /// <returns>The <see cref="Task"/> that returns the retrieved note.</returns>
        public abstract Task<Note> GetNoteAsync(Guid id);
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
