using Microsoft.EntityFrameworkCore;
using ProgramManagement.Data;
using ProgramManagement.Models;

namespace ProgramManagement.Services
{
    public interface INotesService
    {
        Task<IEnumerable<ProjectNote>> GetNotesByProjectId(string projectId);
        Task<ProjectNote> GetNoteById(int noteId);
        Task<ProjectNote> CreateNote(ProjectNote note);
        Task<ProjectNote> UpdateNote(ProjectNote note);
        Task<bool> DeleteNote(int noteId);
    }
}
