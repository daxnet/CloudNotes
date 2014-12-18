using System.ComponentModel.DataAnnotations;

namespace CloudNotes.ViewModels
{
    public class CreateNoteViewModel : ViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        [StringValues("Unspecified", "Cloudy", "Foggy", "Rainy", "Sunny")]
        public string Weather { get; set; }
    }
}
