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
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Controls;
    using CloudNotes.DesktopClient.Extensibility.Extensions;
    using CloudNotes.DesktopClient.Properties;
    using CloudNotes.Infrastructure;

    internal sealed partial class FrmAbout : Form
    {
        private readonly ExtensionManager extensionManager;

        internal FrmAbout(ExtensionManager extensionManager)
        {
            this.InitializeComponent();
            this.extensionManager = extensionManager;
        }

        private void ExecuteLink(string url)
        {
            Process.Start(url);
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            this.lblTitle.Text = string.Format(
                "{0} version {1}",
                this.GetType().Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title,
                this.GetType().Assembly.GetName().Version);
            this.txtLicense.Text = Resources.License;
            foreach (var assemblyName in this.GetType().Assembly.GetReferencedAssemblies())
            {
                this.lstAssemblies.Items.Add(
                    new ListViewItem(
                        new[] {assemblyName.Name, assemblyName.Version.ToString(), assemblyName.FullName},
                        "Assembly.png"));
            }

            if (this.extensionManager.HasResource)
            {
                this.lstExtensions.Visible = true;
                this.lstExtensions.Groups.Clear();
                var grpToolExtension = this.lstExtensions.Groups.Add("grpToolExtension",
                    Resources.ToolExtensionGroupName);
                var grpExportExtension = this.lstExtensions.Groups.Add("grpExportExtension",
                    Resources.ExportExtensionGroupName);

                this.ilExtensions.Images.Clear();
                this.ilExtensions.Images.Add("plugin.png", Resources.plugin);
                // Displays all the extensions.
                foreach (var kvp in this.extensionManager.AllExtensions)
                {
                    var extension = kvp.Value;
                    var lvi =
                        new ListViewItem(new[]
                        {
                            extension.DisplayName.Trim('.'), extension.Version.ToString(), extension.Manufacture,
                            extension.Description
                        });
                    if (extension.Kind == typeof (ToolExtension))
                    {
                        lvi.Group = grpToolExtension;
                        this.ilExtensions.Images.Add(extension.ID.ToString(), ((ToolExtension) extension).ToolIcon);
                        lvi.ImageKey = extension.ID.ToString();
                    }
                    else if (extension.Kind == typeof (ExportExtension))
                    {
                        lvi.Group = grpExportExtension;
                        lvi.ImageKey = "plugin.png";
                    }
                    this.lstExtensions.Items.Add(lvi);
                }
            }
            else
            {
                this.lstExtensions.Visible = false;
                var noExtensionControl = new NoExtensionControl {Dock = DockStyle.Fill};
                this.tpExtensions.Controls.Add(noExtensionControl);
            }
        }

        private void lblAuthorName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
            {
                "http://mvp.microsoft.com/zh-cn/mvp/Qingyang%20Chen-4038146".Navigate();
            }
            else
            {
                "http://mvp.microsoft.com/en-us/mvp/Qingyang%20Chen-4038146".Navigate();
            }
        }

        private void lblBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
            {
                "http://daxnet.cnblogs.com".Navigate();
            }
            else
            {
                "http://daxnetsvr.cloudapp.net/schen".Navigate();
            }
        }

        private void lblDonateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            "http://www.alipay.com".Navigate();
        }
    }
}