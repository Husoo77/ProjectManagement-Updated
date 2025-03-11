using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public required string ProjectNumber { get; set; } = "P-" + Guid.NewGuid().ToString().Substring(0, 5);
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ProjectManager { get; set; }
        public string? Service { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Not Started";

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
