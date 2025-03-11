using ProjectManagement.Application.Common.Interfaces;
using ProjectManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Infrastructure.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public IProjectRepository Project { get; private set; }

    public ICustomerRepository Customer { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Project = new ProjectRepository(_db);
        Customer = new CustomerRepository(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }

}