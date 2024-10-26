namespace ProgramManagement.Models;

public class YLine
{
    public int YLineId { get; set; }
    public string ProjectId { get; set; } = string.Empty;
    public string IPANumber { get; set; } = string.Empty;
    public string MarketNumber { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public DateTime LoadDate { get; set; }
    public DateTime EditDate { get; set; }

    // Navigation property
    public Project Project { get; set; } = null!;
}
