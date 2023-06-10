using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Entities.Sistema
{
    public class Catalogo:BaseEntity
    {
        public string Descripcion { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }

        public ICollection<CatalogoDetalle> CatalogoDetalles { get; set; }
      
    }
}
