using System.Linq;

namespace YARTE.UI.Buttons
{
    using YARTE.Buttons;

    public static class PredefinedButtonSets
    {
        private static readonly string[] _webSafeFonts = new [] { "Courier New", "Times New Roman", "Georgia", "Arial", "Verdana"};

        public static void SetupDefaultButtons(HtmlEditor editor)
        {
            editor.AddToolbarItem(new BoldButton());
            editor.AddToolbarItem(new ItalicButton());
            editor.AddStyleSelector();
            editor.AddFontSizeSelector(Enumerable.Range(1, 7));
            editor.AddFontSelector(_webSafeFonts);
            editor.AddToolbarDivider();
            editor.AddToolbarItem(new LinkButton());
            editor.AddToolbarItem(new UnlinkButton());
            editor.AddToolbarDivider();
            editor.AddToolbarItem(new InsertLinkedImageButton());
            editor.AddToolbarDivider();
            editor.AddToolbarItem(new OrderedListButton());
            editor.AddToolbarItem(new UnorderedListButton());
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