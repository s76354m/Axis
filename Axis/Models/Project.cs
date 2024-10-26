using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProgramManagement.Models;

public class Project
{
    public Project()
    {
        YLines = new HashSet<YLine>();
        Competitors = new HashSet<Competitor>();
        Notes = new HashSet<ProjectNote>();
    }

    public string ProjectId { get; set; }
    public string ProjectType { get; set; }
    public string ProjectDescription { get; set; }
    public string ProjectManager { get; set; }
    public string Analyst { get; set; }
    public string BenchmarkFileId { get; set; }
    public DateTime GoLiveDate { get; set; }
    public DateTime LastEditDate { get; set; }
    public string LastEditMSID { get; set; }
    public int Mileage { get; set; }
    public string NDBLOB { get; set; }
    public string Status { get; set; }
    public string NewMarket { get; set; }
    public bool RefreshInd { get; set; }

    // Navigation properties
    public virtual ICollection<YLine> YLines { get; set; }
    public virtual ICollection<Competitor> Competitors { get; set; }
    public virtual ICollection<ProjectNote> Notes { get; set; }
}
