using Entities.Entity.Models;

namespace Repositorys.Interfaces
{
    public interface IUsuarioRepository
    {
        public void AdicionarUsuario(Usuario usuario);
        public void AtualizarUsuario(Usuario usuario);
        public void DeletarUsuario(int id);
        public Usuario? ObtemUsuarioByID(int id);
        public Task<IEnumerable<Usuario>> ObtemUsuarios();
        public Usuario Get(string email, string senha);
        public void Save();
    }
}
