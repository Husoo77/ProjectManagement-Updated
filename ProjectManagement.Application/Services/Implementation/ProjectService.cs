using ProjectManagement.Application.Common.Interfaces;
using ProjectManagement.Application.Services.Interface;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Implementation;
public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void CreateProject(Project project)
    {
        _unitOfWork.Project.Add(project);
        _unitOfWork.Save();
    }

    public IEnumerable<Project> GetAllProjects()
    {
        return _unitOfWork.Project.GetAll(includeProperties: "Customer");
    }

    public Project GetProjectById(int id)
    {
        return _unitOfWork.Project.Get(u => u.Id == id, includeProperties: "Customer");
    }

    public void UpdateProject(Project project)
    {
        _unitOfWork.Project.Update(project);
        _unitOfWork.Save();
    }
}
