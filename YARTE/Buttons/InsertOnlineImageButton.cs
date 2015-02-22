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

namespace YARTE.Buttons
{
    using System.Drawing;
    using System.Windows.Forms;
    using YARTE.Properties;
    using YARTE.UI.Buttons;

    /// <summary>
    ///     Represents the tool button that inserts an online image to the current cursor
    ///     position of the document.
    /// </summary>
    public sealed class InsertOnlineImageButton : IHTMLEditorButton
    {
        #region Private Constatns

        private const string EmbeddedImageHtmlTagPattern = "<img src=\"data:image/png;base64,{0}\" alt=\"{1}\" />";

        #endregion

        #region Public Methods 

        /// <summary>
        ///     Invoked once the Insert Online Image button has been clicked.
        /// </summary>
        /// <param name="doc"><see cref="HTMLEditorButtonArgs" /> instance that contains the context information.</param>
        public void IconClicked(HTMLEditorButtonArgs doc)
        {
            var dialog = new FrmInsertOnlineImage();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var tag = string.Format(EmbeddedImageHtmlTagPattern, dialog.ImageBase64, dialog.Alt);
                var insertHtmlButton = new InsertHtmlButton(tag);
                insertHtmlButton.IconClicked(doc);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the icon image.
        /// </summary>
        /// <value>
        ///     The icon image.
        /// </value>
        public Image IconImage
        {
            get { return Resources.image_from_web; }
        }

        /// <summary>
        ///     Gets the name of the icon.
        /// </summary>
        /// <value>
        ///     The name of the icon.
        /// </value>
        public string IconName
        {
            get { return "Insert Online Image"; }
        }

        /// <summary>
        ///     Gets the icon tooltip.
        /// </summary>
        /// <value>
        ///     The icon tooltip.
        /// </value>
        public string IconTooltip
        {
            get { return Resources.InsertOnlineImageToolTip; }
        }

        /// <summary>
        ///     This is the string that will be used to poll the text area to determine if the cursor
        ///     is in a given area (say, 'Bold') and show the corresponding button as selected
        ///     Leave blank if there is no command or you have no idea what to put here
        /// </summary>
        public string CommandIdentifier
        {
            get { return "InsertOnlineImage"; }
        }

        #endregion
    }
}
