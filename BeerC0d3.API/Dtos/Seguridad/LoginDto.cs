using System.ComponentModel.DataAnnotations;

namespace BeerC0d3.API.Dtos.Seguridad
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
