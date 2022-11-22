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

        /// <summary>Busca todos os produtos cadastrados</summary>
        /// <response code="200">Retorna uma lista com os produtos cadastrados</response>
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(_produtoService.ObtemProdutos().Result);
        }

        /// <summary>Busca um produto por seu id</summary>
        /// <response code="200">Retorna o produto buscado</response>
        [HttpGet("id")]
        public Produto? Get([FromQuery] string id)
        {
            Produto? produto = _produtoService.ObtemProdutoByID(id);
            return produto;
        }

        /// <summary>Cria um novo produto</summary>
        /// <response code="200">Retorna que o produto foi criado com sucesso</response>
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

        /// <summary>Deleta um produto por seu id</summary>
        /// <response code="200">Retorna que o produto foi deletado com sucesso</response>
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

        /// <summary>Atualiza um produto</summary>
        /// <response code="200">Retorna que o produto foi atualizado com sucesso</response>
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
