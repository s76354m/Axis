using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.DataTransferObjects
{
    public class CreateProjectNoteDTO
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public string OriginalMSID { get; set; }
    }
}
