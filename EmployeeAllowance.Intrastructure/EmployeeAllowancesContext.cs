using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAllowance.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAllowance.Intrastructure
{
    public class EmployeeAllowancesContext : DbContext
    {
        public DbSet<EmployeeAllowanceModel> EmployeeAllowances { get; set; }

        public EmployeeAllowancesContext(DbContextOptions<EmployeeAllowancesContext> options) : base(options) { }
    }
}
