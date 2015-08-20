using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YARTE
{
    public partial class FrmViewHtml : Form
    {
        private readonly string html;

        public FrmViewHtml()
        {
            InitializeComponent();
        }

        internal FrmViewHtml(string html)
            : this()
        {
            this.html = html;
        }

        internal string Html
        {
            get { return (this.elementHost1.Child as HtmlSourceEditor).avalonTextEditor.Text; }
        }

        private void FrmViewHtml_Shown(object sender, EventArgs e)
        {
            //txtHtml.Text = this.html;
            //txtHtml.SelectionStart = 0;
            //txtHtml.SelectionLength = 0;
            (this.elementHost1.Child as HtmlSourceEditor).avalonTextEditor.Text = this.html;
        }
    }
}
