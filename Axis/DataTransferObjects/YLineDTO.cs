using System.ComponentModel.DataAnnotations;
using System;

namespace ProgramManagement.DataTransferObjects
{
    public class YLineDTO
    {
        public int YLineId { get; set; }
        public string ProjectId { get; set; } = string.Empty;
        public string IPANumber { get; set; } = string.Empty;
        public string MarketNumber { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public DateTime LoadDate { get; set; }
        public DateTime EditDate { get; set; }
    }


}
