namespace CloudNotes.DesktopClient.Extensions.InsertSourceCode
{
    using CloudNotes.DesktopClient.Extensibility.Extensions;

    public sealed class InsertSourceCodeSetting : IExtensionSetting
    {
        public static readonly InsertSourceCodeSetting Default = new InsertSourceCodeSetting(true, false, true, true, 4,
            true);

        public InsertSourceCodeSetting()
        {
  
        }

        private InsertSourceCodeSetting(bool autoLinks, bool collapse, bool gutter,
            bool smartTabs, int tabSize, bool showToolbar)
        {
            this.AutoLinks = autoLinks;
            this.Collapse = collapse;
            this.Gutter = gutter;
            this.SmartTabs = smartTabs;
            this.TabSize = tabSize;
            this.ShowToolbar = showToolbar;
        }

        public bool AutoLinks { get; set; }
        public bool Collapse { get; set; }
        public bool Gutter { get; set; }
        public bool SmartTabs { get; set; }
        public int TabSize { get; set; }
        public bool ShowToolbar { get; set; }
    }
}
