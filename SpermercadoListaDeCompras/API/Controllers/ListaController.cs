using BusinessLayer.DTO.ListaDTO;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControllerBase
    {
        private readonly IListaService _listaService;
        public ListaController()
        {
            _listaService = new ListaService();
        }

        /// <summary>Retorna listas que pertençam ao usuário que está logado no momento</summary>
        /// <response code="200">Retorna listas que pertençam ao usuário que está logado no momento</response>
        /// <response code="401">Não autorizado</response>
        [HttpGet("usuario")]
        [Authorize]
        public async Task<ActionResult<List<Listum>>> GetFromUsuario()
        {
            var idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _listaService.ObtemListasPorUsuario(Convert.ToInt32(idUsuario)));
        }

        /// <summary>Retorna listas que tenha o id informado</summary>
        /// <response code="200">Retorna lista que possua o id informado</response>
        [HttpGet("{id}")]
        public Listum? Get([FromRoute] int id)
        {
            Listum? lista = _listaService.ObtemListaByID(id);
            return lista;
        }


        /// <summary>Cria uma nova lista</summary>
        /// <response code="200">Retorna que a nova lista foi criada com sucesso</response>
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(include: "DataLista, Total, EstaAtivo, idUsuario")] ListaDTO lista)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _listaService.AdicionarLista(lista);
                    return Ok("Lista criado com sucesso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar Lista " + ex.Message);
            }
            return BadRequest("Não foi possível salvar a lista ");
        }

        /// <summary>Deleta uma lista por id</summary>
        /// <response code="200">Retorna que a lista, a qual foi informado o id, foi deletada</response>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _listaService.DeletarLista(id);
                return Ok("Lista excluida com sucesso!");
            }
            catch (Exception)
            {
                return NotFound("Lista Não Encontrada");
            }
        }


        /// <summary>Atualiza uma lista</summary>
        /// <response code="200">Retorna que a lista, a qual foi informado o id, foi deletada</response>
        [HttpPut]
        public ActionResult Edit([Bind(include: "DataLista, Total, EstaAtivo, idUsuario")] Listum lista)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _listaService.AtualizarLista(lista);
                    return Ok("Lista atualizada com Sucesso");
                }
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível atualizar lista");
            }
            return BadRequest("Não foi possível salvar a lista");
        }
    }
}
