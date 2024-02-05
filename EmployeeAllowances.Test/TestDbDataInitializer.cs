using EmployeeAllowance.Domain.Models;
using EmployeeAllowance.Intrastructure;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowances.Test
{
    public class TestDbDataInitializer
    {
        public TestDbDataInitializer() { }

        public void Seed(EmployeeAllowancesContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.EmployeeAllowances.AddRange(
                new EmployeeAllowanceModel() { EmployeeID = 99, DepartmentID= 1, Amount = 2000, Date = DateTime.Now.Date ,Status= "Approved" },
                new EmployeeAllowanceModel() { EmployeeID = 101, DepartmentID = 1, Amount = 2000, Date = DateTime.Now.Date, Status = "Approved" },
                new EmployeeAllowanceModel() { EmployeeID = 102, DepartmentID = 1, Amount = 2000, Date = DateTime.Now.Date, Status = "Approved" },
                new EmployeeAllowanceModel() { EmployeeID = 103, DepartmentID = 1, Amount = 2000, Date = DateTime.Now.Date, Status = "Approved" }
            );
            context.SaveChanges();
        }
    }
}
