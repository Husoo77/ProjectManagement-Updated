using ProjectManagement.Application.Common.Interfaces;
using ProjectManagement.Application.Services.Interface;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Implementation;
public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<Customer> GetAllCustomers()
    {
        return _unitOfWork.Customer.GetAll();
    }
}
