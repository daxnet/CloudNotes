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
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the text input dialog box.
    /// </summary>
    public partial class TextInputBox : Form
    {
        #region Private Fields

        private readonly string title;
        private readonly string prompt;
        private readonly string initValue;
        private readonly List<Tuple<Func<string, bool>, string>> validations = new List<Tuple<Func<string, bool>, string>>();
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="TextInputBox"/> class.
        /// </summary>
        public TextInputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextInputBox"/> class.
        /// </summary>
        /// <param name="title">The title of the text input dialog.</param>
        /// <param name="prompt">The prompt message to be shown on the text input dialog box.</param>
        /// <param name="validations">The validation collection which contains the delegates for the validation methods,
        /// and also the error message to be shown when the validation fails.</param>
        public TextInputBox(string title, string prompt, IEnumerable<Tuple<Func<string, bool>, string>> validations = null)
            : this(title, prompt, null, validations)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextInputBox"/> class.
        /// </summary>
        /// <param name="title">The title of the text input dialog.</param>
        /// <param name="prompt">The prompt message to be shown on the text input dialog box.</param>
        /// <param name="initValue">The initial value to be shown on the text input dialog box.</param>
        /// <param name="validations">The validation collection which contains the delegates for the validation methods,
        /// and also the error message to be shown when the validation fails.</param>
        public TextInputBox(string title, string prompt, string initValue, IEnumerable<Tuple<Func<string, bool>, string>> validations = null)
            : this()
        {
            this.title = title;
            this.prompt = prompt;
            this.initValue = initValue;
            if (validations != null)
            {
                this.validations.AddRange(validations);
            }
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the input text.
        /// </summary>
        /// <value>
        /// The input text.
        /// </value>
        public string InputText
        {
            get { return this.txtInput.Text; }
        }
        #endregion

        #region Private Event Handlers
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.validations.Count > 0)
            {
                errorProvider.Clear();
                foreach (var validation in this.validations)
                {
                    if (validation.Item1(this.txtInput.Text))
                    {
                        errorProvider.SetError(this.txtInput, validation.Item2);
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                }
            }
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
        }

        private void TextInputBox_Load(object sender, EventArgs e)
        {
            this.Text = this.title;
            this.lblPrompt.Text = this.prompt;
            this.txtInput.Text = this.initValue;
            this.txtInput.Focus();
        }
        #endregion
    }
}
