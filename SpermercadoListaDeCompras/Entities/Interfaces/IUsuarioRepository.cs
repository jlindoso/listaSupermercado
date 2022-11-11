using Entities.Entity.Models;

namespace Entities.Interfaces
{
    public interface IUsuarioRepository
    {
        public void AdicionarUsuario(Usuario usuario);
        public void AtualizarUsuario(Usuario usuario);
        public void DeletarUsuario(int id);
        public Usuario? ObtemUsuarioByID(int id);
        public IEnumerable<Usuario> ObtemUsuarios();
        public void Save();
    }
}
