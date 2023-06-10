using System.Text.Json.Serialization;

namespace BeerC0d3.API.Dtos.chatGPT
{
    public class ContextSupportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string File { get; set; }
      
        public ICollection<ContextSupportDto> ContextSupportChildren { get; set; }

    }
}
