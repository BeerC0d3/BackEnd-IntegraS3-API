using BeerC0d3.API.Dtos.chatGPT;
using BeerC0d3.API.Dtos.Seguridad;
using BeerC0d3.API.Models;

namespace BeerC0d3.API.Services.chatGPT
{
    public interface IChatService
    {
        Task<ChatModelDto> ChatSetup(ChatModelDto model);
        Task<ChatGptResponse> Chat(ChatModelDto model);
        Task<ICollection<ContextSupportDto>> GetContextSupport();
        Task UpdateContextSupport(UpdateContextSupportDto model);
    }
}
