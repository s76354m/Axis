using Microsoft.EntityFrameworkCore;
using ProgramManagement.Data;
using ProgramManagement.Models;

namespace ProgramManagement.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project?> GetProjectByIdAsync(string id);
    Task<Project> CreateProjectAsync(Project project);
    Task<Project> UpdateProjectAsync(string id, Project project);
    Task<bool> DeleteProjectAsync(string id);
    Task<bool> UpdateProjectStatusAsync(string projectId, string newStatus, string msid);
    Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status);
    Task<bool> ProjectExistsAsync(string projectId);
}
