using System.Data.Entity;
using CloudNotes.Domain.Repositories.EntityFramework;

namespace CloudNotes.WebAPI
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
#if DEBUG
            Database.SetInitializer(new CloudNotesDatabaseInitializationStrategy());
            new CloudNotesContext().Database.Initialize(true);
#else
            Database.SetInitializer<CloudNotesContext>(null);
#endif
        }
    }
}