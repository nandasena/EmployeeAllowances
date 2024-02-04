using EmployeeAllowance.Domain.Models;
using IronXL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowances.Application.Service
{
    public class EmployeeIntegetionWorkerProcessor : IEmployeeIntegetionWorkerProcessor
    {
        private readonly IConfiguration _configuration;
        public EmployeeIntegetionWorkerProcessor(IConfiguration configuration) {

            _configuration = configuration;
        }


        public async Task<IEnumerable<EmployeeAllowanceModel>> ImportEmployeeAllowancess()
        {
            DataTable csvFilereader = new DataTable();
            csvFilereader = ReadExcel(_configuration["DataUpload:Path"].ToString());

            IList<EmployeeAllowanceModel> items = new List<EmployeeAllowanceModel>();
            foreach (DataRow row in csvFilereader.Rows)
            {

                EmployeeAllowanceModel santizeddto = new EmployeeAllowanceModel()
                {

                    EmployeeID = await SanitizData<double>(row, "Employee ID "),
                    DepartmentID = await SanitizData<double>(row, "Department ID"),
                    Date = await SanitizDate(row, "Date"),
                    Amount = await SanitizData<double>(row, "Amount"),
                    Status = await SanitizData<string?>(row, "Status"),

                };

                if (santizeddto.EmployeeID != 0)
                {
                    items.Add(santizeddto);
                }
                
            }

            return items;
        }

        private async Task<T> SanitizData<T>(DataRow row,string columnName)
        {
            try
            {
                return row.Field<T>(columnName);
                
            }
            catch (Exception)
            {
                return default;
            }
        }


        private async Task<DateTime?> SanitizDate(DataRow row, string columnName)
        {
            try
            {
                    string strDate = row.Field<string>(columnName);
                    DateTime dateTime = DateTime.Now;
                    if (DateTime.TryParse(strDate, out dateTime))
                    {
                        return dateTime.Date;
                    }
                    else
                    {
                        return null;
                    }

            }
            catch (Exception)
            {
                return null;
            }
        }


        private DataTable ReadExcel(string sheetName)
        {
            WorkBook workbook = WorkBook.Load(sheetName);
          //  Work with a single WorkSheet.
           // you can pass static sheet name like Sheet1 to get that sheet
            //WorkSheet sheet = workbook.GetWorkSheet("Employee Alowances_");
           // You can also use workbook.DefaultWorkSheet to get default in case you want to get first sheet only
            WorkSheet sheet = workbook.DefaultWorkSheet;
               // Convert the worksheet to System.Data.DataTable
               // Boolean parameter sets the first row as column names of your table.
            return sheet.ToDataTable(true);

            }
        }
}
