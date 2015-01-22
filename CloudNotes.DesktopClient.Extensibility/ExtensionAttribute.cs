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
    using System;

    /// <summary>
    /// Represents that the decorated classes are CloudNotes Desktop Client extensions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
    public sealed class ExtensionAttribute : Attribute
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionAttribute"/> class.
        /// </summary>
        /// <param name="id">The identifier of the extension.</param>
        /// <param name="name">The name of the extension.</param>
        public ExtensionAttribute(string id, string name)
        {
            this.ID = new Guid(id);
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionAttribute"/> class.
        /// </summary>
        /// <param name="id">The identifier of the extension.</param>
        /// <param name="name">The name of the extension.</param>
        /// <param name="settingProviderType">Type of the extension setting provider.</param>
        public ExtensionAttribute(string id, string name, Type settingProviderType)
            : this(id, name)
        {
            this.SettingProviderType = settingProviderType;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the identifier of the extension.
        /// </summary>
        /// <value>
        /// The identifier of the extension.
        /// </value>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the extension.
        /// </summary>
        /// <value>
        /// The name of the extension.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the extension setting provider.
        /// </summary>
        /// <value>
        /// The type of the extension setting provider.
        /// </value>
        public Type SettingProviderType { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ID.ToString();
        }
        #endregion
    }
}
