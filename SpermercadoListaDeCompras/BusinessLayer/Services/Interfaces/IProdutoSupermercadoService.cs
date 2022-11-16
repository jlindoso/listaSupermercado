using BusinessLayer.DTO;
using Entities.Entity.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProdSupermercadoService
    {
        public void AdicionarProdutoSupermercado(CriarProdutoSupermercadoDTO produtoSupermercadoDTO);
        public void AtualizarProdutoSupermercado(AtualizarProdutoSupermercadoDTO produtoSupermercadoDTO);
        public void DeletarProdutoSupermercado(int id);
        public ProdutoSupermercado? ObtemProdutoSupermercadoByID(int id);
        public Task<IEnumerable<ProdutoSupermercado>> ObtemProdutoSupermercado(string? parametro);
    }
}
