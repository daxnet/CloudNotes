using CloudNotes.DesktopClient.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions
{
    [Extension("{93275853-1649-4726-8200-3F3643779499}")]
    public class CustomToolExtension : ToolExtension
    {
        public CustomToolExtension()
            : base("MyCustomTool", "My Custom Tool")
        { }

        protected override Task DoExecuteAsync(IShell shell)
        {
            throw new NotImplementedException();
        }

        public override string DisplayName
        {
            get { return this.ToolName; }
        }
    }
}
