using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.ViewModels
{
    public class NoteItemViewModel : ViewModel
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public DateTime DatePublished { get; set; }

        public int DeletedFlag { get; set; }

        public string DeletedString { get; set; }
    }
}
