using EmployeeAllowances.Application.Utility;

namespace EmployeeAllowances.API.Utility
{
    public class ResponceHandler
    {
        public static ResponseDto<T> ResponceCreator<T>(T data, Meta meta) where T : class
        {
            return new ResponseDto<T>()
            {
                Data = data,
                Meta = meta
            };
        }

        public static BaseResponseDto CreatedResult(Meta meta)
        {
            return new BaseResponseDto()
            {
                Meta = meta
            };
        }
    }
}
