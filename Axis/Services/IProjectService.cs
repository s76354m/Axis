using Microsoft.EntityFrameworkCore;
using ProgramManagement.Data;
using ProgramManagement.Models;

namespace ProgramManagement.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(string projectId);
    Task<Project> CreateProjectAsync(Project project);
    Task<Project> UpdateProjectAsync(string projectId, Project project);
    Task<bool> DeleteProjectAsync(string projectId);
    Task<bool> ProjectExistsAsync(string projectId);
    Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status);
    Task<bool> UpdateProjectStatusAsync(string projectId, string newStatus, string msid);
}