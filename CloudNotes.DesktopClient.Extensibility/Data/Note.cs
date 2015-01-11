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

    /// <summary>
    /// Represents the object that contains the <c>Note</c> data for client processing.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Gets or sets the ID of the note.
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// Gets or sets the title of the note.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the short description of the note.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the HTML content of the note.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the BASE64 encoded string of the thumbnail image.
        /// </summary>
        public string ThumbnailImageBase64 { get; set; }
        /// <summary>
        /// Gets or sets the date on which the note was published.
        /// </summary>
        public DateTime DatePublished { get; set; }
        /// <summary>
        /// Gets or sets the date on which the note was modified last time.
        /// </summary>
        public DateTime? DateLastModified { get; set; }
        /// <summary>
        /// Gets or sets the <c>DeleteFlag</c> which indicates the note deletion state.
        /// </summary>
        public DeleteFlag DeletedFlag { get; set; }

        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return this.Title;
        }

        #endregion
    }
}
