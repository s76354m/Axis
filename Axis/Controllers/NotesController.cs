using Microsoft.AspNetCore.Mvc;
using ProgramManagement.DataTransferObjects;
using ProgramManagement.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProgramManagement.Models;

namespace ProgramManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        private readonly IMapper _mapper;

        public NotesController(INotesService notesService, IMapper mapper)
        {
            _notesService = notesService;
            _mapper = mapper;
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<ProjectNoteDTO>>> GetNotes(string projectId)
        {
            var notes = await _notesService.GetNotesByProjectId(projectId);
            return Ok(_mapper.Map<IEnumerable<ProjectNoteDTO>>(notes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectNoteDTO>> GetNote(int id)
        {
            var note = await _notesService.GetNoteById(id);
            if (note == null)
                return NotFound();

            return Ok(_mapper.Map<ProjectNoteDTO>(note));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectNoteDTO>> CreateNote(CreateProjectNoteDTO createProjectNoteDTO)
        {
            var note = _mapper.Map<ProjectNote>(createProjectNoteDTO);
            var createdNote = await _notesService.CreateNote(note);
            return CreatedAtAction(nameof(GetNote), new { id = createdNote.NoteId },
                _mapper.Map<ProjectNoteDTO>(createdNote));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectNoteDTO>> UpdateNote(int id, ProjectNoteDTO projectNoteDTO)
        {
            if (id != projectNoteDTO.NoteId)
                return BadRequest();

            var note = _mapper.Map<ProjectNote>(projectNoteDTO);
            var updatedNote = await _notesService.UpdateNote(note);
            return Ok(_mapper.Map<ProjectNoteDTO>(updatedNote));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var result = await _notesService.DeleteNote(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
