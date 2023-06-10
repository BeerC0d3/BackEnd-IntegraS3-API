using BeerC0d3.API.Helpers;
using BeerC0d3.Core.Interfaces;
using BeerC0d3.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerC0d3.API.Controllers
{
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork _Iunit;
        public PersonaController(IUnitOfWork Iunit)
        {
            this._Iunit = Iunit;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get()
        {

            var user = new UserClaim(HttpContext).UserID;

            var personas = await _Iunit.Personas.GetAllAsync();

            return Ok(personas);
        }
    }
}
