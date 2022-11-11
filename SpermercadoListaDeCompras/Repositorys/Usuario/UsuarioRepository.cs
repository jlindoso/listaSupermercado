using Microsoft.EntityFrameworkCore;
using BusinessLayer.Context;
using BusinessLayer.DAL.Interfaces;

namespace Repositorys.Usuario
{
    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        private ListaSupermercadoContext context;
        public UsuarioRepository(ListaSupermercadoContext context)
        {
            this.context = context;
        }

        public void AdicionarUsuario(Entities.Entity.Models.Usuario usuario)
        {
            context.Usuarios.Add(usuario);
        }

        public void AtualizarUsuario(Entities.Entity.Models.Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
        }

        public void DeletarUsuario(int id)
        {
            Entities.Entity.Models.Usuario usuario = context.Usuarios.Find(id);
            context.Usuarios.Remove(usuario);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Entities.Entity.Models.Usuario ObtemUsuarioByID(int id)
        {
            return context.Usuarios.Find(id);
        }

        public IEnumerable<Entities.Entity.Models.Usuario> ObtemUsuarios()
        {
            return context.Usuarios.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
