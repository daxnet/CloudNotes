using CloudNotes.DesktopClient.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.Email
{
    [Extension("{0D3548D8-BAD4-4457-925A-72A4B873FE76}", "SendByEmail")]
    public sealed class SendByEmailExtension : ToolExtension
    {
        public SendByEmailExtension() :
            base("Send by Email")
        { }

        protected override void DoExecute(IShell shell)
        {
            
        }
    }
}
