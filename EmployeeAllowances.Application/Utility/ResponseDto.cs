using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAllowances.Application.Utility
{

    public class BaseResponseDto
    {
        public Meta Meta { get; set; }

    }

    public class ResponseDto<T> : BaseResponseDto where T : class
    {
        public T Data {  get; set; }
       // public Meta Meta {  get; set; }

    }



}
