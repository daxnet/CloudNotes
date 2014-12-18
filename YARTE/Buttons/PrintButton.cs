using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YARTE.Buttons
{
    using YARTE.Properties;
    using YARTE.UI.Buttons;

    public class PrintButton : IHTMLEditorButton
    {
        #region IHTMLEditorButton Members

        public void IconClicked(HTMLEditorButtonArgs doc)
        {
            doc.Document.ExecCommand("Print", true, null);
        }

        public System.Drawing.Image IconImage
        {
            get { return Resources.printer; }
        }

        public string IconName
        {
            get
            {
                return "Print";
            }
        }

        public string IconTooltip
        {
            get
            {
                return Resources.PrintToolTip;
            }
        }

        public string CommandIdentifier
        {
            get
            {
                return "";
            }
        }

        #endregion
    }
}
