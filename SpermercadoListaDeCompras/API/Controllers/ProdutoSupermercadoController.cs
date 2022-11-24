using BusinessLayer.DTO.ProdutoSupermercadoDTO;
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

        /// <summary>Retorna o(s) produto(s) que já tenha(m) sido cadastrado(s) no(s) supermercado(s)</summary>
        /// <response code="200">Retorna o(s) produto(s)</response>
        [HttpGet]
        public ActionResult<List<ProdutoSupermercado>> Get([FromQuery] string? parametro)
        {
            return Ok(_produtoSupermercadoService.ObtemProdutoSupermercado(parametro).Result);
        }

        /// <summary>Retorna um produto por seu id</summary>
        /// <response code="200">Retorna o produto que teve o id informado</response>
        [HttpGet("id")]
        public ProdutoSupermercado? Get([FromQuery] int id)
        {
            ProdutoSupermercado? protudoSupermercado = _produtoSupermercadoService.ObtemProdutoSupermercadoByID(id);
            return protudoSupermercado;
        }

        /// <summary>Cria uma nova relação de produto x supermercado</summary>
        /// <response code="201">Retorna a relação que foi criada com sucesso</response>
        [HttpPost]
        public ActionResult Create([Bind(include: "preco, IdSupermercado, codigoBarrasProduto")] CriarProdutoSupermercadoDTO produtoSupermercado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoSupermercadoService.AdicionarProdutoSupermercado(produtoSupermercado);
                    return Created("Relação criada com sucesso", produtoSupermercado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível criar relação " + ex.Message);
            }
            return BadRequest("Não foi possível salvar a relação");
        }

        /// <summary>Exclui uma relação de produto x supermercado, por id</summary>
        /// <response code="200">Retorna que relação foi excluida com sucesso</response>
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

        /// <summary>Atualiza uma relação de produto x supermercado</summary>
        /// <response code="200">Retorna que a relação foi atualizada com sucesso</response>
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
