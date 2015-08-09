namespace YARTE.Buttons
{
    using System.Drawing;
    using YARTE.Properties;
    using YARTE.UI.Buttons;

    public class StrikeThroughButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs doc)
        {
            doc.Document.ExecCommand("StrikeThrough", false, null);
        }

        public Image IconImage
        {
            get { return Resources.strikethrough; }
        }

        public string IconName
        {
            get { return "StrikeThrough"; }
        }

        public string IconTooltip
        {
            get { return Resources.StrikeThroughToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "StrikeThrough"; }
        }
    }
}
