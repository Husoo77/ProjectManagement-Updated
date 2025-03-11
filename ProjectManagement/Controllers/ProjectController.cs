using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.Application.Services.Interface;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Data;

namespace ProjectManagement.Controllers;
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;
    private readonly ICustomerService _customerService;

    public ProjectController(IProjectService projectService, ICustomerService customerService)
    {
        _projectService = projectService;
        _customerService = customerService;
    }
    public IActionResult Index()
    {
        var projects = _projectService.GetAllProjects();
        return View(projects);
    }

    public IActionResult Create()
    {
        ViewBag.Customers = new SelectList(_customerService.GetAllCustomers(), "Id", "Name");
        return View();
    }
    [HttpPost]
    public IActionResult Create(Project obj)
    {
        ModelState.Remove("Customer");
        if (ModelState.IsValid)
        {
            obj.CreatedDate = DateTime.Now;
            _projectService.CreateProject(obj);
            TempData["success"] = "Projektet har skapats framgångsrikt!";
            return RedirectToAction(nameof(Index));
        }

        TempData["error"] = "Vänligen kontrollera formuläret och försök igen.";
        ViewBag.Customers = new SelectList(_customerService.GetAllCustomers(), "Id", "Name", obj.CustomerId);
        return View(obj);
    }

    public IActionResult Update(int Id)
    {
        Project? obj = _projectService.GetProjectById(Id);
        if (obj == null)
        {
            return RedirectToAction("Error", "Home");
        }
        ViewBag.Customers = new SelectList(_customerService.GetAllCustomers(), "Id", "Name", obj.CustomerId);
        return View(obj);
    }

    [HttpPost]
    public IActionResult Update(Project obj)
    {
        ModelState.Remove("Customer");
        if (ModelState.IsValid && obj.Id > 0)
        {

            _projectService.UpdateProject(obj);
            TempData["success"] = "Projektet har uppdaterats framgångsrikt!";
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public IActionResult Details(int id)
    {
        Project? project = _projectService.GetProjectById(id);

        if (project == null)
        {
            return RedirectToAction("Error", "Home");
        }

        return View(project);
    }

}
