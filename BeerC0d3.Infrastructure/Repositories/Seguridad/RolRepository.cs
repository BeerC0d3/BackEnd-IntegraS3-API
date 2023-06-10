using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Interfaces.Seguridad;
using BeerC0d3.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.Seguridad
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(BeerCodeContext context) : base(context)
        {
        }
    }
}
