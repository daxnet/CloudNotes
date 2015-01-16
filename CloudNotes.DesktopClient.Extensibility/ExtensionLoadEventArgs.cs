using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensibility
{

    internal sealed class ExtensionLoadEventArgs : EventArgs
    {
        public ExtensionLoadEventArgs() { }

        public ExtensionLoadEventArgs(string extensionName)
        {
            this.ExtensionName = extensionName;
        }

        public string ExtensionName { get; set; }

    }
}
