using EmployeeAllowance.Domain.Models;

namespace EmployeeAllowances.Application
{
    public interface IEmployeeAllowancesRepository
    {
        Task<IEnumerable<EmployeeAllowanceModel>> All();

        Task<bool> BulkInsertAsync(IEnumerable<EmployeeAllowanceModel> allowanceModels);
    }
}