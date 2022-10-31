using BusinessLayer.Model;
using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuarioService _service;
        public UsuariosController()
        {
            _service = new UsuarioService();
        }
        // POST: api/<UsuariosController>
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] UsuarioCadastroDTO usuarioCadastroDTO)
        {
            return Created(string.Empty, _service.Cadastrar(usuarioCadastroDTO));
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public Usuario Get([FromQuery] int id)
        {
            return _service.Obter(id);
        }

        // PUT: api/<UsuariosController>
        [HttpPut]
        public Usuario Put([FromQuery] int id, [FromBody] UsuarioEditarDTO usuarioEditarDTO)
        {
            return _service.Editar(id, usuarioEditarDTO);
        }

        // DELETE: api/<UsuariosController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _service.Excluir(id);

            }
            catch (Exception ex)
            {

                if (ex.Message.Equals("404"))
                {
                    return NotFound("Usuario Não Encontrado");
                }
            }
            return Ok("Usuario excluido com sucesso!");
        }

    }
}
