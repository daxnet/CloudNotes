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

namespace CloudNotes.DesktopClient.Installation
{
    using System.Collections;
    using System.ComponentModel;
    using System.Xml;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.Infrastructure;

    /// <summary>
    /// Represents and defines the custom action that will be executed during the
    /// CloudNotes Desktop Client installation.
    /// </summary>
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Installer"/> class.
        /// </summary>
        public Installer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When overridden in a derived class, performs the installation.
        /// </summary>
        /// <param name="stateSaver">An <see cref="T:System.Collections.IDictionary" /> used to save information needed to perform a commit, rollback, or uninstall operation.</param>
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            try
            {
                var configFile = Context.Parameters["assemblypath"] + ".config";
                var serverUrl = Context.Parameters["ServerUrl"];
                if (string.IsNullOrEmpty(serverUrl))
                {
                    serverUrl = "http://cloudnotes.cloudapp.net/webapi";
                }

                // -------- Change the App.Config file --------
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(configFile);
                XmlNode configuration = null;
                foreach (XmlNode node in xmlDocument.ChildNodes)
                    if (node.Name == "configuration")
                        configuration = node;

                if (configuration != null)
                {
                    // Get the 'appSettings' node
                    XmlNode settingNode = null;
                    foreach (XmlNode node in configuration.ChildNodes)
                        if (node.Name == "appSettings")
                            settingNode = node;

                    if (settingNode != null)
                    {
                        // Get the node with the attribute key="FilePath"
                        XmlNode numNode = null;
                        foreach (XmlNode node in settingNode.ChildNodes)
                        {
                            if (node.Attributes != null && node.Attributes["key"] != null)
                                if (node.Attributes["key"].Value == Constants.PackageServerSettingKey)
                                    numNode = node;
                        }

                        if (numNode != null && numNode.Attributes != null)
                        {
                            XmlAttribute att = numNode.Attributes["value"];
                            att.Value = serverUrl; // Update the configuration file

                            // Save the configuration file
                            xmlDocument.Save(configFile);
                        }
                    }
                }

                // -------- Change the cloudnotes.profile file --------
                var cloudNotesProfileFile = Directories.GetFullName(Constants.ProfileFileName);
                xmlDocument.Load(cloudNotesProfileFile);
                XmlNode profilesNode = null;
                foreach(XmlNode node in xmlDocument.ChildNodes)
                    if (node.Name == "profiles")
                        profilesNode = node;
                if (profilesNode != null)
                {
                    XmlNode serverProfilesNode = null;
                    foreach (XmlNode node in profilesNode.ChildNodes)
                        if (node.Name == "serverProfiles")
                            serverProfilesNode = node;
                    if (serverProfilesNode != null)
                    {
                        XmlNode serverProfileNode = null;
                        foreach(XmlNode node in serverProfilesNode.ChildNodes)
                            if (node.Name == "serverProfile")
                                serverProfileNode = node;
                        if (serverProfileNode != null)
                        {
                            XmlNode uriNode = null;
                            foreach(XmlNode node in serverProfileNode.ChildNodes)
                                if (node.Name == "Uri")
                                    uriNode = node;
                            if (uriNode != null)
                            {
                                uriNode.InnerText = serverUrl;
                                xmlDocument.Save(cloudNotesProfileFile);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
