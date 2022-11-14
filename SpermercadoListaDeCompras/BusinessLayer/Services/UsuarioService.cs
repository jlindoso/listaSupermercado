using Entities.Entity.Models;
using Repositorys.Usuario;
using Repositorys.Interfaces;

namespace BusinessLayer.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepository.AtualizarUsuario(usuario);
        }

        public void DeletarUsuario(int id)
        {
            _usuarioRepository.DeletarUsuario(id);
        }

        public Usuario? ObtemUsuarioByID(int id)
        {
            return _usuarioRepository.ObtemUsuarioByID(id);
        }

        public IEnumerable<Usuario> ObtemUsuarios()
        {
            return _usuarioRepository.ObtemUsuarios();
        }
    }
}
