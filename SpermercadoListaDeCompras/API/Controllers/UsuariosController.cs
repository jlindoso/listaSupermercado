using BusinessLayer.DAL.Interfaces;
using Entities.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Repositorys.Usuario;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository usuarioRepository;
        public UsuariosController()
        {
            this.usuarioRepository = new UsuarioRepository(new BusinessLayer.Context.ListaSupermercadoContext());
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return Ok(usuarioRepository.ObtemUsuarios());
        }

        // GET: api/<UsuariosController>/{id}
        [HttpGet("id")]
        public Usuario Get([FromQuery] int id)
        {
            Usuario usuario = usuarioRepository.ObtemUsuarioByID(id);
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
                    usuarioRepository.AdicionarUsuario(usuario);
                    usuarioRepository.Save();
                    return Ok("Usuário criado com sucesso");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Não foi possível salvar o usuário");
            }
            return BadRequest("Não foi possível salvar o usuário");
        }

        // DELETE: api/<UsuariosController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                usuarioRepository.DeletarUsuario(id);
                usuarioRepository.Save();
            }
            catch (Exception ex)
            {
                return NotFound("Usuario Não Encontrado");
            }
            return Ok("Usuario excluido com sucesso!");
        }

        // PUT: api/<UsuariosController>
        [HttpPut]
        public ActionResult Edit([Bind(include: "Nome, Email, Senha")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioRepository.AtualizarUsuario(usuario);
                    usuarioRepository.Save();
                    return Ok("Usuário atualizado com Sucesso");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError(string.Empty, "Não foi possível salvar o usuário");
            }
            return BadRequest("Não foi possível salvar o usuário");
        }
    }
}
