using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.DataTransferObjects
{
    public class ProjectNoteDTO
    {
        public int NoteId { get; set; }
        public string ProjectId { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime LoadDate { get; set; }
        public DateTime EditDate { get; set; }
        public string OriginalMSID { get; set; } = string.Empty;
        public string LastEditMSID { get; set; } = string.Empty;
    }


}
