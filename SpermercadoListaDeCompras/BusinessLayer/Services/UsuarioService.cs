using Entities.Entity.Models;
using Repositorys.Interfaces;
using Repositorys.Context;
using BusinessLayer.Services.Interfaces;
using Repositorys.Repos;

namespace BusinessLayer.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository(new ListaSupermercadoContext());
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

        public async Task<IEnumerable<Usuario>> ObtemUsuarios()
        {
            return await _usuarioRepository.ObtemUsuarios();
        }
    }
}
