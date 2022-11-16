using Entities.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositorys.Context;
using Repositorys.Interfaces;

namespace Repositorys.Repos
{
    public class SupermercadoRepository : ISupermercadoRepository
    {
        private readonly ListaSupermercadoContext _context;
        public SupermercadoRepository(ListaSupermercadoContext context)
        {
            _context = context;
        }
        public void AdicionarSupermercado(Supermercado supermercado)
        {
            _context.Supermercados.Add(supermercado);
            _context.SaveChanges();
        }

        public void AtualizarSupermercado(Supermercado supermercado)
        {
            _context.Entry(supermercado).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarSupermercado(int id)
        {
            Supermercado? supermercado = _context.Supermercados.Find(id);
            if (supermercado != null)
            {
                _context.Supermercados.Remove(supermercado);
                _context.SaveChanges();
            }
        }

        public Supermercado? ObtemSupermercadoByID(int id)
        {
            return _context.Supermercados.Find(id);
        }

        public async Task<IEnumerable<Supermercado>> ObtemSupermercados()
        {
            return await _context.Supermercados.Take(10).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
