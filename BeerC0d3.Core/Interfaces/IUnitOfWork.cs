using BeerC0d3.Core.Interfaces.chatGPT;
using BeerC0d3.Core.Interfaces.Seguridad;
using BeerC0d3.Core.Interfaces.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRolRepository Roles { get; }
        IUsuarioRepository Usuarios { get; }
        IMenuRepository Menus { get; }
        IPersonaRepository Personas { get; }
        IContextSupportRepository ContextoSoporte { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task<int> SaveAsync();
    }
}
