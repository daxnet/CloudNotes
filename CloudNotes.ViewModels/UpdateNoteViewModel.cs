using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.ViewModels
{
    public class UpdateNoteViewModel : ViewModel
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Weather { get; set; }
    }
}
