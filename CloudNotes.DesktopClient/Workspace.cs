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

namespace CloudNotes.DesktopClient
{
    using System;
    using System.ComponentModel;
    using CloudNotes.DesktopClient.Extensibility.Data;
    using CloudNotes.DESecurity;

    /// <summary>
    ///     Represents the workspace initialized with a note object.
    /// </summary>
    public class Workspace : INotifyPropertyChanged
    {
        private readonly Crypto crypto = Crypto.CreateDefaultCrypto();
        private Guid id;

        private string title;

        private string content;

        private bool isSaved;

        private DateTime datePublished;

        public Workspace(Note note)
        {
            id = note.ID;
            title = note.Title;
            var encryptedContent = note.Content;
            this.content = string.IsNullOrEmpty(encryptedContent) ? string.Empty : this.crypto.Decrypt(encryptedContent);
            datePublished = note.DatePublished;
            isSaved = true;
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid ID
        {
            get { return id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title
        {
            get { return title; }
            set
            {
                if (title == value)
                {
                    return;
                }
                title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        /// <value>
        ///     The content.
        /// </value>
        public string Content
        {
            get { return content; }
            set
            {
                if (this.content == value)
                {
                    return;
                }
                this.isSaved = false;
                this.content = value;
                this.OnPropertyChanged("Content");
            }
        }

        public bool IsSaved
        {
            get { return isSaved; }
            set
            {
                if (isSaved == value)
                {
                    return;
                }
                isSaved = value;
                OnPropertyChanged("IsSaved");
            }
        }

        public DateTime DatePublished
        {
            get { return datePublished; }
            set
            {
                if (datePublished == value)
                {
                    return;
                }
                datePublished = value;
                OnPropertyChanged("DatePublished");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var evnt = PropertyChanged;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}