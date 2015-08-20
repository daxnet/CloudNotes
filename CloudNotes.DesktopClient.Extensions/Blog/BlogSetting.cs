using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using CloudNotes.DesktopClient.Extensibility.Extensions;

    public sealed class BlogSetting : IExtensionSetting
    {
        public static readonly BlogSetting Default = new BlogSetting();

        public string MetaWeblogAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
