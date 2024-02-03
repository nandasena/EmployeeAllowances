using EmployeeAllowance.Domain.Models;
using EmployeeAllowances.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowance.Intrastructure
{
    public class EmployeeAllowancesRepository: IEmployeeAllowancesRepository
    {

        protected EmployeeAllowancesContext _context;

        protected DbSet<EmployeeAllowanceModel> dbSet;

        protected readonly ILogger _logger;

        public EmployeeAllowancesRepository(EmployeeAllowancesContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = context.Set<EmployeeAllowanceModel>();
        }

        public async Task<IEnumerable<EmployeeAllowanceModel>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All Method error", typeof(EmployeeAllowancesRepository));
                return new List<EmployeeAllowanceModel>();
            }
        }

    }
}
