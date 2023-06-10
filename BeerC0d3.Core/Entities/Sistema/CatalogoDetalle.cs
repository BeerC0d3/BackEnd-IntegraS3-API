


namespace BeerC0d3.Core.Entities.Sistema
{
    public class CatalogoDetalle : BaseEntity
    {
        public int CatId { get; set; }
        public Catalogo Catalogo { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechAlta { get; set; }

    }
}
