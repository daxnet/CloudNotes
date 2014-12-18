using Apworks.Repositories;
using CloudNotes.Domain.Model;
using CloudNotes.ViewModels;
using CloudNotes.WebAPI.Controllers;
using CloudNotes.WebAPI.Models.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudNotes.Tests
{
    /// <summary>
    /// Represents the tests for the <see cref="NotesController"/>.
    /// </summary>
    [TestClass]
    public class NotesControllerTests : ControllerTests
    {
        private readonly List<Note> notes = new List<Note>();

        private Guid guid1;

        private Guid guid2;

        private Mock<IRepository<Note>> mockNoteRepository;

        [TestInitialize]
        public void Initialization()
        {
            guid1 = Guid.NewGuid();
            guid2 = Guid.NewGuid();

            notes.Clear();
            notes.Add(
                new Note
                    {
                        ID = guid1,
                        User = CurrentLoginUser,
                        Title = "111",
                        Content = "test1",
                        DatePublished = DateTime.UtcNow,
                        Weather = Weather.Cloudy
                    });
            notes.Add(
                new Note
                    {
                        ID = guid2,
                        User = CurrentLoginUser,
                        Title = "222",
                        Content = "test2",
                        DatePublished = DateTime.UtcNow,
                        Weather = Weather.Sunny
                    });

            mockNoteRepository = this.CreateMockRepository(
                n => notes.Add(n), 
                n => notes.Remove(n), 
                n =>
                    {
                        foreach (var note in notes)
                            if (note.ID == n.ID)
                            {
                                note.Title = n.Title;
                                note.Content = n.Content;
                                note.DateLastModified = n.DateLastModified;
                                note.DatePublished = n.DatePublished;
                                note.Encrypted = n.Encrypted;
                                note.ID = n.ID;
                                note.User = n.User;
                                note.Weather = n.Weather;
                            }
                    }, 
                spec => notes.FirstOrDefault(spec.GetExpression().Compile()) != null, 
                spec => notes.FirstOrDefault(spec.GetExpression().Compile()), 
                key => notes.First(n => n.ID == (Guid)key));

        }

        [TestMethod]
        public void CreateNoteTest()
        {
            var notesController = new NotesController(MockRepositoryContext.Object, mockNoteRepository.Object);
            var createNoteViewModel = new CreateNoteViewModel
                                          {
                                              Content = "Test Content",
                                              Title = "Test",
                                              Weather = "Sunny"
                                          };
            notesController.CreateNote(createNoteViewModel);
            Assert.AreEqual(3, notes.Count);
            Assert.IsNotNull(notes[0].User);
            Assert.AreEqual(CurrentLoginUser, notes[0].User);
        }

        [TestMethod]
        public void UpdateNoteTest()
        {
            var updateViewModel = new UpdateNoteViewModel
                                      {
                                          Content = "updated",
                                          ID = guid2,
                                          Title = "updated title",
                                          Weather = "Foggy"
                                      };

            var notesController = new NotesController(MockRepositoryContext.Object, mockNoteRepository.Object);
            notesController.UpdateNote(updateViewModel);

            Assert.AreEqual(updateViewModel.Content, notes[1].Content);
            Assert.AreEqual(guid2, notes[1].ID);
            Assert.AreEqual(updateViewModel.Title, notes[1].Title);
            Assert.AreEqual(Weather.Foggy, notes[1].Weather);
        }

        [TestMethod]
        public void MarkDeleteTest()
        {
            var notesController = new NotesController(MockRepositoryContext.Object, mockNoteRepository.Object);
            notesController.MarkDelete(guid1);
            Assert.AreEqual(DeleteFlag.MarkDeleted, notes[0].Deleted);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientPriviledgeException))]
        public void MarkDeleteWithInvalidUserTest()
        {
            var user = new User { ID = Guid.NewGuid(), UserName = "acqy", Password = "123" };
            this.InjectLoginUser(user);
            var notesController = new NotesController(MockRepositoryContext.Object, mockNoteRepository.Object);
            notesController.MarkDelete(guid1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var notesController = new NotesController(MockRepositoryContext.Object, mockNoteRepository.Object);
            notesController.DeleteNote(guid2);
            Assert.AreEqual(DeleteFlag.Deleted, notes[1].Deleted);
        }
    }
}
