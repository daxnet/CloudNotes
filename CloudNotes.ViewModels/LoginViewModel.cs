using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.ViewModels
{
    public class AuthenticationViewModel : ViewModel
    {
        public string UserName { get; set; }

        public string EncodedPassword { get; set; }
    }
}
