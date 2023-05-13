using ParkingApp_Core;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace ParkingWebApi.Comman
{
    public class ResponseProvier
    {
        public static Response Default()
        {
            var response = new Response
            {
                Message = "Üzgünüz, bir sorun oluştu :("
            };
            return response;
        }

        public static Response ModelState(ValueEnumerable ModelStateValues)
        {
            IEnumerable<string> allErrors = ModelStateValues.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

            var response = new Response
            {
                Message = "Lütfen bilgilerinizi kontrol ediniz",
                Exception = new Error
                {
                    Message = "Model Hatası",
                    ErrorCode = 1111,
                    InnerException = string.Join(", ", allErrors)
                }
            };
            return response;
        }
    }
}
