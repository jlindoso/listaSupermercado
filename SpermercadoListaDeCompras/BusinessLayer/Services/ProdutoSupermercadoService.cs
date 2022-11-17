using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Repositorys.Interfaces;
using Repositorys.Repos;
using Repositorys.Context;
using BusinessLayer.DTO.ProdutoSupermercadoDTO;

namespace BusinessLayer.Services
{
    public class ProdutoSupermercadoService : IProdSupermercadoService
    {
        private readonly IProdutoSupermercadoRepository _produtoSupermercadoRepository;
        public ProdutoSupermercadoService()
        {
            _produtoSupermercadoRepository = new ProdutoSupermercadoRepository(new ListaSupermercadoContext());
        }

        public void AdicionarProdutoSupermercado(CriarProdutoSupermercadoDTO produtoSupermercadoDTO)
        {
            ProdutoSupermercado produtoSupermercado = new()
            {
                Preco = produtoSupermercadoDTO.Preco,
                IdSupermercado = produtoSupermercadoDTO.IdSupermercado,
                CodigoBarrasProduto = produtoSupermercadoDTO.CodigoBarrasProduto,
            };
            _produtoSupermercadoRepository.AdicionarProdutoSupermercado(produtoSupermercado);
        }

        public void AtualizarProdutoSupermercado(AtualizarProdutoSupermercadoDTO produtoSupermercadoDTO)
        {
            ProdutoSupermercado produtoSupermercado = new()
            {
                Id = produtoSupermercadoDTO.Id,
                Preco = produtoSupermercadoDTO.Preco,
                IdSupermercado = produtoSupermercadoDTO.IdSupermercado,
                CodigoBarrasProduto = produtoSupermercadoDTO.CodigoBarrasProduto,
            };
            _produtoSupermercadoRepository.AtualizarProdutoSupermercado(produtoSupermercado);
        }

        public void DeletarProdutoSupermercado(int id)
        {
            _produtoSupermercadoRepository.DeletarProdutoSupermercado(id);
        }

        public async Task<IEnumerable<ProdutoSupermercado>> ObtemProdutoSupermercado(string? parametro)
        {
            return await _produtoSupermercadoRepository.ObtemProdutoSupermercado(parametro);
        }

        public ProdutoSupermercado? ObtemProdutoSupermercadoByID(int id)
        {
            return _produtoSupermercadoRepository.ObtemProdutoSupermercadoByID(id);
        }
    }
}
