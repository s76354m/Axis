using System.ComponentModel.DataAnnotations;

namespace Axis.DataTransferObjects
{
    public class UpdateProjectDTO
    {
        [Required]
        public string ProjectId { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectManager { get; set; }
        public string Analyst { get; set; }
        public string BenchmarkFileId { get; set; }
        public DateTime? GoLiveDate { get; set; }
        public int? Mileage { get; set; }
        public string NDBLOB { get; set; }
        public string Status { get; set; }
        public string NewMarket { get; set; }
    }
}
