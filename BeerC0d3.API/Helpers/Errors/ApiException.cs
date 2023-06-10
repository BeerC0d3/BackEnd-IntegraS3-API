//using BeerSoft.API.Helpers.Errors;

namespace BeerC0d3.API.Helpers.Errors;
public class ApiException : ApiResponse
{
    public ApiException(int statusCode, string message = null,string details=null) 
                    : base(statusCode, message)
    {
        Details = details;
    }

    public string Details { get; set; }
}
