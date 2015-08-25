namespace CloudNotes.DesktopClient.Extensions.InsertSourceCode
{
    using System.Drawing;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensibility.Extensions;
    using CloudNotes.DesktopClient.Extensions.Properties;

    [Extension("170BFB11-4782-4A7A-A055-D7E31CED6EAE", "InsertSourceCode", typeof(InsertSourceCodeSettingProvider))]
    public sealed class InsertSourceCodeExtension : ToolExtension
    {
        public InsertSourceCodeExtension()
            : base(Resources.InsertSourceCodeToolName)
        {
        }

        public override Image ToolIcon
        {
            get { return Resources.CSharpCode; }
        }

        protected override void DoExecute(IShell shell)
        {
            if (shell.HasActiveDocument)
            {
                SafeExecutionContext.Execute((Form)shell.Owner, () =>
                {
                    var setting = this.SettingProvider.GetExtensionSetting<InsertSourceCodeSetting>();
                    var insertCodeDialog = new FrmInsertSourceCode(setting);
                    if (insertCodeDialog.ShowDialog() == DialogResult.OK)
                    {
                        shell.InsertHtml(insertCodeDialog.SourceCodeTag);
                    }
                });
            }
            else
            {
                MessageBox.Show(Resources.NoActiveNoteOpened, Resources.Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public override string Manufacture
        {
            get { return Resources.ManufactureName; }
        }

        public override string Description
        {
            get { return Resources.InsertSourceCodeDescription; }
        }
    }
}
