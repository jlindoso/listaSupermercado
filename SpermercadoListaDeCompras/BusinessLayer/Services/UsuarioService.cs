using BusinessLayer.DAL;
using BusinessLayer.DAL.Interfaces;
using BusinessLayer.Model;
using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUsuarioDAO _usuarioDAO;

        public UsuarioService()
        {
            _usuarioDAO = new UsuarioDAO();
        }

        public Usuario? Cadastrar(UsuarioCadastroDTO usuarioDTO)
        {
            var user = _usuarioDAO.Adicionar(new Usuario
            {
                Email = usuarioDTO.Email,
                Nome = usuarioDTO.Nome,
                Senha = usuarioDTO.Senha
            });
            return user;
        }

        public Usuario Editar(int id, UsuarioEditarDTO usuario)
        {
            var userEdit = Obter(id);
            if (userEdit == null) throw new Exception("O usuário não existe");


            userEdit.Nome = string.IsNullOrEmpty(usuario.Nome) ? userEdit.Nome : usuario.Nome;
            userEdit.Senha = string.IsNullOrEmpty(usuario.Senha) ? userEdit.Senha : usuario.Senha; 
            userEdit.Email = string.IsNullOrEmpty(usuario.Email) || userEdit.Email.ToLower().Equals(usuario.Email.ToLower()) ? null : usuario.Email; 

            return _usuarioDAO.Editar(id, userEdit);
        }


        public void Excluir(int id)
        {
            var userExclude = Obter(id);
            if (userExclude == null) throw new Exception("404");
            
            _usuarioDAO.Excluir(id);
        }

        public List<Usuario> Listar()
        { 
            return _usuarioDAO.Listar();
        }

        public Usuario? Login(UsuarioLoginDTO usuario)
        {
            var user = _usuarioDAO.Login(usuario.Email, usuario.Senha);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public Usuario Obter(int id)
        {
            return _usuarioDAO.Obter(id);
        }
    }
}
