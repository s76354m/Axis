using System.ComponentModel.DataAnnotations;

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

    [Display(Name = "CSP Indicator")]
    public bool CSPIndicator { get; set; }
    
    [Display(Name = "EI Indicator")]
    public bool EIIndicator { get; set; }
    
    [Display(Name = "MR Indicator")]
    public bool MRIndicator { get; set; }
}
