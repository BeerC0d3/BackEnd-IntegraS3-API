using BeerC0d3.Core.Interfaces;
using BeerC0d3.Core.Interfaces.chatGPT;
using BeerC0d3.Core.Interfaces.Seguridad;
using BeerC0d3.Core.Interfaces.Sistema;
using BeerC0d3.Infrastructure.Data;
using BeerC0d3.Infrastructure.Repositories.chatGPT;
using BeerC0d3.Infrastructure.Repositories.Seguridad;
using BeerC0d3.Infrastructure.Repositories.Sistema;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BeerCodeContext _context;
        private DbContextTransaction _objTran;
        private IUsuarioRepository _usuarios;
        private IMenuRepository _menus;
        private IRolRepository _roles;
        private IPersonaRepository _personas;
        private IContextSupportRepository _contextoSoporte;
        public UnitOfWork(BeerCodeContext context)
        {
            _context = context;
        }

        public IUsuarioRepository Usuarios
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new UsuarioRepository(_context);
                }
                return _usuarios;
            }
        }

        public IMenuRepository Menus
        {
            get
            {
                if (_menus == null)
                {
                    _menus = new MenuRepository(_context);
                }

                return _menus;
            }
        }
        public IRolRepository Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public IPersonaRepository Personas
        {
            get
            {
                if (_personas == null)
                {
                    _personas = new PersonaRepository(_context);
                }
                return _personas;
            }
        }

        public IContextSupportRepository ContextoSoporte
        {
            get
            {
                if (_contextoSoporte == null)
                {
                    _contextoSoporte = new ContextSupportRepository(_context);
                }
                return _contextoSoporte;
            }
        }

        public void CreateTransaction()
        {
            _objTran = (DbContextTransaction)_context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _objTran.Commit();
        }
        public void Rollback()
        {
            _objTran.Rollback();
            //_objTran.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
