

namespace CloudNotes.DesktopClient.Extensibility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class TextInputBox : Form
    {
        private readonly string prompt;
        private readonly string initValue;
        private readonly List<Tuple<Func<string, bool>, string>> validations = new List<Tuple<Func<string, bool>, string>>();

        public TextInputBox()
        {
            InitializeComponent();
        }

        public TextInputBox(string prompt, IEnumerable<Tuple<Func<string, bool>, string>> validations = null)
            : this(prompt, null, validations)
        {
            
        }

        public TextInputBox(string prompt, string initValue, IEnumerable<Tuple<Func<string, bool>, string>> validations = null)
            :this()
        {
            this.prompt = prompt;
            this.initValue = initValue;
            if (validations != null)
            {
                this.validations.AddRange(validations);
            }
        }

        public string InputText
        {
            get { return this.txtInput.Text; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.validations.Count > 0)
            {
                errorProvider.Clear();
                foreach (var validation in this.validations)
                {
                    if (validation.Item1(this.txtInput.Text))
                    {
                        errorProvider.SetError(this.txtInput, validation.Item2);
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                }
            }
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
        }

        private void TextInputBox_Load(object sender, EventArgs e)
        {
            this.lblPrompt.Text = this.prompt;
            this.txtInput.Text = this.initValue;
        }
    }
}
