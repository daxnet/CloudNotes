using CloudNotes.DesktopClient.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions
{
    public sealed class CustomSetting : IExtensionSetting
    {
        public string Greeting { get; set; }
    }
}
