namespace BeerC0d3.API.Dtos.Sistema
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Icono { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }

        public ICollection<MenuDto> MenuHijos { get; set; }
    }
}
