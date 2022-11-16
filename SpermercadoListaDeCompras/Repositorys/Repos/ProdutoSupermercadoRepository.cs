using Entities.Entity.Models;
using Repositorys.Context;
using Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorys.Repos
{
    public class ProdutoSupermercadoRepository : IProdutoSupermercadoRepository
    {
        private readonly ListaSupermercadoContext _context;
        public ProdutoSupermercadoRepository(ListaSupermercadoContext context)
        {
            _context = context;
        }
        public void AdicionarProdutoSupermercado(ProdutoSupermercado produtoSupermercado)
        {
            _context.ProdutoSupermercados.Add(produtoSupermercado);
            _context.SaveChanges();
        }

        public void AtualizarProdutoSupermercado(ProdutoSupermercado produtoSupermercado)
        {
            _context.Entry(produtoSupermercado).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarProdutoSupermercado(int id)
        {
            ProdutoSupermercado? produtoSupermercado = _context.ProdutoSupermercados.Find(id);
            if (produtoSupermercado != null)
            {
                _context.ProdutoSupermercados.Remove(produtoSupermercado);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<ProdutoSupermercado>> ObtemProdutoSupermercado(string? parametro)
        {
            return await _context.ProdutoSupermercados
                .Where(p => p.CodigoBarrasProduto
                .Equals(parametro))
                .ToListAsync();
        }

        public ProdutoSupermercado? ObtemProdutoSupermercadoByID(int id)
        {
            return _context.ProdutoSupermercados.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
