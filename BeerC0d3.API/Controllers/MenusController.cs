using AutoMapper;
using BeerC0d3.API.Helpers;
using BeerC0d3.API.Services.Sistema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerC0d3.API.Controllers
{
    [Authorize]
    public class MenusController : BaseApiController
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenusController(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get()
        {

            var user = new UserClaim(HttpContext).UserID;

            var menus = await _menuService.GetMenuByUser(user);

            return Ok(menus);
        }
    }
}
