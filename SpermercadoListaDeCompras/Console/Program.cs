using BusinessLayer.DAL;
using BusinessLayer.Model;
using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services;
using Newtonsoft.Json;


var random = new Random().Next();

var user = new UsuarioCadastroDTO
{
    Nome = "teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste teste ",
    Email = $"teste{random}@teste.com",
    Senha = "123456"
};


var userRecebido = new UsuarioService().Cadastrar(user);

Console.WriteLine(JsonConvert.SerializeObject(userRecebido));