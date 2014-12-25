using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient
{
    public static class Directories
    {
        private const string CloudNotesDataFolder = "CloudNotes";
        public static string GetFullName(string fileOrDir)
        {
#if DEBUG
            return Path.Combine(Application.StartupPath, fileOrDir);
#else
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                CloudNotesDataFolder);
            return Path.Combine(path, fileOrDir);
#endif
        }
    }
}
