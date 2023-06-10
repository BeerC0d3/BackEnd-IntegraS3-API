using BeerC0d3.Core.Entities.chatGPT;
using BeerC0d3.Core.Interfaces;
using BeerC0d3.Core.Interfaces.chatGPT;
using BeerC0d3.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.chatGPT
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(BeerCodeContext context):base(context)
        {

        }
    }
}
