using CloudNotes.DesktopClient.Extensibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensions.Exporters
{
    public partial class TextFileExporterOptionDialog : Form, IExportOptionDialog
    {
        public TextFileExporterOptionDialog()
        {
            InitializeComponent();
        }


        public object Options
        {
            get { return cbEncoding.SelectedItem; }
        }

        private void TextFileExporterOptionDialog_Load(object sender, EventArgs e)
        {
            var encodingInforArray = Encoding.GetEncodings().OrderBy(p => p.DisplayName).ToList();
            cbEncoding.Items.Clear();
            cbEncoding.DisplayMember = "DisplayName";
            cbEncoding.ValueMember = "Name";
            cbEncoding.DataSource = encodingInforArray;
            cbEncoding.SelectedItem = encodingInforArray.First(enc => enc.CodePage == Encoding.UTF8.CodePage);
        }
    }
}
