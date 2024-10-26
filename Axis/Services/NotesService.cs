using Microsoft.EntityFrameworkCore;
using ProgramManagement.Data;
using ProgramManagement.Models;

namespace ProgramManagement.Services
{
    public class NotesService : INotesService
    {
        private readonly ProgramManagementContext _context;

        public NotesService(ProgramManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectNote>> GetNotesByProjectId(string projectId)
        {
            return await _context.ProjectNotes
                .Where(n => n.ProjectId == projectId)
                .OrderByDescending(n => n.EditDate)
                .ToListAsync();
        }

        public async Task<ProjectNote> GetNoteById(int noteId)
        {
            return await _context.ProjectNotes.FindAsync(noteId);
        }

        public async Task<ProjectNote> CreateNote(ProjectNote note)
        {
            _context.ProjectNotes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<ProjectNote> UpdateNote(ProjectNote note)
        {
            note.EditDate = DateTime.UtcNow;
            _context.Entry(note).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<bool> DeleteNote(int noteId)
        {
            var note = await _context.ProjectNotes.FindAsync(noteId);
            if (note == null)
                return false;

            _context.ProjectNotes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
