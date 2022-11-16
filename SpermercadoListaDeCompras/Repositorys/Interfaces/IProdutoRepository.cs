using Entities.Entity.Models;

namespace Repositorys.Interfaces
{
    public interface IProdutoRepository
    {
        public void AdicionarProduto(Produto produto);
        public void AtualizarProduto(Produto produto);
        public void DeletarProduto(string id);
        public Produto? ObtemProdutoByID(string id);
        public Task<IEnumerable<Produto>> ObtemProdutos();
        public void Save();
    }
}
