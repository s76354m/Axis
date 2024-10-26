using System;

namespace ProgramManagement.Models;

public class ProjectNote
{
    public int NoteId { get; set; }
    public string ProjectId { get; set; }
    public string Category { get; set; }
    public string Notes { get; set; }
    public DateTime LoadDate { get; set; }
    public DateTime EditDate { get; set; }
    public string OriginalMSID { get; set; }
    public string LastEditMSID { get; set; }

    // Navigation property
    public virtual Project Project { get; set; }
}
