using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    public partial class ImportFromWebSettingControl : UserControl
    {
        public ImportFromWebSettingControl()
        {
            InitializeComponent();

            var encodingInforArray = Encoding.GetEncodings().OrderBy(p => p.DisplayName).ToList();
            cbEncoding.Items.Clear();
            cbEncoding.DisplayMember = "DisplayName";
            cbEncoding.ValueMember = "Name";
            cbEncoding.DataSource = encodingInforArray;
            
        }
    }
}
