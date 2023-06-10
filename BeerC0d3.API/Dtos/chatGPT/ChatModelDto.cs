namespace BeerC0d3.API.Dtos.chatGPT
{
    public class ChatModelDto
    {
        public string conversationId { get; set; }
        public string message { get; set; }
        public int contextId { get; set; }
        public string contextFile { get; set; }
    }
}
