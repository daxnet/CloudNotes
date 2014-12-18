using System.Drawing;
using Microsoft.VisualBasic;
using YARTE.Properties;

namespace YARTE.UI.Buttons
{
    public class InsertLinkedImageButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs args)
        {
            //var x = args.Editor.Location.X + 10;
            //var y = args.Editor.Location.Y + 10;
            
            //var url = Interaction.InputBox("Please enter an image url", "URL", null, x, y);
            //if (!string.IsNullOrEmpty(url))
            //{
            //    args.Document.ExecCommand("InsertImage", false, url);
            //}
            args.Document.ExecCommand("InsertImage", true, null);
        }

        public Image IconImage
        {
            get { return Resources.image; }
        }

        public string IconName
        {
            get { return "Linked image"; }
        }

        public string IconTooltip
        {
            get { return Resources.InsertImageToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "InsertImage"; }
        }
    }
}