using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CloudNotes.DesktopClient.Properties;

namespace CloudNotes.DesktopClient
{
    public partial class FrmNewNote : Form
    {
        private readonly IEnumerable<string> existingNoteTitles; 
        public FrmNewNote()
        {
            InitializeComponent();
        }

        public FrmNewNote(IEnumerable<string> existingNoteTitles)
            : this ()
        {
            this.existingNoteTitles = existingNoteTitles;
        }

        public string NoteTitle { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, 
                    Resources.TitleRequired);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (existingNoteTitles.Any(p=>p==txtTitle.Text))
            {
                errorProvider.SetError(txtTitle,
                    Resources.TitleExists);
                this.DialogResult = DialogResult.None;
                return;
            }
            this.NoteTitle = txtTitle.Text;
        }

        private void FrmNewNote_Shown(object sender, EventArgs e)
        {
            txtTitle.Focus();
        }
    }
}
