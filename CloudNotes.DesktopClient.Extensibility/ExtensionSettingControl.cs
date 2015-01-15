using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CloudNotes.DesktopClient.Extensibility
{
    public partial class ExtensionSettingControl : UserControl
    {
        private readonly Extension extension;

        public ExtensionSettingControl(Extension extension)
        {
            InitializeComponent();
            this.extension = extension;
        }


    }
}
