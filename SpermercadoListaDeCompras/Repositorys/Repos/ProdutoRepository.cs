using Entities.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositorys.Context;
using Repositorys.Interfaces;

namespace Repositorys.Repos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ListaSupermercadoContext _context;
        public ProdutoRepository(ListaSupermercadoContext context)
        {
            _context = context;
        }

        public void AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void AtualizarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarProduto(string id)
        {
            Produto? produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }

        public Produto? ObtemProdutoByID(string id)
        {
            return _context.Produtos.Find(id);
        }

        public async Task<IEnumerable<Produto>> ObtemProdutos()
        {
            return await _context.Produtos.Take(10).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
