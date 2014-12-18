using System.Drawing;
using System.Windows.Forms;

namespace YARTE.UI.Buttons
{
    public struct HTMLEditorButtonArgs
    {
        public HtmlDocument Document;
        public HtmlEditor Editor;
    }

    public interface IHTMLEditorButton
    {
        void IconClicked(HTMLEditorButtonArgs doc);
        Image IconImage { get; }
        string IconName { get; }
        string IconTooltip { get; }

        /// <summary>
        /// This is the string that will be used to poll the text area to determine if the cursor
        /// is in a given area (say, 'Bold') and show the corresponding button as selected
        /// Leave blank if there is no command or you have no idea what to put here
        /// </summary>
        string CommandIdentifier { get; }
    }
}