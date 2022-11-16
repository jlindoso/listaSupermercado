using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermercadoController : ControllerBase
    {
        private readonly ISupermercadoService _supermercadoService;

        public SupermercadoController()
        {
            _supermercadoService = new SupermercadoService();
        }

        // GET: api/<SupermercadoController>
        [HttpGet]
        public ActionResult<List<Supermercado>> Get()
        {
            return Ok(_supermercadoService.ObtemSupermercados().Result);
        }

        // GET: api/<SupermercadoController>/{id}
        [HttpGet("id")]
        public Supermercado? Get([FromQuery] int id)
        {
            Supermercado? supermercado = _supermercadoService.ObtemSupermercadoByID(id);
            return supermercado;
        }

        // POST: api/<SupermercadoController>
        [HttpPost]
        public ActionResult Create([Bind(include: "nome, logradouro, cidade, bairro, estado, cep")] Supermercado supermercado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _supermercadoService.AdicionarSupermercado(supermercado);
                    return Ok("Usuário criado com sucesso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar usuário" + ex.Message);
            }
            return BadRequest("Não foi possível salvar o usuário");
        }

        // DELETE: api/<SupermercadoController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _supermercadoService.DeletarSupermercado(id);
                return Ok("Usuario excluido com sucesso!");
            }
            catch (Exception)
            {
                return NotFound("Usuario Não Encontrado");
            }
        }

        // PUT: api/<SupermercadoController>
        [HttpPut]
        public ActionResult Edit([Bind(include: "nome, logradouro, cidade, bairro, estado, cep")] Supermercado supermercado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _supermercadoService.AtualizarSupermercado(supermercado);
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
