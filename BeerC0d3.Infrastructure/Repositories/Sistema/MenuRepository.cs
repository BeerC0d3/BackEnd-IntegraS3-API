using BeerC0d3.Core.Entities.Sistema;
using BeerC0d3.Core.Interfaces.Sistema;
using BeerC0d3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Sistema
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(BeerCodeContext context) : base(context)
        {

        }

        public async Task<ICollection<Menu>> GetByRol(string[] roles)
        {

            return await _context.Menus
                .Where(x => roles.Any(rol => x.Roles.ToLower().Contains(rol))).ToListAsync();
        }
    }
}
