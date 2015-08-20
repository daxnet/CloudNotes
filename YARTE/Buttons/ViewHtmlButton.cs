namespace YARTE.Buttons
{
    using System.Drawing;
    using System.Windows.Forms;
    using YARTE.Properties;
    using YARTE.UI.Buttons;

    public class ViewHtmlButton : IHTMLEditorButton
    {
        #region IHTMLEditorButton Members

        public void IconClicked(HTMLEditorButtonArgs doc)
        {
            var frm = new FrmViewHtml(doc.Editor.Html);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                doc.Editor.SetHtml(frm.Html);
            }
        }

        public Image IconImage
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
