using BusinessLayer.DAL;
using BusinessLayer.Model;
using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services;
using Newtonsoft.Json;




int x = 12000;

for(int i= 0; i<90000; i++)
{
    var user = new UsuarioCadastroDTO
    {
        Nome = $"teste {x}",
        Email = $"teste{x}@teste.com",
        Senha = "123456"
    };
    var userRecebido = new UsuarioService().Cadastrar(user);
    x++;
}

Console.WriteLine("terminou");