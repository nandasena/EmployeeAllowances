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
        public EmployeeIntegrationCommandHandler(IEmployeeIntegetionWorkerProcessor integetionWorkerProcessor) {

            _integetionWorkerProcessor = integetionWorkerProcessor;
        }
        public async Task<bool> Handle(EmployeeIntegrationCommand request, CancellationToken cancellationToken)
        {
            try
            {
               await _integetionWorkerProcessor.ImportEmployeeAllowancess();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }
    }
}
