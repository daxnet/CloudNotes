using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class LinkButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand("CreateLink", true, null);
        }

        public Image IconImage
        {
            get { return Resources.world_link; }
        }

        public string IconName
        {
            get { return "Create link"; }
        }

        public string IconTooltip
        {
            get { return Resources.InsertLinkToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "CreateLink"; }
        }
    }
}