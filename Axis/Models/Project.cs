using System;
using System.Collections.Generic;
using System.Numerics;
using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.Models;

public class Project
{
    public Project()
    {
        YLines = new HashSet<YLine>();
        Competitors = new HashSet<Competitor>();
        Notes = new HashSet<ProjectNote>();
    }

    [Required]
    [StringLength(50)]
    [Display(Name = "Project ID")]
    public string ProjectId { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Project Type")]
    public string ProjectType { get; set; }

    [StringLength(500)]
    [Display(Name = "Description")]
    public string ProjectDescription { get; set; }

    [StringLength(100)]
    [Display(Name = "Project Manager")]
    public string ProjectManager { get; set; }

    [StringLength(100)]
    public string Analyst { get; set; }

    [StringLength(100)]
    [Display(Name = "Benchmark File ID")]
    public string BenchmarkFileId { get; set; }

    [Required]
    [Display(Name = "Go Live Date")]
    [DataType(DataType.Date)]
    public DateTime GoLiveDate { get; set; }

    public DateTime LastEditDate { get; set; }
    
    [StringLength(100)]
    public string LastEditMSID { get; set; }

    [Display(Name = "Mileage")]
    public int Mileage { get; set; }

    public string NDBLOB { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; }

    [StringLength(100)]
    [Display(Name = "New Market")]
    public string NewMarket { get; set; }

    [Display(Name = "Refresh Indicator")]
    public bool RefreshInd { get; set; }

    // Navigation properties
    public virtual ICollection<YLine> YLines { get; set; }
    public virtual ICollection<Competitor> Competitors { get; set; }
    public virtual ICollection<ProjectNote> Notes { get; set; }
}
