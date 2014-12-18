using System.Globalization;
using System.Runtime.Remoting.Channels;

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var credential = LoginProvider.Login(Application.Exit);
            //if (credential != null) //Application.Run(new FrmMain(credential));
            //{
            var args = Environment.GetCommandLineArgs();
            var controller = new SingleInstanceController();
            try
            {
                controller.Run(args);
            }
            catch (NoStartupFormException)
            {
                
            }
            
            //}
        }
    }
}
