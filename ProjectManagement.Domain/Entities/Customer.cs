using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    // Navigation Property
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
