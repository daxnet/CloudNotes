using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using CloudNotes.DesktopClient.Settings;
using System.Globalization;
using System.Threading;

namespace CloudNotes.DesktopClient
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            // Set whether the application is single instance
            this.IsSingleInstance = true;
            this.StartupNextInstance += this.this_StartupNextInstance;
        }

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            // Here you get the control when any other instance is
            // invoked apart from the first one.
            // You have args here in e.CommandLine.

            // You custom code which should be run on other instances
            if (MainForm != null && MainForm is FrmMain)
            {
                (MainForm as FrmMain).WindowState = FormWindowState.Normal;
                (MainForm as FrmMain).Show();
            }
        }

        protected override void OnCreateMainForm()
        {
            var settings = DesktopClientSettings.ReadSettings();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.General.Language);

            var credential = LoginProvider.Login(Application.Exit, settings);
            if (credential != null)
            {
                // Instantiate your main application form
                this.MainForm = new FrmMain(credential, settings);
            }
        }
    }
}
