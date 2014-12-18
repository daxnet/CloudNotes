using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Profiles
{
    public class UserProfile
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsSelected { get; set; }

        public bool RememberPassword { get; set; }

        public bool AutoLogin { get; set; }

        public override string ToString()
        {
            return UserName;
        }
    }
}
