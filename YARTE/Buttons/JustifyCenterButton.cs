using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class JustifyCenterButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand(CommandIdentifier, false, null);
        }

        public Image IconImage
        {
            get { return Resources.text_align_center; }
        }

        public string IconName
        {
            get { return "Justify center"; }
        }

        public string IconTooltip
        {
            get { return Resources.JustifyCenterToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "JustifyCenter"; }
        }
    }
}