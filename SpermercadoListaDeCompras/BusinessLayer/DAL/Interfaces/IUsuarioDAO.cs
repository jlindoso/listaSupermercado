using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL.Interfaces
{
    public interface IUsuarioDAO
    {
        public List<Usuario> Listar();
        public Usuario? Obter(int id);
        public Usuario Editar(int id, Usuario usuario);
        public void Excluir(int id);
        public Usuario Adicionar(Usuario usuario);
        public Usuario? Login(string email, string senha);
    }
}
