using BusinessLayer.DTO.FotoProdutoDTO;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoProdutoController : ControllerBase
    {
        private readonly IFotoProdutoService _fotoProdutoService;
        public FotoProdutoController()
        {
            _fotoProdutoService = new FotoProdutoService();
        }

        [HttpPost]
        public ActionResult Create(string path)
        {
            _fotoProdutoService.AdicionarFotoProduto(path);
            return Ok("Upload completo");
        }

        [HttpGet("{id}")]
        public ExibirFotoProdutoDTO? Get([FromRoute] string id)
        {
            Guid uuid = new Guid(id);
            FotoProduto fotoProduto = _fotoProdutoService.ObtemFotoProdutoByID(uuid);
            var ms = new MemoryStream(fotoProduto.Imagem);
            ExibirFotoProdutoDTO exibirFotoProduto = new()
            {
                Foto = Image.FromStream(ms)
            };
            return exibirFotoProduto;
        }

        [HttpGet]
        public ActionResult<List<FotoProduto>> Get()
        {
            return Ok(_fotoProdutoService.ObtemFotosProdutos());
        }

        [HttpPut]
        public ActionResult Edit([FromBody] AtualizarFotoProdutoDTO foto)
        {
            _fotoProdutoService.AtualizarFotoProduto(foto);
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            Guid uuid = new Guid(id);
            _fotoProdutoService.DeletarFotoProduto(uuid);
            return Ok("Foto excluída com sucesso");
        }
    }
}
