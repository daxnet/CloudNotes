using System.Threading.Tasks;
using System.Web.Http.OData;

using Apworks;
using Apworks.Repositories;
using Apworks.Specifications;
using Apworks.Storage;
using AutoMapper.QueryableExtensions;
using CloudNotes.Domain.Model;
using CloudNotes.ViewModels;
using CloudNotes.WebAPI.Models.Exceptions;
using CloudNotes.WebAPI.Models.Filters;
using CloudNotes.WebAPI.Properties;
using System;
using System.Linq;
using System.Web.Http;


namespace CloudNotes.WebAPI.Controllers
{
    using AutoMapper;

    [RoutePrefix("api")]
    public class NotesController : WebApiController
    {
        private readonly IRepository<Note> noteRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="noteRepository">The note repository.</param>
        public NotesController(IRepositoryContext repositoryContext,
            IRepository<Note> noteRepository)
            : base(repositoryContext)
        {
            this.noteRepository = noteRepository;
        }

        [WebApiAuthorization]
        [Route("notes/create")]
        [HttpPost]
        public IHttpActionResult CreateNote([FromBody]CreateNoteViewModel viewModel)
        {
            var note = Mapper.Map<CreateNoteViewModel, Note>(viewModel);
            note.User = CurrentLoginUser;
            noteRepository.Add(note);
            RepositoryContext.Commit();
            return Ok(note.ID);
        }

        [WebApiAuthorization]
        [Route("notes/update")]
        [HttpPost]
        public IHttpActionResult UpdateNote([FromBody]UpdateNoteViewModel viewModel)
        {
            var note = noteRepository.GetByKey(viewModel.ID);
            if (note != null) note = Mapper.Map(viewModel, note);
            noteRepository.Update(note);
            RepositoryContext.Commit();
            return this.Ok();
        }

        [WebApiAuthorization]
        [Route("notes/markdelete")]
        [HttpPost]
        public IHttpActionResult MarkDelete([FromBody]Guid id)
        {
            RequireExistance(n => n.ID == id, noteRepository);
            var note = noteRepository.GetByKey(id);
            if (note.User != CurrentLoginUser) 
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            note.Deleted = DeleteFlag.MarkDeleted;
            noteRepository.Update(note);
            RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        /// Deletes the note by using the given note ID.
        /// </summary>
        /// <param name="id">The identifier of the note to be deleted.</param>
        /// <returns></returns>
        /// <exception cref="InsufficientPriviledgeException"></exception>
        [WebApiAuthorization]
        [Route("notes/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteNote(Guid id)
        {
            RequireExistance(n => n.ID == id, noteRepository);
            var note = noteRepository.GetByKey(id);
            if (note.User != CurrentLoginUser)
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            note.Deleted = DeleteFlag.Deleted;
            noteRepository.Update(note);
            RepositoryContext.Commit();
            return this.Ok();
        }

        [WebApiAuthorization]
        [Route("notes/emptytrash")]
        [HttpDelete]
        public IHttpActionResult EmptyTrash()
        {
            var notes =
                noteRepository.FindAll(
                    Specification<Note>.Eval(
                        note => note.User.ID == CurrentLoginUser.ID && note.Deleted == DeleteFlag.MarkDeleted));
            foreach(var note in notes)
            {
                note.Deleted = DeleteFlag.Deleted;
                noteRepository.Update(note);
            }
            RepositoryContext.Commit();
            return this.Ok();
        }

        [WebApiAuthorization]
        [Route("notes/restore")]
        [HttpPost]
        public IHttpActionResult RestoreNote([FromBody] Guid id)
        {
            RequireExistance(n => n.ID == id && n.Deleted == DeleteFlag.MarkDeleted, noteRepository);
            var note = noteRepository.GetByKey(id);
            if (note.User!=CurrentLoginUser)
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            note.Deleted = DeleteFlag.None;
            noteRepository.Update(note);
            RepositoryContext.Commit();
            return this.Ok();
        }

        [WebApiAuthorization]
        [Route("notes/list/{pageNumber:int:min(1)=1}/{pageSize:int=25}")]
        [HttpGet]
        public PagedResult<NoteItemViewModel> GetNoteList(int pageNumber, int pageSize)
        {
            return GetPagedResultByCriteria<Note, NoteItemViewModel>(
                noteRepository,
                pageNumber,
                pageSize,
                "DatePublished",
                SortOrder.Descending,
                "User.ID.Equals(@0) && (!Deleted.HasValue || Deleted.Value == @1)", this.CurrentLoginUser.ID, DeleteFlag.None);
        }

        [WebApiAuthorization]
        [Route("notes/{id:guid}")]
        [HttpGet]
        public NoteViewModel GetNoteByID(Guid id)
        {
            RequireExistance(n => n.ID == id /*&& (!n.Deleted.HasValue || n.Deleted.Value == DeleteFlag.None)*/, noteRepository);
            var note = noteRepository.GetByKey(id);
            if (note.User != CurrentLoginUser)
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            return Mapper.Map<Note, NoteViewModel>(note);
        }

        [WebApiAuthorization]
        [Route("notes/all")]
        [HttpGet]
        [EnableQuery]
        public IQueryable<NoteItemViewModel> GetNoteList()
        {
            return
                noteRepository.FindAll(Specification<Note>.Eval(note => note.User.ID == CurrentLoginUser.ID))
                    .Project()
                    .To<NoteItemViewModel>();
        }
    }
}
