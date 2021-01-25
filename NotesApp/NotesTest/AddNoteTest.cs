using System;
using NotesApp;
using Xunit;
using Moq;

namespace NotesTest
{
    public class AddNoteTest
    {
        [Fact]
        public void AddNote_CheckExceptionWhenArgumentIsNull_ExceptionWasThrown()
        {
                // Arrange&Act
                var mockS = new Mock<NotesApp.Services.Abstractions.INotesStorage>();
                var mockE = new Mock<NotesApp.Services.Abstractions.INoteEvents>();

                var noteService = new NotesApp.Services.Services.NotesService(mockS.Object,mockE.Object);
       
                var exception = Record.Exception(() => noteService.AddNote(null, 1));
                //Assert
                Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void AddNote_TryToAddNoteAndDisplayMessage_MessageDisplayed()
        {
            var mockS = new Mock<NotesApp.Services.Abstractions.INotesStorage>();
            var mockE = new Mock<NotesApp.Services.Abstractions.INoteEvents>();

            var noteService = new NotesApp.Services.Services.NotesService(mockS.Object, mockE.Object);
            var note = new NotesApp.Services.Models.Note();
            noteService.AddNote(note, 1);
            mockE.Verify(x => x.NotifyAdded(note,1), Times.Once);
        }
        [Fact]/*Not finisihed yet*/
        public void AddNote_TryAddNoteAndDisplayMessage_MessageNotDisplayed()
        {
            var mockS = new Mock<NotesApp.Services.Abstractions.INotesStorage>();
            var mockE = new Mock<NotesApp.Services.Abstractions.INoteEvents>();

            var note = new NotesApp.Services.Models.Note();
            try
            {
                mockS.Setup(x => x.AddNote(note, 2));
                var noteService = new NotesApp.Services.Services.NotesService(mockS.Object, mockE.Object);
                //noteService.AddNote(note,2).Throw
            }
            catch (ArgumentException)
            {
                mockE.Object.NotifyAdded(note, 2);
            }
        }
        [Fact]
        public void DeleteNote_TryDeleteNoteAndDisplayMessage_MessageDisplayed()
        {
            var mockS = new Mock<NotesApp.Services.Abstractions.INotesStorage>();
            var mockE = new Mock<NotesApp.Services.Abstractions.INoteEvents>();
            var note = new NotesApp.Services.Models.Note {Id = Guid.NewGuid() };
            mockS.Setup(x => x.DeleteNote(note.Id)).Returns(true);
            var noteService = new NotesApp.Services.Services.NotesService(mockS.Object, mockE.Object);
            noteService.DeleteNote(note.Id, 2);
            mockE.Verify(x => x.NotifyDeleted(note.Id, 2),Times.Once);
        }
        [Fact]
        public void DeleteNote_TryDeleteNoteAndDisplayMessage_MessageNotDisplayed()
        {
            var mockS = new Mock<NotesApp.Services.Abstractions.INotesStorage>();
            var mockE = new Mock<NotesApp.Services.Abstractions.INoteEvents>();
            var note = new NotesApp.Services.Models.Note { Id = Guid.NewGuid() };
            mockS.Setup(x => x.DeleteNote(note.Id)).Returns(false);
            var noteService = new NotesApp.Services.Services.NotesService(mockS.Object, mockE.Object);
            noteService.DeleteNote(note.Id, 2);
            mockE.Verify(x => x.NotifyDeleted(note.Id, 2), Times.Never);
        }
    }
}
