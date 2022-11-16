using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoSupermercadoService _produtoService;
        public ProdutoController()
        {
            _produtoService = new ProdutoService();
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(_produtoService.ObtemProdutos().Result);
        }

        // GET: api/<ProdutoController>/{id}
        [HttpGet("id")]
        public Produto? Get([FromQuery] string id)
        {
            Produto? produto = _produtoService.ObtemProdutoByID(id);
            return produto;
        }

        // POST: api/<ProdutoController>
        [HttpPost]
        public ActionResult Create([Bind(include: "codigoBarras, nome, descricao, foto")] Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoService.AdicionarProduto(produto);
                    return Ok("Produto criado com sucesso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar produto " + ex.Message);
            }
            return BadRequest("Não foi possível salvar o produto");
        }

        // DELETE: api/<ProdutoController>
        [HttpDelete]
        public ActionResult Delete([FromQuery] string id)
        {
            try
            {
                _produtoService.DeletarProduto(id);
                return Ok("Produto excluido com sucesso!");
            }
            catch (Exception)
            {
                return NotFound("Produto Não Encontrado");
            }
        }

        // PUT: api/<ProdutoController>
        [HttpPut]
        public ActionResult Edit([Bind(include: "codigodeBarras, nome, descricao, foto")] Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoService.AtualizarProduto(produto);
                    return Ok("Produto atualizado com Sucesso");
                }
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível atualizar o produto");
            }
            return BadRequest("Não foi possível salvar o produto");
        }
    }

}
