using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CloudNotes.DesktopClient.Extensibility.Properties;

namespace CloudNotes.DesktopClient.Extensibility
{
    public partial class FrmExceptionDialog : Form
    {
        private bool showDetail = false;

        private FrmExceptionDialog()
        {
            InitializeComponent();
            txtDetail.Visible = false;
            this.Height = 151;
        }

        public static DialogResult ShowException(Exception ex)
        {
            var excDialog = new FrmExceptionDialog
                                {
                                    txtMessage = { Text = ex.Message },
                                    txtDetail = { Text = ex.ToString() }
                                };
            
            return excDialog.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showDetail = !showDetail;
            if (showDetail)
            {
                linkLabel1.Text = Resources.HideDetail;
                txtDetail.Visible = true;
                this.Height = 307;
            }
            else
            {
                linkLabel1.Text = Resources.ShowDetail;
                txtDetail.Visible = false;
                this.Height = 151;
            }
        }
    }
}
