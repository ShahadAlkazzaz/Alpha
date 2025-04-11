using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;
using WebApp.Models.Entities;
using WebApp.Services;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
    
        private readonly ProjectService _projectService;
        // AI-genererad kod: Injectar ProjectService enligt Service Pattern för att separera ansvar mellan controller och logiklager
        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("")]
        [Route("projects")]
        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAllAsync();
            ViewBag.AllCount = projects.Count();
            ViewBag.StartedCount = projects.Count(p => p.Status == ProjectStatus.Started);
            ViewBag.CompletedCount = projects.Count(p => p.Status == ProjectStatus.Completed);
            ViewBag.Filter = "ALL";

            var viewModels = projects.Select(p => new ProjectViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ClientName = p.ClientName,
                CreatedAt = p.CreatedAt,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Budget = p.Budget,
                Status = p.Status.ToString()
            });

            return View(viewModels);
        }
        public async Task<IActionResult> Started()
        {
            var allProjects = await _projectService.GetAllAsync();
            var filtered = allProjects.Where(p => p.Status == ProjectStatus.Started);

            ViewBag.AllCount = allProjects.Count();
            ViewBag.StartedCount = filtered.Count();
            ViewBag.CompletedCount = allProjects.Count(p => p.Status == ProjectStatus.Completed);
            ViewBag.Filter = "STARTED";

            var viewModels = filtered.Select(p => new ProjectViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ClientName = p.ClientName,
                CreatedAt = p.CreatedAt,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Budget = p.Budget,
                Status = p.Status.ToString()
            });

            return View("Index", viewModels); // använder samma vy!
        }

        public async Task<IActionResult> Completed()
        {
            var allProjects = await _projectService.GetAllAsync();
            var filtered = allProjects.Where(p => p.Status == ProjectStatus.Completed);

            ViewBag.AllCount = allProjects.Count();
            ViewBag.CompletedCount = filtered.Count();
            ViewBag.StartedCount = allProjects.Count(p => p.Status == ProjectStatus.Started);
            ViewBag.Filter = "COMPLETED";

            var viewModels = filtered.Select(p => new ProjectViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ClientName = p.ClientName,
                CreatedAt = p.CreatedAt,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Budget = p.Budget,
                Status = p.Status.ToString()
            });

            return View("Index", viewModels); // använder samma vy!
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProjectFormModel form)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            var entity = new ProjectEntity
            {
                Title = form.Title,
                Description = form.Description,
                ClientName = form.ClientName,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                Budget = form.Budget,
                Status = form.Status,
                CreatedAt = DateTime.UtcNow
            };


            await _projectService.AddAsync(entity);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProjectFormModel form)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var entity = await _projectService.GetByIdAsync(form.Id);
            if (entity == null)
                return NotFound();

            entity.Title = form.Title;
            entity.Description = form.Description;
            entity.ClientName = form.ClientName;
            entity.StartDate = form.StartDate;
            entity.EndDate = form.EndDate;
            entity.Budget = form.Budget;
            entity.Status = form.Status;

            await _projectService.UpdateAsync(entity);

            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project != null)
            {
                await _projectService.DeleteAsync(project);
            }

            return RedirectToAction("Index");
        }


    }
}
