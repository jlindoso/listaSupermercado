using API.Services;
using BusinessLayer.DTO;
using BusinessLayer.DTO.UsuarioDTO;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController()
        {
            _usuarioService = new UsuarioService();
        }

        /// <summary>Retorna todos os usuários</summary>
        /// <response code="200">Retorna uma lista com os usuários cadastrados</response>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return Ok(_usuarioService.ObtemUsuarios().Result);
        }

        /// <summary>Retorna um usuário pelo seu id</summary>
        /// <response code="200">Retorna usuário que foi informado o id</response>
        [HttpGet("id")]
        public BuscarUsuarioDTO? Get([FromQuery] int id)
        {
            BuscarUsuarioDTO? usuario = _usuarioService.ObtemUsuarioByID(id);
            return usuario;
        }

        /// <summary>Cria um novo usuário</summary>
        /// <response code="200">Retorna o usuário que foi criado com sucesso</response>
        [HttpPost]
        public ActionResult Create([Bind(include: "Nome, Email, Senha")] Usuario usuario)
        {
            _usuarioService.AdicionarUsuario(usuario);
            return Created("Usuário criado com sucesso", usuario);
        }

        /// <summary>Deleta um usuário por seu id</summary>
        /// <response code="200">Retorna que o usuário, que foi informado o id, foi deletado com sucesso</response>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            _usuarioService.DeletarUsuario(id);
            return Ok("Usuario excluido com sucesso!");
        }

        /// <summary>Atualiza um usuário</summary>
        /// <response code="200">Retorna que o usuário, que foi informado o id, foi atualizado com sucesso</response>
        [HttpPut]
        public ActionResult Edit([Bind(include: "Nome, Email, Senha")] Usuario usuario)
        {
            _usuarioService.AtualizarUsuario(usuario);
            return Ok("Usuário atualizado com Sucesso");
        }

        /// <summary>Obtêm um token de autenticação de usuário</summary>
        /// <response code="200">Retorna o token de autentição do usuário</response>
        [HttpPost("login")]
        public ActionResult<string> Authenticate([FromBody] LoginUsuarioDTO usuario)
        {
            var user = _usuarioService.Login(usuario.Email, usuario.Senha);
            if (user != null)
            {
                var token = TokenService.GenerateToken(user);
                return Ok(token);
            }
            return NotFound("Usuário e/ou senha inserido(s) incorretamente");
        }
    }
}
