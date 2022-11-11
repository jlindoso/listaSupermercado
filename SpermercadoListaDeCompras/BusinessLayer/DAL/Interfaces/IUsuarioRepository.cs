using Entities.Entity.Models;

namespace BusinessLayer.DAL.Interfaces
{
    public interface IUsuarioRepository : IDisposable
    {
        IEnumerable<Usuario> ObtemUsuarios();
        Usuario ObtemUsuarioByID(int id);
        void AdicionarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        void AtualizarUsuario(Usuario usuario);
        void Save();
    }
}
