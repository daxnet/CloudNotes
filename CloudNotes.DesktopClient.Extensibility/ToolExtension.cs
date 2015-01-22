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
    using CloudNotes.DesktopClient.Extensibility.Properties;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Represents that the derived classes are the extensions that will be registered
    /// as a tool in CloudNotes Desktop Client.
    /// </summary>
    public abstract class ToolExtension : Extension
    {
        #region Private Fields
        private readonly string toolName;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolExtension"/> class.
        /// </summary>
        /// <param name="toolName">Name of the tool.</param>
        public ToolExtension(string toolName)
        {
            this.toolName = toolName;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <value>
        /// The name of the tool.
        /// </value>
        public string ToolName
        {
            get { return this.toolName; }
        }

        /// <summary>
        /// Gets the tool icon that will appear on the menu or toolbar.
        /// </summary>
        /// <value>
        /// The tool icon.
        /// </value>
        public virtual Image ToolIcon
        {
            get
            {
                return Resources.Plugin;
            }
        }

        /// <summary>
        /// Gets the tool tip.
        /// </summary>
        /// <value>
        /// The tool tip.
        /// </value>
        public virtual string ToolTip
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the shortcut.
        /// </summary>
        /// <value>
        /// The shortcut.
        /// </value>
        public virtual Shortcut Shortcut
        {
            get
            {
                return Shortcut.None;
            }
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Gets the display name of the extension.
        /// </summary>
        /// <value>
        /// The display name of the extension.
        /// </value>
        public override string DisplayName
        {
            get { return this.ToolName; }
        }
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.toolName;
        }
        #endregion
    }
}
