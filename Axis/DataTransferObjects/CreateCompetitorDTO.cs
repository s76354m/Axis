using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.DataTransferObjects
{
    public class CreateCompetitorDTO
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string PayorName { get; set; }
        [Required]
        public string Product { get; set; }
        public bool CSPIndicator { get; set; }
        public bool EIIndicator { get; set; }
        public bool MRIndicator { get; set; }
        public string SPCIndicator { get; set; }
    }
}
