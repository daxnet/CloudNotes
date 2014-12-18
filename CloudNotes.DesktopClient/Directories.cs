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
        public const string ProfileFileName = "cloudnotes.profile";
        public static string GetFullName(string fileOrDir)
        {
            return Path.Combine(Application.StartupPath, fileOrDir);
        }
    }
}
