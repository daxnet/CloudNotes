//  =======================================================================================================
// 
//     ,uEZGZX  LG                             Eu       iJ       vi                                              
//    BB7.  .:  uM                             8F       0BN      Bq             S:                               
//   @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
//  ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
//  v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
//  .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//   @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//    ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//      iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
// 
// 
//  Copyright 2014-2015 daxnet
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  =======================================================================================================

namespace CloudNotes.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.OData;
    using Apworks;
    using Apworks.Repositories;
    using Apworks.Specifications;
    using Apworks.Storage;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CloudNotes.Domain.Model;
    using CloudNotes.ViewModels;
    using CloudNotes.WebAPI.Models.Exceptions;
    using CloudNotes.WebAPI.Models.Filters;
    using CloudNotes.WebAPI.Properties;

    /// <summary>
    ///     Represents the controller that provides Notes APIs.
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
        ///     Initializes a new instance of the <see cref="NotesController" /> class.
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
        ///     Creates a note based on the given model.
        /// </summary>
        /// <param name="viewModel">
        ///     The model which contains the information of the note that is going
        ///     to be created.
        /// </param>
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
        ///     Updates a note based on the given update model.
        /// </summary>
        /// <param name="viewModel">
        ///     The model which contains the information of the note that is going
        ///     to be updated.
        /// </param>
        /// <returns>HTTP 200.</returns>
        [WebApiAuthorization]
        [Route("notes/update")]
        [HttpPost]
        public IHttpActionResult UpdateNote([FromBody] UpdateNoteViewModel viewModel)
        {
            var note = this.noteRepository.GetByKey(viewModel.ID);
            if (note != null)
            {
                note = Mapper.Map(viewModel, note);
            }
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        ///     Marks the specified note as deleted, so that the note will be shown in
        ///     user's trash bin.
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
            {
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            }
            note.Deleted = DeleteFlag.MarkDeleted;
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        ///     Deletes the note by using the given note ID.
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
            {
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            }
            note.Deleted = DeleteFlag.Deleted;
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        ///     Empties the trash bin for the currently login user.
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
        ///     Restores a note from the trash bin.
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
            {
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            }
            note.Deleted = DeleteFlag.None;
            this.noteRepository.Update(note);
            this.RepositoryContext.Commit();
            return this.Ok();
        }

        /// <summary>
        ///     Gets a list of notes for currently login user with pagination enabled.
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
        ///     Gets the note with the specified ID.
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
            {
                throw new InsufficientPriviledgeException(Resources.InsufficientPriviledgeError);
            }
            return Mapper.Map<Note, NoteViewModel>(note);
        }

        /// <summary>
        ///     Gets all the notes for the currently login user.
        /// </summary>
        /// <returns>HTTP 200, with a list of notes.</returns>
        [WebApiAuthorization]
        [Route("notes/all")]
        [HttpGet]
        [EnableQuery]
        public IQueryable<NoteItemViewModel> GetNoteList()
        {
            return
                this.noteRepository.FindAll(Specification<Note>.Eval(note => note.User.ID == this.CurrentLoginUser.ID))
                    .Project()
                    .To<NoteItemViewModel>();
        }

        /// <summary>
        ///     Gets the revisions of all the notes for the current login user.
        /// </summary>
        /// <returns>A list of objects that contains the note ID and revision data.</returns>
        [WebApiAuthorization]
        [Route("notes/revisions")]
        [HttpGet]
        public IHttpActionResult GetRevisions()
        {
            return this.Ok(
                this.noteRepository.FindAll(Specification<Note>.Eval(note => note.User.ID == this.CurrentLoginUser.ID))
                    .Select(note => new {note.ID, note.Revision}));
        }

        #endregion
    }
}