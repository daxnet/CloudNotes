using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Settings
{
    public class GeneralSettings
    {
        public string Language { get; set; }

        public bool ShowUnderExtensionsMenu { get; set; }
        public bool OnlyShowForMaximumExtensionsLoaded { get; set; }
        public int MaximumExtensionsLoadedValue { get; set; }
    }
}
