

namespace CloudNotes.WebAPI.Controllers
{
    using Apworks;
    using Apworks.Repositories;
    using Apworks.Specifications;
    using Apworks.Storage;
    using AutoMapper;
    using CloudNotes.Domain.Model;
    using CloudNotes.ViewModels;
    using CloudNotes.WebAPI.Models.Exceptions;
    using CloudNotes.WebAPI.Models.Filters;
    using CloudNotes.WebAPI.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.OData;

    /// <summary>
    /// Represents the controller that provides Notes APIs.
    /// </summary>
    [RoutePrefix("api")]
    [WebApiLogging]
    public class NotesController : WebApiController
    {
        #region Private Fields

        private readonly IRepository<Note> noteRepository;

        #endregion

        #region Ctor

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

        #endregion

        #region Public APIs

        /// <summary>
        /// Creates a note based on the given model.
        /// </summary>
        /// <param name="viewModel">The model which contains the information of the note that is going
        /// to be created.</param>
        /// <returns>HTTP 200 with the newly created note ID.</returns>
        [WebApiAuthorization]
        [Route("notes/create")]
        [HttpPost]
        public IHttpActionResult CreateNote([FromBody] CreateNoteViewModel viewModel)
        {
            var note = Mapper.Map<CreateNoteViewModel, Note>(viewModel);
            note.User = this.CurrentLoginUser;
            this.noteRepository.Add(note);
            this.RepositoryContext.Commit();
            return this.Ok(note.ID);
        }

        /// <summary>
        /// Updates a note based on the given update model.
        /// </summary>
        /// <param name="viewModel">The model which contains the information of the note that is going
        /// to be updated.</param>
        /// <returns>HTTP 200.</returns>
        [WebApiAuthorization]
        [Route("notes/update")]
        [HttpPost]
        public IHttpActionResult UpdateNote([FromBody] UpdateNoteViewModel viewModel)
        {
            var note = this.noteRepository.GetByKey(viewModel.ID);
            if (note != null) note = Mapper.Map(viewModel, note);
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        /// Marks the specified note as deleted, so that the note will be shown in
        /// user's trash bin.
        /// </summary>
        /// <param name="id">The ID of the note that is going to be marked as deleted.</param>
        /// <returns>HTTP 200.</returns>
        [WebApiAuthorization]
        [Route("notes/markdelete")]
        [HttpPost]
        public IHttpActionResult MarkDelete([FromBody] Guid id)
        {
            this.RequireExistance(n => n.ID == id, this.noteRepository);
            var note = this.noteRepository.GetByKey(id);
            if (note.User != this.CurrentLoginUser)
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            note.Deleted = DeleteFlag.MarkDeleted;
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        /// Deletes the note by using the given note ID.
        /// </summary>
        /// <param name="id">The identifier of the note to be deleted.</param>
        /// <returns>HTTP 200.</returns>
        /// <exception cref="InsufficientPriviledgeException"></exception>
        [WebApiAuthorization]
        [Route("notes/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteNote(Guid id)
        {
            this.RequireExistance(n => n.ID == id, this.noteRepository);
            var note = this.noteRepository.GetByKey(id);
            if (note.User != this.CurrentLoginUser)
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            note.Deleted = DeleteFlag.Deleted;
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        /// Empties the trash bin for the currently login user.
        /// </summary>
        /// <returns>HTTP 200.</returns>
        [WebApiAuthorization]
        [Route("notes/emptytrash")]
        [HttpDelete]
        public IHttpActionResult EmptyTrash()
        {
            var notes = this.noteRepository.FindAll(
                Specification<Note>.Eval(
                    note => note.User.ID == this.CurrentLoginUser.ID && note.Deleted == DeleteFlag.MarkDeleted));
            foreach (var note in notes)
            {
                note.Deleted = DeleteFlag.Deleted;
                this.noteRepository.Update(note);
            }
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        /// Restores a note from the trash bin.
        /// </summary>
        /// <param name="id">The ID of the note to be restored.</param>
        /// <returns>HTTP 200.</returns>
        [WebApiAuthorization]
        [Route("notes/restore")]
        [HttpPost]
        public IHttpActionResult RestoreNote([FromBody] Guid id)
        {
            this.RequireExistance(n => n.ID == id && n.Deleted == DeleteFlag.MarkDeleted, this.noteRepository);
            var note = this.noteRepository.GetByKey(id);
            if (note.User != this.CurrentLoginUser)
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            note.Deleted = DeleteFlag.None;
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        /// Gets a list of notes for currently login user with pagination enabled.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of notes per page.</param>
        /// <returns>HTTP 200, with the note list.</returns>
        [WebApiAuthorization]
        [Route("notes/list/{pageNumber:int:min(1)=1}/{pageSize:int=25}")]
        [HttpGet]
        public PagedResult<NoteItemViewModel> GetNoteList(int pageNumber, int pageSize)
        {
            return this.GetPagedResultByCriteria<Note, NoteItemViewModel>(this.noteRepository,
                pageNumber,
                pageSize,
                "DatePublished",
                SortOrder.Descending,
                "User.ID.Equals(@0) && (!Deleted.HasValue || Deleted.Value == @1)", this.CurrentLoginUser.ID,
                DeleteFlag.None);
        }

        /// <summary>
        /// Gets the note with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the note to be retrieved.</param>
        /// <returns></returns>
        [WebApiAuthorization]
        [Route("notes/{id:guid}")]
        [HttpGet]
        // ReSharper disable InconsistentNaming
        public NoteViewModel GetNoteByID(Guid id)
            // ReSharper restore InconsistentNaming
        {
            this.RequireExistance(n => n.ID == id /*&& (!n.Deleted.HasValue || n.Deleted.Value == DeleteFlag.None)*/,
                this.noteRepository);
            var note = this.noteRepository.GetByKey(id);
            if (note.User != this.CurrentLoginUser)
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            return Mapper.Map<Note, NoteViewModel>(note);
        }

        /// <summary>
        /// Gets all the notes for the currently login user.
        /// </summary>
        /// <returns>HTTP 200, with a list of notes.</returns>
        [WebApiAuthorization]
        [Route("notes/all")]
        [HttpGet]
        [EnableQuery]
        public IQueryable<NoteItemViewModel> GetNoteList()
        {
            //return
            //    this.noteRepository.FindAll(Specification<Note>.Eval(note => note.User.ID == this.CurrentLoginUser.ID))
            //        .Project()
            //        .To<NoteItemViewModel>();
            var notes =
                this.noteRepository.FindAll(Specification<Note>.Eval(note => note.User.ID == this.CurrentLoginUser.ID));
            var list = new List<NoteItemViewModel>();
            foreach (var note in notes)
            {
                list.Add(Mapper.Map<Note, NoteItemViewModel>(note));
            }
            return list.AsQueryable();
        }

        #endregion
    }
}