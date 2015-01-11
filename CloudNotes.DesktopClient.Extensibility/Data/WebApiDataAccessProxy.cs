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
    using DESecurity;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the data access proxy that consumes the CloudNotes Web API.
    /// </summary>
    internal sealed class WebApiDataAccessProxy : DataAccessProxy
    {
        #region Private Fields
        private readonly ServiceProxy serviceProxy;
        private readonly Crypto crypto = Crypto.CreateDefaultCrypto();
        #endregion

        #region Private Constants

        private const string RetrieveNotesODataQueryString = @"?$filter=(DeletedString ne 'Deleted') and (DeletedString ne 'MarkDeleted')&$orderby=DatePublished desc";
        private const string RetrieveMarkDeletedNotesODataQueryString = @"?$filter=(DeletedString eq 'MarkDeleted')&$orderby=DatePublished desc";
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiDataAccessProxy"/> class.
        /// </summary>
        /// <param name="credential">The client credential used for consuming the data access functionalities.</param>
        public WebApiDataAccessProxy(ClientCredential credential) : base(credential)
        {
            this.serviceProxy = new ServiceProxy(credential);
        }

        #endregion

        #region Overrides of DataAccessProxy

        public async override Task<IEnumerable<Note>> GetNotesAsync(bool deleted = false)
        {
            var uri = "api/notes/all";
            if (deleted)
            {
                uri += RetrieveMarkDeletedNotesODataQueryString;
            }
            else
            {
                uri += RetrieveNotesODataQueryString;
            }
            var result =
                await
                    this.serviceProxy.GetAsync(uri);
            result.EnsureSuccessStatusCode();
            dynamic noteItems = JsonConvert.DeserializeObject(await result.Content.ReadAsStringAsync());
            var notes = new List<Note>();
            foreach (dynamic note in noteItems)
            {
                string base64ImageString = null;
                var imageString = (string)note.ImageData;
                if (!string.IsNullOrEmpty(imageString))
                {
                    base64ImageString = this.crypto.Decrypt(imageString);
                }
                notes.Add(new Note
                {
                    ID = (Guid)note.ID,
                    Title = note.Title.ToString(),
                    Description = this.crypto.Decrypt(note.Description.ToString()),
                    ThumbnailImageBase64 = base64ImageString,
                    DatePublished = (DateTime)note.DatePublished,
                    DeletedFlag = (DeleteFlag)note.DeletedFlag
                });
            }
            return notes;
        }

        public override Task CreateNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public override Task MarkDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task EmptyTrashAsync()
        {
            throw new NotImplementedException();
        }

        public override Task RestoreAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<Note> GetNoteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.serviceProxy != null)
                {
                    this.serviceProxy.Dispose();
                }
            }
        }

        #endregion
    }
}
