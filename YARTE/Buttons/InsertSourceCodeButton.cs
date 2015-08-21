namespace YARTE.Buttons
{
    using System.Drawing;
    using YARTE.Properties;
    using YARTE.UI.Buttons;

    public class InsertSourceCodeButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs doc)
        {
            
        }

        public Image IconImage
        {
            get { return Resources.insert_source_code; }
        }

        public string IconName
        {
            get { return "Insert Source Code"; }
        }

        public string IconTooltip
        {
            get { return Resources.InsertSourceCodeToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "InsertSourceCode"; }
        }
    }
}
