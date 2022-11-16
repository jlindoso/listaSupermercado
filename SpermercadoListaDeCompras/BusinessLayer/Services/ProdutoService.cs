using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Repositorys.Interfaces;
using Repositorys.Repos;
using Repositorys.Context;

namespace BusinessLayer.Services
{
    public class ProdutoService : IProdutoSupermercadoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService()
        {
            _produtoRepository = new ProdutoRepository(new ListaSupermercadoContext());
        }
        public void AdicionarProduto(Produto produto)
        {
            _produtoRepository.AdicionarProduto(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            _produtoRepository.AtualizarProduto(produto);
        }

        public void DeletarProduto(string id)
        {
            _produtoRepository.DeletarProduto(id);
        }

        public Produto? ObtemProdutoByID(string id)
        {
            return _produtoRepository.ObtemProdutoByID(id);
        }

        public Task<IEnumerable<Produto>> ObtemProdutos()
        {
            return _produtoRepository.ObtemProdutos();
        }
    }
}
