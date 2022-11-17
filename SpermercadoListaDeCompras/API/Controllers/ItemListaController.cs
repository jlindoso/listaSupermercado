using BusinessLayer.Services.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Entities.Entity.Models;
using BusinessLayer.DTO.ListaDTO;
using BusinessLayer.DTO.ItemListaDTO;
using BusinessLayer.DTO;
using Repositorys.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemListaController : ControllerBase
    {
        private readonly IItemListaService _itemListaService;
        public ItemListaController()
        {
            _itemListaService = new ItemListaService();
        }
        
        // GET: api/<ItemListaController>
        [HttpGet("lista/{idLista}")]
        public ActionResult<List<BuscarItemLista>> GetFromLista([FromRoute] int idLista)
        {
            return Ok(_itemListaService.ObtemItemPorLista(idLista));
        }

        // GET: api/<ItemListaController>
        [HttpGet("{id}")]
        public BuscarItemListaDTO? Get([FromRoute] int id)
        {
            BuscarItemListaDTO? itemlista = _itemListaService.ObtemItemListaByID(id);
            return itemlista;
        }

        // POST: api/<ItemListaController>
        [HttpPost]
        public ActionResult Create([Bind(include: "Quantidade, Comprado, Preco, IdSupermercado, CodigoBarrasProduto, IdLista")] CriarItemListaDTO itemLista)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemListaService.AdicionarItemLista(itemLista);
                    return Ok("ItemLista criado com sucesso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar itemLista " + ex.Message);
            }
            return BadRequest("Não foi possível salvar a itemLista ");
        }

        // DELETE: api/<ItemListaController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _itemListaService.DeletarItemLista(id);
                return Ok("ItemLista excluido com sucesso!");
            }
            catch (Exception)
            {
                return NotFound("ItemLista Não Encontrado");
            }
        }

        // PUT: api/<ItemListaController>
        [HttpPut]
        public ActionResult Edit([Bind(include: "Id, Quantidade, Comprado, Preco, IdSupermercado, CodigoBarrasProduto, IdLista")] BaseItemListaDTO itemLista)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemListaService.AtualizarItemLista(itemLista);
                    return Ok("ItemLista atualizado com Sucesso");
                }
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível atualizar itemLista");
            }
            return BadRequest("Não foi possível salvar o itemLista");
        }
    }
}
