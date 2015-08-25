namespace CloudNotes.DesktopClient.Extensions.InsertSourceCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensions.Properties;
    using CloudNotes.Infrastructure;

    public partial class FrmInsertSourceCode : Form
    {
        private const string PreTagFormat = "<pre class=\"{0}\">{1}</pre>";
        private readonly List<CodeLanguage> codeLanguages = new List<CodeLanguage>
        {
            new CodeLanguage("csharp", "Visual C#"),
            new CodeLanguage("bash", "Bash"),
            new CodeLanguage("shell", "Shell"),
            new CodeLanguage("cpp", "C++"),
            new CodeLanguage("css", "CSS"),
            new CodeLanguage("pas", "Pascal"),
            new CodeLanguage("groovy", "Groovy"),
            new CodeLanguage("xml", "XML"),
            new CodeLanguage("js", "Javascript"),
            new CodeLanguage("java", "Java"),
            new CodeLanguage("php", "PHP"),
            new CodeLanguage("text", "Text"),
            new CodeLanguage("py", "Python"),
            new CodeLanguage("rails", "Rails"),
            new CodeLanguage("sql", "SQL"),
            new CodeLanguage("vb", "Visual Basic"),
            new CodeLanguage("powershell", "Windows PowerShell"),
            new CodeLanguage("fsharp", "Visual F#")
        };

        private readonly InsertSourceCodeSetting setting;

        private FrmInsertSourceCode()
        {
            InitializeComponent();
            this.Text = Resources.InsertSourceCodeToolName.Trim('.');
            this.lblTitle.Text = this.Text;
            this.lblDescription.Text = Resources.InsertSourceCodeDescription;
        }

        public FrmInsertSourceCode(InsertSourceCodeSetting setting)
            :this()
        {
            cbLanguage.Items.Clear();
            foreach (var codeLanguage in codeLanguages)
            {
                cbLanguage.Items.Add(codeLanguage);
            }
            cbLanguage.SelectedIndex = 0;
            this.setting = setting;
        }

        public string SourceCodeTag
        {
            get
            {
                var defaultSetting = InsertSourceCodeSetting.Default;
                var classBuilder = new StringBuilder();
                classBuilder.AppendFormat("brush: {0}; ", ((CodeLanguage) cbLanguage.SelectedItem).Name);
                if (setting.AutoLinks != defaultSetting.AutoLinks)
                {
                    classBuilder.AppendFormat("auto-links: {0}; ", setting.AutoLinks);
                }
                if (setting.Collapse != defaultSetting.Collapse)
                {
                    classBuilder.AppendFormat("collapse: {0}; ", setting.Collapse);
                }
                if (setting.Gutter != defaultSetting.Gutter)
                {
                    classBuilder.AppendFormat("gutter: {0}; ", setting.Gutter);
                }
                if (setting.ShowToolbar != defaultSetting.ShowToolbar)
                {
                    classBuilder.AppendFormat("toolbar: {0}; ", setting.ShowToolbar);
                }
                if (setting.SmartTabs != defaultSetting.SmartTabs)
                {
                    classBuilder.AppendFormat("smart-tabs: {0}; ", setting.SmartTabs);
                }
                if (setting.TabSize != defaultSetting.TabSize)
                {
                    classBuilder.AppendFormat("tab-size: {0}; ", setting.TabSize);
                }
                if (!string.IsNullOrEmpty(txtHightlightedLines.Text))
                {
                    classBuilder.AppendFormat("highlight: [{0}]; ", txtHightlightedLines.Text);
                }
                return string.Format(PreTagFormat, classBuilder, HttpUtility.HtmlEncode(txtSourceCode.Text));
            }
        }

        private void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            "http://alexgorbatchev.com/SyntaxHighlighter/".Navigate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!string.IsNullOrEmpty(txtHightlightedLines.Text))
            {
                var allValues = txtHightlightedLines.Text.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
                int res;
                if (allValues.Any(v => !int.TryParse(v, out res)))
                {
                    errorProvider.SetError(txtHightlightedLines, Resources.HighlightedLinesFormatMsg);
                    this.DialogResult = DialogResult.None;
                }
            }

            if (string.IsNullOrEmpty(txtSourceCode.Text))
            {
                errorProvider.SetError(grpSourceCode, Resources.EmptySourceCodeMsg);
                this.DialogResult = DialogResult.None;
            }

        }

        private void FrmInsertSourceCode_Shown(object sender, EventArgs e)
        {
            txtSourceCode.Focus();
        }
        
    }

    internal sealed class CodeLanguage
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }

        public CodeLanguage(string name, string displayName)
        {
            this.DisplayName = displayName;
            this.Name = name;
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
