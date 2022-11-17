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

        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return Ok( _usuarioService.ObtemUsuarios().Result);
        }

        // GET: api/<UsuariosController>/{id}
        [HttpGet("id")]
        public BuscarUsuarioDTO? Get([FromQuery] int id)
        {
            BuscarUsuarioDTO? usuario = _usuarioService.ObtemUsuarioByID(id);
            return usuario;
        }

        // POST: api/<UsuariosController>
        [HttpPost]
        public ActionResult Create([Bind(include: "Nome, Email, Senha")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioService.AdicionarUsuario(usuario);
                    return Ok("Usuário criado com sucesso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar usuário" + ex.Message);
            }
            return BadRequest("Não foi possível salvar o usuário");
        }

        // DELETE: api/<UsuariosController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _usuarioService.DeletarUsuario(id);
                return Ok("Usuario excluido com sucesso!");
            }
            catch (Exception)
            {
                return NotFound("Usuario Não Encontrado");
            }
        }

        // PUT: api/<UsuariosController>
        [HttpPut]
        public ActionResult Edit([Bind(include: "Nome, Email, Senha")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioService.AtualizarUsuario(usuario);
                    return Ok("Usuário atualizado com Sucesso");
                }
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível atualizar usuário");
            }
            return BadRequest("Não foi possível salvar o usuário");
        }
    }
}
