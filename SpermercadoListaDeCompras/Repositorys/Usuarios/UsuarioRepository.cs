using Microsoft.EntityFrameworkCore;
using BusinessLayer.Context;
using Entities.Entity.Models;
using Entities.Interfaces;

namespace Repositorys.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ListaSupermercadoContext _context;
        public UsuarioRepository(ListaSupermercadoContext context)
        {
            _context = context;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public void DeletarUsuario(int id)
        {
            Usuario? usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Usuario? ObtemUsuarioByID(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObtemUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
