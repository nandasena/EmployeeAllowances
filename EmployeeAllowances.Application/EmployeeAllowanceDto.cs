using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowances.Application
{
    public class EmployeeAllowanceDto
    {
        public double EmployeeID { get; set; }
        public double DepartmentID { get; set; }
        public DateTime? Date { get; set; }
        public double? Amount { get; set; }
        public string? Status { get; set; }
    }
}
