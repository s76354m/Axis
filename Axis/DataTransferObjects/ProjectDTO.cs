using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.DataTransferObjects;

public class ProjectDTO
{
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
    public ICollection<YLineDTO> YLines { get; set; }
    public ICollection<CompetitorDTO> Competitors { get; set; }
    public ICollection<ProjectNoteDTO> Notes { get; set; }
}

public class CreateProjectDTO
{
    [Required]
    [StringLength(50)]
    public string ProjectId { get; set; }

    [Required]
    [StringLength(50)]
    public string ProjectType { get; set; }

    [StringLength(500)]
    public string ProjectDescription { get; set; }

    [StringLength(100)]
    public string ProjectManager { get; set; }

    [StringLength(100)]
    public string Analyst { get; set; }

    public string BenchmarkFileId { get; set; }

    [Required]
    public DateTime GoLiveDate { get; set; }

    public string NDBLOB { get; set; }

    [Required]
    [StringLength(50)]
    public string Status { get; set; }

    public string NewMarket { get; set; }
}

public class UpdateProjectDTO
{
    [Required]
    public string ProjectId { get; set; }

    [StringLength(500)]
    public string ProjectDescription { get; set; }

    [StringLength(100)]
    public string ProjectManager { get; set; }

    [StringLength(100)]
    public string Analyst { get; set; }

    public string BenchmarkFileId { get; set; }
    public DateTime? GoLiveDate { get; set; }
    public int? Mileage { get; set; }
    public string NDBLOB { get; set; }

    [StringLength(50)]
    public string Status { get; set; }

    public string NewMarket { get; set; }
}

public class UpdateStatusDTO
{
    [Required]
    [StringLength(50)]
    public string NewStatus { get; set; }

    [Required]
    [StringLength(100)]
    public string MSID { get; set; }
}