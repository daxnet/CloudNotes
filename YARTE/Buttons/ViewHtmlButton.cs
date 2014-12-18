using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YARTE.Buttons
{
    using YARTE.Properties;
    using YARTE.UI.Buttons;

    public class ViewHtmlButton : IHTMLEditorButton
    {
        #region IHTMLEditorButton Members

        public void IconClicked(HTMLEditorButtonArgs doc)
        {
            new FrmViewHtml(doc.Editor.Html).ShowDialog();
        }

        public System.Drawing.Image IconImage
        {
            get
            {
                return Resources.page_white_code;
            }
        }

        public string IconName
        {
            get
            {
                return "View Html";
            }
        }

        public string IconTooltip
        {
            get { return Resources.ViewHtmlToolTip; }
        }

        public string CommandIdentifier
        {
            get { return ""; }
        }

        #endregion
    }
}
