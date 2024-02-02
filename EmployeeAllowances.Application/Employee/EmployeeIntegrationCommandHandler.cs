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
        public async Task<bool> Handle(EmployeeIntegrationCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
