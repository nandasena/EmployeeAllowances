using EmployeeAllowance.Domain.Models;
using EmployeeAllowances.Application.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowances.Application.Employee
{
    public class EmployeeIntegrationCommandHandler : IRequestHandler<EmployeeIntegrationCommand, bool>
    {

        private readonly IEmployeeIntegetionWorkerProcessor _integetionWorkerProcessor;
        private readonly IEmployeeAllowancesRepository _employeeAllowancesRepository;
        public EmployeeIntegrationCommandHandler(IEmployeeIntegetionWorkerProcessor integetionWorkerProcessor, IEmployeeAllowancesRepository employeeAllowancesRepository) {

            _integetionWorkerProcessor = integetionWorkerProcessor;
            _employeeAllowancesRepository = employeeAllowancesRepository;
        }
        public async Task<bool> Handle(EmployeeIntegrationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<EmployeeAllowanceModel> empallData = await _integetionWorkerProcessor.ImportEmployeeAllowancess();
                await _employeeAllowancesRepository.BulkInsertAsync(empallData);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }
    }
}
