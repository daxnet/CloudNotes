using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    public partial class ProgressIndicatorDialog : Form
    {
        public ProgressIndicatorDialog()
        {
            InitializeComponent();
        }

        public async Task SetProgress(int current, int total)
        {
            await Task.Factory.StartNew(() =>
                {
                    SetLabel1Text(string.Format("{0} of {1} proceeded.", current, total));
                    SetProgressValue(current, total);
                });
        }

        private void SetLabel1Text(string text)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)SetLabel1Text, text);
                return;
            }
            this.lblStatus.Text = text;
        }

        private void SetProgressValue(int current, int total)
        {
            if(InvokeRequired)
            {
                Invoke((Action<int,int>)SetProgressValue, current, total);
            }
            this.pb.Maximum = total;
            this.pb.Value = current;
        }
    }
}
