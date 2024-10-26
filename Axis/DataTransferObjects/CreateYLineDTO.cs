using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.DataTransferObjects
{
    public class CreateYLineDTO
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string IPANumber { get; set; }
        [Required]
        public string MarketNumber { get; set; }
        [Required]
        public string ProductCode { get; set; }
        public bool IsPreAward { get; set; }
        public bool IsOptional { get; set; }
    }
}
