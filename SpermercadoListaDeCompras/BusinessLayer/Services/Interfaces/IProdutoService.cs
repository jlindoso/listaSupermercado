using Entities.Entity.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProdutoSupermercadoService
    {
        public void AdicionarProduto(Produto produto);
        public void AtualizarProduto(Produto produto);
        public void DeletarProduto(string id);
        public Produto? ObtemProdutoByID(string id);
        public Task<IEnumerable<Produto>> ObtemProdutos();
    }
}
