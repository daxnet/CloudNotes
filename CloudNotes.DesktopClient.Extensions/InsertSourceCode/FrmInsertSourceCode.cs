namespace CloudNotes.DesktopClient.Extensions.InsertSourceCode
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class FrmInsertSourceCode : Form
    {
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

        public FrmInsertSourceCode()
        {
            InitializeComponent();

            cbLanguage.Items.Clear();
            foreach (var codeLanguage in codeLanguages)
            {
                cbLanguage.Items.Add(codeLanguage);
            }
            cbLanguage.SelectedIndex = 0;
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
