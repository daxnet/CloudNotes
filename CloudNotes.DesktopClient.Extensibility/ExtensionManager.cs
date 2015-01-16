using CloudNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensibility
{
    internal sealed class ExtensionManager
    {
        private readonly string path;
        private readonly Dictionary<Guid, Extension> extensions = new Dictionary<Guid, Extension>();

        public ExtensionManager(string path)
        {
            this.path = path;
        }

        public ExtensionManager()
            : this(Path.Combine(Application.StartupPath, Constants.ExtensionFolderName))
        {

        }

        #region Public Events        
        /// <summary>
        /// Occurs when the extension is loading by current extension manager.
        /// </summary>
        public event EventHandler<ExtensionLoadEventArgs> ExtensionLoaded;
        #endregion

        private void OnExtensionLoaded(string extensionName)
        {
            var handler = this.ExtensionLoaded;
            if (handler!=null)
            {
                handler(this, new ExtensionLoadEventArgs(extensionName));
            }
        }

        public void Load()
        {
            var extensionFiles = Directory.EnumerateFiles(this.path, Constants.ExtensionFileSearchPattern, SearchOption.AllDirectories);
            foreach (var extensionFile in extensionFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(extensionFile);
                    foreach (var type in assembly.GetExportedTypes())
                    {
                        try
                        {
                            if (type.IsDefined(typeof(ExtensionAttribute)) &&
                                type.IsSubclassOf(typeof(Extension)))
                            {
                                var extensionLoaded = (Extension)Activator.CreateInstance(type);
                                this.OnExtensionLoaded(extensionLoaded.Name);
                                this.extensions.Add(extensionLoaded.ID, extensionLoaded);
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }
    }
}
