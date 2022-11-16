using BusinessLayer.DTO;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Microsoft.AspNetCore.Mvc;

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

        // Chamada parece redundante 
        // GET: api/<ListaController>
        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<List<Usuario>>> GetFromUsuario([FromRoute] int idUsuario)
        {
            return Ok(await _listaService.ObtemListasPorUsuario(idUsuario));
        }

        // Também parece redundante
        // GET: api/<ListaController>
        [HttpGet("{id}")]
        public Listum? Get([FromRoute] int id)
        {
            Listum? lista = _listaService.ObtemListaByID(id);
            return lista;
        }

        // POST: api/<ListaController>
        [HttpPost]
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

        // DELETE: api/<ListaController>
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

        // PUT: api/<ListaController>
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
