using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class BoldButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand("Bold", false, null);
        }

        public Image IconImage
        {
            get
            {
                return Resources.text_bold;
            }
        }

        public string IconName
        {
            get { return "Bold"; }
        }

        public string IconTooltip
        {
            get { return Resources.BoldToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "Bold"; }
        }
    }
}