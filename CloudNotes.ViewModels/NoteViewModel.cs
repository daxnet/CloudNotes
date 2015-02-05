using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.ViewModels
{
    public class NoteViewModel : ViewModel
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; set; }

        public DateTime? DateLastModified { get; set; }

        public string Weather { get; set; }

        public Guid UserID { get; set; }

        public string Description { get; set; }

        public string ThumbnailBase64 { get; set; }
    }
}
