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
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the option dialog for the Text File Export extension.
    /// </summary>
    public partial class TextFileExporterOptionDialog : Form, IExportOptionDialog
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileExporterOptionDialog"/> class.
        /// </summary>
        public TextFileExporterOptionDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the export options.
        /// </summary>
        /// <value>
        /// The export options.
        /// </value>
        public object Options
        {
            get { return cbEncoding.SelectedItem; }
        }
        #endregion

        #region Private Event Handlers
        private void TextFileExporterOptionDialog_Load(object sender, EventArgs e)
        {
            var encodingInforArray = Encoding.GetEncodings().OrderBy(p => p.DisplayName).ToList();
            cbEncoding.Items.Clear();
            cbEncoding.DisplayMember = "DisplayName";
            cbEncoding.ValueMember = "Name";
            cbEncoding.DataSource = encodingInforArray;
            cbEncoding.SelectedItem = encodingInforArray.First(enc => enc.CodePage == Encoding.UTF8.CodePage);
        }
        #endregion
    }
}
