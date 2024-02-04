using EmployeeAllowance.Domain.Models;

namespace EmployeeAllowances.Application.Service
{
    public interface IEmployeeIntegetionWorkerProcessor
    {
        Task<IEnumerable<EmployeeAllowanceModel>> ImportEmployeeAllowancess();
    }
}