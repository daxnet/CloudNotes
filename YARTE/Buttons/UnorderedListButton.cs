using System.Drawing;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class UnorderedListButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            args.Document.ExecCommand("InsertUnorderedList", false, null);
        }

        public Image IconImage
        {
            get { return Resources.text_list_bullets; }
        }

        public string IconName
        {
            get { return "Unordered list"; }
        }

        public string IconTooltip
        {
            get { return Resources.UnorderedListToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "InsertUnorderedList"; }
        }
    }
}