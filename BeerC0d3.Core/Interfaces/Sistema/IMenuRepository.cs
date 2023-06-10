using BeerC0d3.Core.Entities.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Interfaces.Sistema
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<ICollection<Menu>> GetByRol(string[] roles);
    }
}
