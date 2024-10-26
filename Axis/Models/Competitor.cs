namespace ProgramManagement.Models;

public class Competitor
{
    public int CompetitorId { get; set; }
    public string ProjectId { get; set; } = string.Empty;
    public string PayorName { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public decimal MarketShare { get; set; }
    public decimal Lives { get; set; }
    public string SPCIndicator { get; set; } = string.Empty;
    public DateTime LoadDate { get; set; }

    // Navigation property
    public Project Project { get; set; } = null!;
}
