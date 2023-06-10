
namespace BeerC0d3.API.Helpers.Errors;
public class ApiValidation:ApiResponse
{
    public ApiValidation():base(400)
    {

    }

    public IEnumerable<string> Errors { get; set; }

}
