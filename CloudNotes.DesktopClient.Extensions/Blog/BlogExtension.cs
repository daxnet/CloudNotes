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

namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensibility.Extensions;
    using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp;
    using CloudNotes.DesktopClient.Extensions.Properties;
    using CloudNotes.Infrastructure;

    /// <summary>
    /// Represents the extension that can publish the current note to the web log.
    /// </summary>
    [Extension("321945D2-9CF8-40A7-B794-323A27CF8900", "Blog", typeof(BlogSettingProvider))]
    public class BlogExtension : ToolExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogExtension"/> class.
        /// </summary>
        public BlogExtension()
            : base(Resources.BlogExtensionToolName)
        {
        }

        /// <summary>
        /// Executes the current extension.
        /// </summary>
        /// <param name="shell">The <see cref="IShell" /> object on which the current extension will be executed.</param>
        protected async override void DoExecute(IShell shell)
        {
            if (shell.HasActiveDocument)
            {
                await SafeExecutionContext.ExecuteAsync((Form) shell.Owner, async () =>
                {
                    var blogSetting = this.SettingProvider.GetExtensionSetting<BlogSetting>();
                    if (string.IsNullOrEmpty(blogSetting.MetaWeblogAddress) ||
                        string.IsNullOrEmpty(blogSetting.UserName) ||
                        string.IsNullOrEmpty(blogSetting.Password))
                    {
                        MessageBox.Show(Resources.MissingBlogConfigurationMsg, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var gateway = new BlogGateway(blogSetting.MetaWeblogAddress, blogSetting.UserName,
                        blogSetting.Password);
                    if (await gateway.TestConnectionAsync())
                    {
                        var blogPublishDialog = new FrmBlogPublish(gateway);
                        if (blogPublishDialog.ShowDialog() == DialogResult.OK)
                        {
                            var selectedCategories = blogPublishDialog.SelectedCategories.Select(s => s.Title).ToList();
                            var postInfo = new PostInfo
                            {
                                Categories = selectedCategories,
                                DateCreated = DateTime.Now,
                                Description =
                                    HtmlUtilities.Tidy(HtmlUtilities.ReplaceFileSystemImages(shell.Note.Content)),
                                Title = shell.Note.Title
                            };
                            await gateway.PublishBlog(postInfo, selectedCategories);
                            shell.StatusText = Resources.PublishSucceeded;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Resources.BlogExtensionCannotConnectToBlogService, Resources.Error,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                });
            }
            else
            {
                MessageBox.Show(Resources.NoActiveNoteOpened, Resources.Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public override string Manufacture
        {
            get { return Resources.ManufactureName; }
        }

        public override Shortcut Shortcut
        {
            get { return Shortcut.CtrlShiftP; }
        }

        public override string Description
        {
            get { return Resources.BlogExtensionDescription; }
        }

        public override Image ToolIcon
        {
            get { return Resources.blog_icon; }
        }
    }
}
