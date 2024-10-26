using System.ComponentModel.DataAnnotations;

namespace Axis.DataTransferObjects
{
    public class YLineDTO
    {
        public int YLineId { get; set; }
        public string ProjectId { get; set; }
        public string IPANumber { get; set; }
        public string MarketNumber { get; set; }
        public string ProductCode { get; set; }
        public bool IsPreAward { get; set; }
        public bool IsOptional { get; set; }
    }

    
}
