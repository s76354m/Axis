using Microsoft.EntityFrameworkCore;
using ProgramManagement.Data;
using ProgramManagement.Models;

namespace ProgramManagement.Services;

public class ProjectService : IProjectService
{
    private readonly ProgramManagementContext _context;
    private readonly ILogger<ProjectService> _logger;

    public ProjectService(ProgramManagementContext context, ILogger<ProjectService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects
            .Include(p => p.YLines)
            .Include(p => p.Competitors)
            .Include(p => p.Notes)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(string id)
    {
        return await _context.Projects
            .Include(p => p.YLines)
            .Include(p => p.Competitors)
            .Include(p => p.Notes)
            .FirstOrDefaultAsync(p => p.ProjectId == id);
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> UpdateProjectAsync(string id, Project project)
    {
        var existingProject = await _context.Projects.FindAsync(id);
        if (existingProject == null)
        {
            throw new KeyNotFoundException($"Project with ID {id} not found");
        }

        _context.Entry(existingProject).CurrentValues.SetValues(project);
        await _context.SaveChangesAsync();
        return existingProject;
    }

    public async Task<bool> DeleteProjectAsync(string id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return false;
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateProjectStatusAsync(string projectId, string newStatus, string msid)
    {
        var project = await _context.Projects.FindAsync(projectId);
        if (project == null)
        {
            return false;
        }

        project.Status = newStatus;
        project.LastEditDate = DateTime.UtcNow;
        project.LastEditMSID = msid;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status)
    {
        return await _context.Projects
            .Where(p => p.Status == status)
            .Include(p => p.YLines)
            .Include(p => p.Competitors)
            .Include(p => p.Notes)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> ProjectExistsAsync(string projectId)
    {
        return await _context.Projects.AnyAsync(p => p.ProjectId == projectId);
    }
}
