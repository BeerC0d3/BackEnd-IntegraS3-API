using BeerC0d3.Core.Entities.chatGPT;
using BeerC0d3.Core.Interfaces.chatGPT;
using BeerC0d3.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories.chatGPT
{
    public class ContextSupportRepository : GenericRepository<ContextSupport>,IContextSupportRepository
    {
        public ContextSupportRepository(BeerCodeContext context):base(context) { 
        
        }
    }
}
