using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgramManagement.DataTransferObjects;

public class ProjectDTO
{
    public string ProjectId { get; set; } = string.Empty;
    public string ProjectType { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string ProjectManager { get; set; } = string.Empty;
    public string Analyst { get; set; } = string.Empty;
    public string BenchmarkFileId { get; set; } = string.Empty;
    public DateTime GoLiveDate { get; set; }
    public DateTime LastEditDate { get; set; }
    public string LastEditMSID { get; set; } = string.Empty;
    public string NDBLOB { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string NewMarket { get; set; } = string.Empty;
    public ICollection<YLineDTO> YLines { get; set; } = new List<YLineDTO>();
    public ICollection<CompetitorDTO> Competitors { get; set; } = new List<CompetitorDTO>();
    public ICollection<ProjectNoteDTO> Notes { get; set; } = new List<ProjectNoteDTO>();
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
