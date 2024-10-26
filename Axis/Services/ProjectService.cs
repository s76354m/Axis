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
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        try
        {
            return await _context.Projects
                .Include(p => p.YLines)
                .Include(p => p.Competitors)
                .Include(p => p.Notes)
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all projects");
            throw;
        }
    }

    public async Task<Project> GetProjectByIdAsync(string projectId)
    {
        try
        {
            var project = await _context.Projects
                .Include(p => p.YLines)
                .Include(p => p.Competitors)
                .Include(p => p.Notes)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);

            if (project == null)
            {
                _logger.LogWarning("Project with ID {ProjectId} was not found", projectId);
                return null;
            }

            return project;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving project with ID {ProjectId}", projectId);
            throw;
        }
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        if (project == null)
        {
            throw new ArgumentNullException(nameof(project));
        }

        try
        {
            project.LastEditDate = DateTime.UtcNow;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating project with ID {ProjectId}", project.ProjectId);
            throw;
        }
    }

    public async Task<Project> UpdateProjectAsync(string projectId, Project project)
    {
        if (project == null)
        {
            throw new ArgumentNullException(nameof(project));
        }

        if (projectId != project.ProjectId)
        {
            throw new ArgumentException("Project ID mismatch");
        }

        try
        {
            var existingProject = await _context.Projects.FindAsync(projectId);
            if (existingProject == null)
            {
                _logger.LogWarning("Project with ID {ProjectId} was not found for update", projectId);
                return null;
            }

            // Update the properties
            existingProject.ProjectType = project.ProjectType;
            existingProject.ProjectDescription = project.ProjectDescription;
            existingProject.ProjectManager = project.ProjectManager;
            existingProject.Analyst = project.Analyst;
            existingProject.BenchmarkFileId = project.BenchmarkFileId;
            existingProject.GoLiveDate = project.GoLiveDate;
            existingProject.LastEditDate = DateTime.UtcNow;
            existingProject.LastEditMSID = project.LastEditMSID;
            existingProject.Mileage = project.Mileage;
            existingProject.NDBLOB = project.NDBLOB;
            existingProject.Status = project.Status;
            existingProject.NewMarket = project.NewMarket;
            existingProject.RefreshInd = project.RefreshInd;

            await _context.SaveChangesAsync();
            return existingProject;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, "Concurrency error occurred while updating project with ID {ProjectId}", projectId);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating project with ID {ProjectId}", projectId);
            throw;
        }
    }

    public async Task<bool> DeleteProjectAsync(string projectId)
    {
        try
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null)
            {
                _logger.LogWarning("Project with ID {ProjectId} was not found for deletion", projectId);
                return false;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting project with ID {ProjectId}", projectId);
            throw;
        }
    }

    public async Task<bool> ProjectExistsAsync(string projectId)
    {
        try
        {
            return await _context.Projects.AnyAsync(p => p.ProjectId == projectId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while checking existence of project with ID {ProjectId}", projectId);
            throw;
        }
    }

    public async Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status)
    {
        try
        {
            return await _context.Projects
                .Where(p => p.Status == status)
                .Include(p => p.YLines)
                .Include(p => p.Competitors)
                .Include(p => p.Notes)
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving projects with status {Status}", status);
            throw;
        }
    }

    public async Task<bool> UpdateProjectStatusAsync(string projectId, string newStatus, string msid)
    {
        try
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null)
            {
                _logger.LogWarning("Project with ID {ProjectId} was not found for status update", projectId);
                return false;
            }

            project.Status = newStatus;
            project.LastEditDate = DateTime.UtcNow;
            project.LastEditMSID = msid;

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating status for project with ID {ProjectId}", projectId);
            throw;
        }
    }
}