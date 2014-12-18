using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Updater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null || args.Length != 2)
                return;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[1]);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain(args));
        }
    }
}
