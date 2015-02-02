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
    public partial class ImportFromWebDialog : Form
    {
        public ImportFromWebDialog()
        {
            InitializeComponent();
        }

        public string Url
        {
            get { return this.txtLink.Text; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtLink.Text))
            {
                errorProvider.SetError(txtLink, "Link cannot be empty.");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }


    }
}
