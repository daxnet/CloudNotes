using System.Linq;

namespace YARTE.UI.Buttons
{
    using YARTE.Buttons;

    public static class PredefinedButtonSets
    {
        private static readonly string[] webSafeFonts = { "Courier New", "Times New Roman", "Georgia", "Arial", "Verdana"};

        public static void SetupDefaultButtons(HtmlEditor editor)
        {
            editor.AddToolbarItem(new BoldButton());
            editor.AddToolbarItem(new ItalicButton());
            editor.AddToolbarItem(new UnderlineButton());
            editor.AddToolbarItem(new StrikeThroughButton());
            editor.AddStyleSelector();
            editor.AddFontSizeSelector(Enumerable.Range(1, 7));
            editor.AddFontSelector(webSafeFonts);
            editor.AddToolbarDivider();
            editor.AddToolbarItem(new LinkButton());
            editor.AddToolbarItem(new UnlinkButton());
            editor.AddToolbarItem(new InsertLinkedImageButton());
            editor.AddToolbarItem(new InsertOnlineImageButton());
            editor.AddToolbarItem(new OrderedListButton());
            editor.AddToolbarItem(new UnorderedListButton());
            editor.AddToolbarItem(new InsertSourceCodeButton());
            editor.AddToolbarDivider();
            editor.AddToolbarItem(new ForecolorButton());
            editor.AddToolbarDivider();
            editor.AddToolbarItem(new JustifyLeftButton());
            editor.AddToolbarItem(new JustifyCenterButton());
            editor.AddToolbarItem(new JustifyRightButton());
            editor.AddToolbarDivider();
            // editor.AddToolbarItem(new PrintButton());
            editor.AddToolbarItem(new ViewHtmlButton());
        }
    }
}