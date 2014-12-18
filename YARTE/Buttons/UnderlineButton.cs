using System;
using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class UnderlineButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand("Underline", false, null);
        }

        public Image IconImage
        {
            get { return Resources.underline; }
        }

        public string IconName
        {
            get { return "Underline"; }
        }

        public string IconTooltip
        {
            get { return Resources.UnderlineToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "Underline"; }
        }
    }
}