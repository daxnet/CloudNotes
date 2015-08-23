namespace YARTE.Buttons
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    using YARTE.Properties;
    using YARTE.UI.Buttons;

    public class InsertClipboardImageButton : IHTMLEditorButton
    {
        public void IconClicked(HTMLEditorButtonArgs doc)
        {
            var image = Clipboard.GetImage();
            if (image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    var base64 = Convert.ToBase64String(memoryStream.ToArray());
                    var html = string.Format("<img src=\"data:image/png;base64,{0}\" alt=\"{1}\" />", base64,
                        Guid.NewGuid());
                    var insertHtmlButton = new InsertHtmlButton(html);
                    insertHtmlButton.IconClicked(doc);
                }
            }
        }

        public Image IconImage
        {
            get { return Resources.image_clipboard; }
        }

        public string IconName
        {
            get { return "Insert Clipboard Image"; }
        }

        public string IconTooltip
        {
            get { return Resources.InsertClipboardImageToolTip; }
        }

        public string CommandIdentifier
        {
            get { return "InsertClipboardImage"; }
        }
    }
}
