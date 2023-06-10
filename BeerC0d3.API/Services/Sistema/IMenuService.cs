using BeerC0d3.API.Dtos.Sistema;

namespace BeerC0d3.API.Services.Sistema
{
    public interface IMenuService
    {
        Task<ICollection<MenuDto>> GetMenuByUser(int userId);
    }
}
