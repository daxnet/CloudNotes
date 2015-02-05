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

        /// <summary>
        /// The description of the note, normally it is the first N
        /// letters of the note content.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The base64 encoded data that represents the first picture
        /// shown in the note content. If there is no picture in the
        /// note, value of this property is null.
        /// </summary>
        public string ThumbnailBase64 { get; set; }

        public DateTime DatePublished { get; set; }

        public int DeletedFlag { get; set; }

        public string DeletedString { get; set; }
    }
}
