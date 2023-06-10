using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Seguridad
{
    public class Usuario:BaseEntity
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Username { get; set; }      
        public string Password { get; set; }
        public string Email { get; set; }

        public string FotoUrl { get; set; }

        public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}
