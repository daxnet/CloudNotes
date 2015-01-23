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
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Settings;
    using Microsoft.VisualBasic.ApplicationServices;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the class for controlling the application on a single running instance.
    /// </summary>
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleInstanceController"/> class.
        /// </summary>
        public SingleInstanceController()
        {
            // Set whether the application is single instance
            this.IsSingleInstance = true;
            this.StartupNextInstance += this.this_StartupNextInstance;
        }

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            // Here you get the control when any other instance is
            // invoked apart from the first one.
            // You have args here in e.CommandLine.

            // You custom code which should be run on other instances
            if (MainForm != null && MainForm is FrmMain)
            {
                (MainForm as FrmMain).WindowState = FormWindowState.Normal;
                (MainForm as FrmMain).Show();
            }
        }

        /// <summary>
        /// When overridden in a derived class, allows a designer to emit code that configures the splash screen and main form.
        /// </summary>
        protected override void OnCreateMainForm()
        {
            var extensionManager = new ExtensionManager();
            var settings = DesktopClientSettings.ReadSettings();
            var loadExtensionTask = Task.Factory.StartNew(() => 
            {
                // As the extensions are loaded in another thread, setting that thread's ui culture
                // to the one read from the setting preference.
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.General.Language);
                extensionManager.Load(); 
            });

            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.General.Language);

            var credential = LoginProvider.Login(Application.Exit, settings);
            if (credential != null)
            {
                Task.WaitAll(loadExtensionTask);
                // Instantiate your main application form
                this.MainForm = new FrmMain(credential, settings, extensionManager);
            }
        }
    }
}
