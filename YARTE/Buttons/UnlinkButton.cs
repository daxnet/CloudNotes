using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class UnlinkButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand("Unlink", false, null);
        }

        public Image IconImage
        {
            get { return Resources.unlink; }
        }

        public string IconName
        {
            get { return "Unlink"; }
        }

        public string IconTooltip
        {
            get { return Resources.UnlinkToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "Unlink"; }
        }
    }
}