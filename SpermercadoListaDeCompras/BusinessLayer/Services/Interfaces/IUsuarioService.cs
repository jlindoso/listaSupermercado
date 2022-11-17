using BusinessLayer.DTO.UsuarioDTO;
using Entities.Entity.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUsuarioService
    {
        public void AdicionarUsuario(Usuario usuario);
        public void AtualizarUsuario(Usuario usuario);
        public void DeletarUsuario(int id);
        public BuscarUsuarioDTO? ObtemUsuarioByID(int id);
        public Task<IEnumerable<Usuario>> ObtemUsuarios();
    }
}
