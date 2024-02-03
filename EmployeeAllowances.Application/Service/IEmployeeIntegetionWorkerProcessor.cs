namespace EmployeeAllowances.Application.Service
{
    public interface IEmployeeIntegetionWorkerProcessor
    {
        Task<bool> ImportEmployeeAllowancess();
    }
}