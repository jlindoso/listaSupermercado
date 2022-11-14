using Entities.Entity.Models;

namespace BusinessLayer.Services
{
    public interface IUsuarioService
    {
        public void AdicionarUsuario(Usuario usuario);
        public void AtualizarUsuario(Usuario usuario);
        public void DeletarUsuario(int id);
        public Usuario? ObtemUsuarioByID(int id);
        public IEnumerable<Usuario> ObtemUsuarios();
    }
}
