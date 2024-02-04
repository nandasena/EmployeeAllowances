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

        public EmployeeAllowancesRepository(EmployeeAllowancesContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
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

        public async Task<bool> BulkInsertAsync(IEnumerable<EmployeeAllowanceModel> allowanceModels) {

            try
            {
                //dbSet.AddRange(allowanceModels);
                foreach (var item in allowanceModels)
                {
                    await _context.Database.ExecuteSqlRawAsync("ManageEmployeeAllowancesData @p0, @p1, @p2, @p3, @p4", item.EmployeeID, item.DepartmentID, item.Date, item.Amount,item.Status );
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} BulkInsertAsync Method error", typeof(EmployeeAllowancesRepository));
                return false;
            }

        }

    }
}
