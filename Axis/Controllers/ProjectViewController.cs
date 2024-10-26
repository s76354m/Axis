using Microsoft.AspNetCore.Mvc;
using ProgramManagement.Services;
using AutoMapper;
using ProgramManagement.Models;

namespace ProgramManagement.Controllers
{
    public class ProjectViewController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectViewController> _logger;

        public ProjectViewController(
            IProjectService projectService,
            IMapper mapper,
            ILogger<ProjectViewController> logger)
        {
            _projectService = projectService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View(new Project { LastEditDate = DateTime.UtcNow });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    project.LastEditDate = DateTime.UtcNow;
                    project.Status = "New"; // Set default status
                    project.LastEditMSID = User.Identity?.Name ?? "System";
                    
                    await _projectService.CreateProjectAsync(project);
                    TempData["Success"] = "Project created successfully.";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating project");
                    ModelState.AddModelError("", "Error creating project. Please try again.");
                }
            }
            return View(project);
        }

        public async Task<IActionResult> Update(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                // If no ID is provided, show a list of projects to select from
                var projects = await _projectService.GetAllProjectsAsync();
                return View("ProjectList", projects);
            }

            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _projectService.UpdateProjectAsync(id, project);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating project");
                    ModelState.AddModelError("", "Error updating project");
                }
            }
            return View(project);
        }
    }
}
