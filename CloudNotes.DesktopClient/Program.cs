
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;
using CloudNotes.DesktopClient.Extensibility;

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

            var args = Environment.GetCommandLineArgs();
            var controller = new SingleInstanceController();
            try
            {
                controller.Run(args);
            }
            catch (NoStartupFormException)
            {

            }
            catch (Exception e)
            {
                FrmExceptionDialog.ShowException(e);
            }
        }
    }
}
