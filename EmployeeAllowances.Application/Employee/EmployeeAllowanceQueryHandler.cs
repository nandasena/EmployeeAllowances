using EmployeeAllowance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowances.Application.Employee
{
    public class EmployeeAllowanceQueryHandler : IRequestHandler<EmployeeAllowanceQuery, IEnumerable<EmployeeAllowanceDto>>
    {
        private readonly IEmployeeAllowancesRepository _employeeAllowancesRepository;
        public EmployeeAllowanceQueryHandler(IEmployeeAllowancesRepository employeeAllowancesRepository)
        {
            _employeeAllowancesRepository = employeeAllowancesRepository;
        }
        public async Task<IEnumerable<EmployeeAllowanceDto>> Handle(EmployeeAllowanceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IList< EmployeeAllowanceDto > employeeAllowances = new List< EmployeeAllowanceDto >();
                IEnumerable<EmployeeAllowanceModel> models = await  _employeeAllowancesRepository.All();
                foreach (EmployeeAllowanceModel item in models)
                {
                    employeeAllowances.Add(new EmployeeAllowanceDto() { 
                    
                        EmployeeID = item.EmployeeID,
                        DepartmentID = item.DepartmentID,
                        Date = item.Date,
                        Amount = item.Amount,
                        Status = item.Status,
                    
                    });
                }
                return employeeAllowances;
            }
            catch (Exception )
            {

                throw;
            }
            
        }
    }
}
