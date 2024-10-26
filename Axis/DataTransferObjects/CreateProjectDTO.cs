using System.ComponentModel.DataAnnotations;

namespace Axis.DataTransferObjects
{
    public class CreateProjectDTO
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string ProjectType { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectManager { get; set; }
        public string Analyst { get; set; }
        public string BenchmarkFileId { get; set; }
        public DateTime GoLiveDate { get; set; }
        public string NDBLOB { get; set; }
        [Required]
        public string Status { get; set; }
        public string NewMarket { get; set; }
    }
}
