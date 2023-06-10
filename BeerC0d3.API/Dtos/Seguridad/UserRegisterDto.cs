using System.ComponentModel.DataAnnotations;

namespace BeerC0d3.API.Dtos.Seguridad
{
    public class UserRegisterDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

       
        public string FotoUrl { get; set; }
    }
}
