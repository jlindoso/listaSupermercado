using API.Services;
using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public UsuarioService _usuarioService { get; set; }
        public AuthController()
        {
            _usuarioService = new UsuarioService();
        }
        // POST api/<AuthController>
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioLoginDTO model)
        {
            var user = _usuarioService.Login(model);
            if (user != null) return Ok(TokenService.GenerateToken(user));
            else return Unauthorized();
        }

    }
}
