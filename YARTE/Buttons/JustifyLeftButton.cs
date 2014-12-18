using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class JustifyLeftButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand(CommandIdentifier, false, null);
        }

        public Image IconImage
        {
            get { return Resources.text_align_left; }
        }

        public string IconName
        {
            get { return "Justify left"; }
        }

        public string IconTooltip
        {
            get { return Resources.JustifyLeftToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "JustifyLeft"; }
        }
    }
}