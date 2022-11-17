using Entities.Entity.Models;
using Repositorys.Interfaces;
using Repositorys.Context;
using BusinessLayer.Services.Interfaces;
using Repositorys.Repos;
using BusinessLayer.DTO.UsuarioDTO;

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

        public BuscarUsuarioDTO? ObtemUsuarioByID(int id)
        {
            Usuario? usuario = _usuarioRepository.ObtemUsuarioByID(id);
            BuscarUsuarioDTO? usuarioBuscado = new(){
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
            };
            return usuarioBuscado;
        }

        public async Task<IEnumerable<Usuario>> ObtemUsuarios()
        {
            return await _usuarioRepository.ObtemUsuarios();
        }
    }
}
