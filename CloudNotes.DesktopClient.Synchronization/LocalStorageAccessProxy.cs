using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Synchronization
{
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensibility.Data;

    internal sealed class LocalStorageAccessProxy : DataAccessProxy
    {
        public LocalStorageAccessProxy(ClientCredential credential)
            : base(credential)
        {
        }

        protected override void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Note>> GetNotesAsync(bool deleted = false)
        {
            throw new NotImplementedException();
        }

        public override Task<Guid> CreateNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public override Task MarkDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task EmptyTrashAsync()
        {
            throw new NotImplementedException();
        }

        public override Task RestoreAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<Note> GetNoteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
