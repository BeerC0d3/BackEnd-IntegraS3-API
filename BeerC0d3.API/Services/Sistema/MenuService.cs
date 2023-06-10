using BeerC0d3.API.Dtos.Sistema;
using BeerC0d3.Core.Entities.Sistema;
using BeerC0d3.Core.Interfaces;

namespace BeerC0d3.API.Services.Sistema
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICollection<MenuDto>> GetMenuByUser(int userId)
        {
            ICollection<MenuDto> menu = new List<MenuDto>();
            //1.obtenemos los roles por usuario
            var user = await _unitOfWork.Usuarios.GetUsuarioRolAsync(userId);
            //2.obtenemos los menus por rol
            string[] roles = user.Roles.Select(item => item.Nombre).ToArray();
            var menus = await _unitOfWork.Menus.GetAllAsync();

            var menuByRol = menus.Where(item => (roles.Any(rol => item.Roles.Contains(rol)) || item.Roles.Equals("*")))
                  .ToList();

            var menuProcesados = CreaMenu(menuByRol);

            return menuProcesados;
        }

        private ICollection<MenuDto> CreaMenu(ICollection<Menu> listMenu)
        {
            ICollection<MenuDto> listMenuDto = new List<MenuDto>();
            Menu menuOrigen = listMenu.Where(item => item.MenuIdPadre == 0).FirstOrDefault();
            if (menuOrigen == null)
                throw new Exception("No se encontró el menú origen.");


            MenuDto mnuDto = new MenuDto();
            mnuDto.Id = menuOrigen.Id;
            mnuDto.Icono = menuOrigen.Icono;
            mnuDto.Titulo = menuOrigen.Titulo;
            mnuDto.Url = menuOrigen.Url;
            mnuDto.MenuHijos = CreaMenu(listMenu, mnuDto.Id);
            listMenuDto.Add(mnuDto);

            return listMenuDto;
        }

        private ICollection<MenuDto> CreaMenu(ICollection<Menu> listMenu, int menuIdPadre)
        {
            ICollection<MenuDto> listMenuDto = new List<MenuDto>();

            List<Menu> listMenuHijos = listMenu.Where(item => item.MenuIdPadre == menuIdPadre).ToList();
            foreach (Menu menuHijo in listMenuHijos)
            {
                MenuDto mnuDto = new MenuDto();
                mnuDto.Id = menuHijo.Id;
                mnuDto.Icono = menuHijo.Icono;
                mnuDto.Titulo = menuHijo.Titulo;
                mnuDto.Url = menuHijo.Url;
                mnuDto.MenuHijos = CreaMenu(listMenu, mnuDto.Id);
                listMenuDto.Add(mnuDto);
            }


            return listMenuDto;

        }
    }
}
