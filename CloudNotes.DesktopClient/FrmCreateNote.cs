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

namespace CloudNotes.DesktopClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility.Styling;
    using CloudNotes.DesktopClient.Settings;
    using CloudNotes.DesktopClient.Properties;

    internal partial class FrmCreateNote : Form
    {
        private readonly string prompt;
        private readonly StyleManager styleManager;
        private readonly DesktopClientSettings settings;
        private readonly List<Tuple<Func<string, bool>, string>> validations = new List<Tuple<Func<string, bool>, string>>();

        private FrmCreateNote()
        {
            InitializeComponent();
        }

        internal FrmCreateNote(string prompt, StyleManager styleManager, DesktopClientSettings settings, IEnumerable<Tuple<Func<string, bool>, string>> validations = null)
            : this()
        {
            this.prompt = prompt;
            this.styleManager = styleManager;
            this.settings = settings;
            if (validations != null)
            {
                this.validations.AddRange(validations);
            }
        }

        private void InitializeStyles()
        {
            this.cbStyle.Items.Clear();
            if (this.styleManager.HasResource)
            {
                foreach (var kvp in this.styleManager.Styles)
                {
                    var style = kvp.Value;
                    cbStyle.Items.Add(style);
                }
                var defaultStyleId = this.settings.Composing.DefaultStyleId;
                if (defaultStyleId != Guid.Empty)
                {
                    var style = styleManager.Styles.FirstOrDefault(s => s.Key == defaultStyleId).Value;
                    cbStyle.SelectedItem = style;
                    //BindStyle(style);
                }
            }
        }

        private void BindStyle(Style style)
        {
            wbStylePreview.DocumentText = style != null ? Resources.HtmlPreviewTemplate.Replace("$style$", style.Content) : string.Empty;
        }

        internal string SelectedTitle
        {
            get { return txtTitle.Text; }
        }

        internal string SelectedEmptyHtml
        {
            get
            {
                var style = this.cbStyle.SelectedItem as Style;
                if (style != null)
                {
                    return Resources.HtmlEmptyTemplate.Replace("$style$", style.Content);
                }
                return string.Empty;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.validations.Count > 0)
            {
                errorProvider.Clear();
                foreach (var validation in this.validations)
                {
                    if (validation.Item1(this.txtTitle.Text))
                    {
                        errorProvider.SetError(this.txtTitle, validation.Item2);
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
        }

        private void txtTitle_Enter(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void FrmCreateNote_Load(object sender, EventArgs e)
        {
            this.lblTitle.Text = this.prompt;
            this.txtTitle.Text = string.Empty;
            this.InitializeStyles();
            this.txtTitle.Focus();
        }

        private void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindStyle((Style)cbStyle.SelectedItem);
        }
    }
}
