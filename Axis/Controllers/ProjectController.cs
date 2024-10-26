using Microsoft.AspNetCore.Mvc;
using ProgramManagement.DataTransferObjects;
using ProgramManagement.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProgramManagement.Models;

namespace ProgramManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectApiController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;
    private readonly ILogger<ProjectApiController> _logger;

    public ProjectApiController(
        IProjectService projectService,
        IMapper mapper,
        ILogger<ProjectApiController> logger)
    {
        _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Gets all projects
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProjectDTO>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsAsync();
            var projectDtos = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
            return Ok(projectDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all projects");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Gets a specific project by ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProjectDTO), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<ProjectDTO>> GetProject(string id)
    {
        try
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            var projectDto = _mapper.Map<ProjectDTO>(project);
            return Ok(projectDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving project with ID {ProjectId}", id);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Creates a new project
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ProjectDTO), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<ProjectDTO>> CreateProject([FromBody] CreateProjectDTO createProjectDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if project already exists
            if (await _projectService.ProjectExistsAsync(createProjectDto.ProjectId))
            {
                return BadRequest($"Project with ID {createProjectDto.ProjectId} already exists.");
            }

            var project = _mapper.Map<Project>(createProjectDto);
            project.LastEditDate = DateTime.UtcNow;

            var createdProject = await _projectService.CreateProjectAsync(project);
            var projectDto = _mapper.Map<ProjectDTO>(createdProject);

            return CreatedAtAction(
                nameof(GetProject),
                new { id = projectDto.ProjectId },
                projectDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating project");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Updates an existing project
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ProjectDTO), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<ProjectDTO>> UpdateProject(string id, [FromBody] UpdateProjectDTO updateProjectDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updateProjectDto.ProjectId)
            {
                return BadRequest("Project ID in URL does not match Project ID in request body.");
            }

            var project = _mapper.Map<Project>(updateProjectDto);
            var updatedProject = await _projectService.UpdateProjectAsync(id, project);

            if (updatedProject == null)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            var projectDto = _mapper.Map<ProjectDTO>(updatedProject);
            return Ok(projectDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating project with ID {ProjectId}", id);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Deletes a specific project
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> DeleteProject(string id)
    {
        try
        {
            var result = await _projectService.DeleteProjectAsync(id);
            if (!result)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting project with ID {ProjectId}", id);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Gets projects by status
    /// </summary>
    [HttpGet("status/{status}")]
    [ProducesResponseType(typeof(IEnumerable<ProjectDTO>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectsByStatus(string status)
    {
        try
        {
            var projects = await _projectService.GetProjectsByStatusAsync(status);
            var projectDtos = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
            return Ok(projectDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving projects with status {Status}", status);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    /// <summary>
    /// Updates a project's status
    /// </summary>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> UpdateProjectStatus(string id, [FromBody] UpdateStatusDTO updateStatusDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _projectService.UpdateProjectStatusAsync(id, updateStatusDto.NewStatus, updateStatusDto.MSID);
            if (!result)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating status for project with ID {ProjectId}", id);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}
