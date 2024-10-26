using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.DataTransferObjects
{
    public class CompetitorDTO
    {
        public int CompetitorId { get; set; }
        public string ProjectId { get; set; }
        public string PayorName { get; set; }
        public string Product { get; set; }
        public bool CSPIndicator { get; set; }
        public bool EIIndicator { get; set; }
        public bool MRIndicator { get; set; }
        public string SPCIndicator { get; set; }
    }


}
