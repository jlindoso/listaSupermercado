using Entities.Entity.Models;

namespace Repositorys.Interfaces
{
    public interface IProdutoSupermercadoRepository
    {
        public void AdicionarProdutoSupermercado(ProdutoSupermercado produtoSupermercado);
        public void AtualizarProdutoSupermercado(ProdutoSupermercado produtoSupermercado);
        public void DeletarProdutoSupermercado(int id);
        public ProdutoSupermercado? ObtemProdutoSupermercadoByID(int id);
        public Task<IEnumerable<ProdutoSupermercado>> ObtemProdutoSupermercado(string? parametro);
        public void Save();
    }
}
