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
    using System;

    /// <summary>
    /// Represents the base class for CloudNotes Desktop Client extensions.
    /// </summary>
    public abstract class Extension
    {
        #region Private Fields
        private ExtensionSettingProvider settingProvider;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Extension"/> class.
        /// </summary>
        protected Extension()
        {
            
        }
        #endregion

        #region Private Properties
        private ExtensionAttribute ExtensionAttribute
        {
            get
            {
                var thisType = this.GetType();
                if (thisType.IsDefined(typeof(ExtensionAttribute), false))
                {
                    return (ExtensionAttribute)thisType.GetCustomAttributes(typeof(ExtensionAttribute), false)[0];
                }
                return null;
            }
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Executes the current extension.
        /// </summary>
        /// <param name="shell">The shell.</param>
        protected abstract void DoExecute(IShell shell);
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the identifier of the extension.
        /// </summary>
        /// <value>
        /// The identifier of the extension.
        /// </value>
        /// <exception cref="System.InvalidOperationException">The extension was not decorated with ExtensionAttribute attribute.</exception>
        public Guid ID
        {
            get
            {
                if (this.ExtensionAttribute != null)
                    return this.ExtensionAttribute.ID;
                throw new InvalidOperationException(Resources.ExtensionNotDecoratedWithExtensionAttribute);
            }
        }

        /// <summary>
        /// Gets the name of the extension.
        /// </summary>
        /// <value>
        /// The name of the extension.
        /// </value>
        /// <exception cref="System.InvalidOperationException">The extension was not decorated with ExtensionAttribute attribute.</exception>
        public string Name
        {
            get
            {
                if (this.ExtensionAttribute != null)
                    return this.ExtensionAttribute.Name;
                throw new InvalidOperationException(Resources.ExtensionNotDecoratedWithExtensionAttribute);
            }
        }

        /// <summary>
        /// Gets the version of the extension.
        /// </summary>
        /// <value>
        /// The version of the extension.
        /// </value>
        public virtual Version Version
        {
            get
            {
                return this.GetType().Assembly.GetName().Version;
            }
        }

        /// <summary>
        /// Gets the manufacture of the extension.
        /// </summary>
        /// <value>
        /// The manufacture of the extension.
        /// </value>
        public abstract string Manufacture { get; }
        
        /// <summary>
        /// Gets the display name of the extension.
        /// </summary>
        /// <value>
        /// The display name of the extension.
        /// </value>
        public abstract string DisplayName { get; }

        /// <summary>
        /// Gets the description of the extension.
        /// </summary>
        /// <value>
        /// The description of the extension.
        /// </value>
        public abstract string Description { get; }

        /// <summary>
        /// Gets the setting provider.
        /// </summary>
        /// <value>
        /// The setting provider.
        /// </value>
        public ExtensionSettingProvider SettingProvider
        {
            get
            {
                if (this.settingProvider == null)
                {
                    if (this.ExtensionAttribute == null)
                    {
                        throw new InvalidOperationException(Resources.ExtensionNotDecoratedWithExtensionAttribute);
                    }

                    if (this.ExtensionAttribute.SettingProviderType != null &&
                        this.ExtensionAttribute.SettingProviderType.IsSubclassOf(typeof(ExtensionSettingProvider)))
                    {
                        this.settingProvider = (ExtensionSettingProvider)Activator.CreateInstance(this.ExtensionAttribute.SettingProviderType, new[] { this });
                        return this.settingProvider;
                    }
                    return null;
                }
                return this.settingProvider;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Executes the current extension against the specified shell.
        /// </summary>
        /// <param name="shell">The shell.</param>
        /// <exception cref="System.ArgumentNullException">shell</exception>
        public void Execute(IShell shell)
        {
            if (shell == null)
                throw new ArgumentNullException("shell");
            this.DoExecute(shell);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }
        #endregion
    }
}
