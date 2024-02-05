using EmployeeAllowance.Intrastructure;
using EmployeeAllowances.Application.Employee;
using EmployeeAlowances.EmployeeAllowances.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowances.Test
{
    public class EmployeeAllowancesUnitTestController
    {
        private EmployeeAllowancesRepository allowancesRepository;
        public static DbContextOptions<EmployeeAllowancesContext> dbContextOptions { get;}
        public static string cs = "Data Source=CML-SAMITHANAND\\SQL2019;Initial Catalog=EmpolyeeAllowancesTest;Persist Security Info=True;User ID=sa;Password=123;MultipleActiveResultSets=true;TrustServerCertificate=True";
        private readonly EmployeeAllowanceQueryHandler _queryHandler;
        static EmployeeAllowancesUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<EmployeeAllowancesContext>()
            .UseSqlServer(cs)
            .Options;
        }

        public EmployeeAllowancesUnitTestController()
        {
            var context = new EmployeeAllowancesContext(dbContextOptions);
            TestDbDataInitializer db = new TestDbDataInitializer();
            db.Seed(context);

            allowancesRepository = new EmployeeAllowancesRepository(context);

            _queryHandler = new EmployeeAllowanceQueryHandler(allowancesRepository);

        
        }

        [Fact]
        public async void EmployeeAllowance_Check_Count()
        {

            //Arrange  
            var query = new EmployeeAllowanceQuery();

            //Act  
           var actual =  await _queryHandler.Handle(query, default);

            //Assert  
            Assert.Equal(4,actual.Count());
        }
    }
}
