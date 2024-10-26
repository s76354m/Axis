using System;

namespace ProgramManagement.Models;

public class ProjectNote
{
    public int NoteId { get; set; }
    public string ProjectId { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime LoadDate { get; set; }
    public DateTime EditDate { get; set; }
    public string OriginalMSID { get; set; } = string.Empty;
    public string LastEditMSID { get; set; } = string.Empty;

    // Navigation property
    public Project Project { get; set; } = null!;
}
