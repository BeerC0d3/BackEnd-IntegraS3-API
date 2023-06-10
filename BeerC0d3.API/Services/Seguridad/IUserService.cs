using BeerC0d3.API.Dtos.Seguridad;

namespace BeerC0d3.API.Services.Seguridad
{
    public interface IUserService
    {
        Task<string> RegisterAsync(UserRegisterDto model);
        Task<DatosUsuarioDto> GetTokenAsync(LoginDto model);
        //Task<UsuarioInfoDto> GetInfoUsuario(int id);
        //Task<string> AddRoleAsync(AddRoleDto model);
        Task<DatosUsuarioDto> RefreshTokenAsync(string refreshToken);
    }
}
