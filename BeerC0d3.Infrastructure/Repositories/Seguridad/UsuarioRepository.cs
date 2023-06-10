using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Interfaces.Seguridad;
using BeerC0d3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Seguridad
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BeerCodeContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Usuarios
                        .Include(u => u.Roles)
                        .Include(u => u.RefreshTokens)
                        .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }
        public async Task<Usuario> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios
                                .Include(u => u.Roles)
                                .Include(u => u.RefreshTokens)
                                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<Usuario> GetUsuarioRolAsync(int userId)
        {
            return await _context.Usuarios
                                .Include(u => u.Roles)
                                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
