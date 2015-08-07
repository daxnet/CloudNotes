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

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensibility.Data;
    using CloudNotes.DesktopClient.Extensions.Properties;
    using CloudNotes.Infrastructure;

    /// <summary>
    ///     Represents the extension that will import the note from the web.
    /// </summary>
    [Extension("D3C4C8BB-38E0-4EEE-9263-C83F3F4C39E0", "ImportFromWeb", typeof (ImportFromWebSettingProvider))]
    public sealed class ImportFromWebExtension : ToolExtension
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImportFromWebExtension" /> class.
        /// </summary>
        public ImportFromWebExtension()
            : base(Resources.ImportFromWeb)
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        ///     Executes the current extension.
        /// </summary>
        /// <param name="shell">The <see cref="IShell" /> object on which the current extension will be executed.</param>
        protected override async void DoExecute(IShell shell)
        {
            try
            {
                var setting = this.SettingProvider.GetExtensionSetting<ImportFromWebSetting>();
                var dialog = new ImportFromWebDialog(setting);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var title = HtmlUtilities.ExtractTitle(dialog.HtmlContent);
                    if (string.IsNullOrEmpty(title) || shell.ExistingNotesTitle.Contains(title))
                    {
                        var titleInputDialog = new TextInputBox(Resources.ImportFromWebInputTitleText,
                            Resources.ImportFromWebInputTitlePrompt, title,
                            new[]
                            {
                                new Tuple<Func<string, bool>, string>(string.IsNullOrEmpty,
                                    Resources.ImportFromWebEmptyTitleErrorMsg),
                                new Tuple<Func<string, bool>, string>(shell.ExistingNotesTitle.Contains,
                                    Resources.ImportFromWebDuplicatedTitleErrorMsg)
                            });
                        if (titleInputDialog.ShowDialog() == DialogResult.OK)
                        {
                            title = titleInputDialog.InputText;
                        }
                        else
                        {
                            return;
                        }
                    }
                    await shell.ImportNote(new Note
                    {
                        Title = title,
                        Content = dialog.HtmlContent
                    });
                }
            }
            catch (Exception ex)
            {
                FrmExceptionDialog.ShowException(ex);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the tool icon that will appear on the menu or toolbar.
        /// </summary>
        /// <value>
        ///     The tool icon.
        /// </value>
        public override Image ToolIcon
        {
            get { return Resources.ImportFromWebImage; }
        }

        /// <summary>
        ///     Gets the manufacture of the extension.
        /// </summary>
        /// <value>
        ///     The manufacture of the extension.
        /// </value>
        public override string Manufacture
        {
            get { return "daxnet"; }
        }

        /// <summary>
        ///     Gets the description of the extension.
        /// </summary>
        /// <value>
        ///     The description of the extension.
        /// </value>
        public override string Description
        {
            get { return Resources.ImportFromWebDescription; }
        }

        #endregion
    }
}