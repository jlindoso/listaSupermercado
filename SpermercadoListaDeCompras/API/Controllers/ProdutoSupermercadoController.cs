using BusinessLayer.DTO;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoSupermercadoController : ControllerBase
    {
        private readonly IProdSupermercadoService _produtoSupermercadoService;
        public ProdutoSupermercadoController()
        {
            _produtoSupermercadoService = new ProdutoSupermercadoService();
        }

        // GET: api/<ProdutoSupermercadoController>
        [HttpGet]
        public ActionResult<List<ProdutoSupermercado>> Get([FromQuery] string? parametro)
        {
            return Ok(_produtoSupermercadoService.ObtemProdutoSupermercado(parametro).Result);
        }

        // GET: api/<ProdutoSupermercadoController>/{id}
        [HttpGet("id")]
        public ProdutoSupermercado? Get([FromQuery] int id)
        {
            ProdutoSupermercado? protudoSupermercado = _produtoSupermercadoService.ObtemProdutoSupermercadoByID(id);
            return protudoSupermercado;
        }

        // POST: api/<ProdutoSupermercadoController>
        [HttpPost]
        public ActionResult Create([Bind(include: "preco, IdSupermercado, codigoBarrasProduto")] CriarProdutoSupermercadoDTO produtoSupermercado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoSupermercadoService.AdicionarProdutoSupermercado(produtoSupermercado);
                    return Ok("Relação criada com sucesso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar relação " + ex.Message);
            }
            return BadRequest("Não foi possível salvar a relação");
        }

        // DELETE: api/<ProdutoSupermercadoController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int id)
        {
            try
            {
                _produtoSupermercadoService.DeletarProdutoSupermercado(id);
                return Ok("Relação excluida com sucesso!");
            }
            catch (Exception)
            {
                return NotFound("Relação Não Encontrada");
            }
        }

        // PUT: api/<ProdutoSupermercadoController>
        [HttpPut]
        public ActionResult Edit([Bind(include: "id, preco, IdSupermercado, codigoBarrasProduto")] AtualizarProdutoSupermercadoDTO produtoSupermercado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoSupermercadoService.AtualizarProdutoSupermercado(produtoSupermercado);
                    return Ok("Relação atualizada com Sucesso");
                }
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível atualizar relação");
            }
            return BadRequest("Não foi possível salvar a relação");
        }
    }
}
