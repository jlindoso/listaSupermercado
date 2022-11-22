using Microsoft.EntityFrameworkCore;
using Entities.Entity.Models;
using Repositorys.Context;
using Repositorys.Interfaces;

namespace Repositorys.Repos
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
            _context.SaveChanges();
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            Usuario? usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
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

        public async Task<IEnumerable<Usuario>> ObtemUsuarios()
        {
            return await _context.Usuarios.Take(10).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Usuario? Get(string email, string senha)
        {
            return _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower() && x.Senha == senha).FirstOrDefault();
        }
    }
}
