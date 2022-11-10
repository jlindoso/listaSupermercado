using BusinessLayer.Model;
using BusinessLayer.Model.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Usuario? Cadastrar(UsuarioCadastroDTO usuario);
        public Usuario Editar(int id, UsuarioEditarDTO usuario);
        public Usuario Obter(int id);
        public List<Usuario> Listar();
        public Usuario Login(UsuarioLoginDTO usuario);

    }
}
