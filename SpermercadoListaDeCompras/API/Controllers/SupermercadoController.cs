using BusinessLayer.DTO.SupermercadoDTO;
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

        /// <summary>Retorna todos os supermercados cadastrados</summary>
        /// <response code="200">Retorna uma lista com supermercados cadastrados</response>
        [HttpGet]
        public ActionResult<List<Supermercado>> Get()
        {
            return Ok(_supermercadoService.ObtemSupermercados().Result);
        }

        /// <summary>Retorna o supermercado pelo id informado</summary>
        /// <response code="200">Retorna o supemercado o qual foi informado o id</response>
        [HttpGet("id")]
        public Supermercado? Get([FromQuery] int id)
        {
            Supermercado? supermercado = _supermercadoService.ObtemSupermercadoByID(id);
            return supermercado;
        }

        /// <summary>Cria um novo supermercado</summary>
        /// <response code="200">Retorna que o supermercado foi criado com sucesso</response>
        [HttpPost]
        public ActionResult Create([Bind(include: "nome, logradouro, cidade, bairro, estado, cep")] CriarSupermercadoDTO supermercado)
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

        /// <summary>Deleta um supermercado</summary>
        /// <response code="200">Retorna que o supermercado foi deletado com sucesso</response>
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

        /// <summary>Atualiza um supermercado</summary>
        /// <response code="200">Retorna que o supermercado foi atualizado com sucesso</response>
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
