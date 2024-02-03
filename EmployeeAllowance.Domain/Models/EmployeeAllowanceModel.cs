using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowance.Domain.Models
{
    public class EmployeeAllowanceModel
    {
        public double EmployeeID { get; set; }
        public double DepartmentID { get; set; }
        public DateTime? Date { get; set; }
        public double? Amount { get; set; }
        public string? Status { get; set; }
    }
}
