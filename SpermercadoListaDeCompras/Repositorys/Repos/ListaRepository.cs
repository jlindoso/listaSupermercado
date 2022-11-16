using Entities.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repositorys.Context;
using Repositorys.Interfaces;

namespace Repositorys.Repos
{
    public class ListaRepository : IListaRepository
    {
        private readonly ListaSupermercadoContext _context;

        public ListaRepository(ListaSupermercadoContext context)
        {
            _context = context;
        }
        public void AdicionarLista(Listum lista)
        {
            _context.Lista.Add(lista);
            _context.SaveChanges();
        }

        public void AtualizarLista(Listum lista)
        {
            _context.Entry(lista).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarLista(int id)
        {
            Listum? lista = _context.Lista.Find(id);
            if (lista != null)
            {
                _context.Lista.Remove(lista);
                _context.SaveChanges();
            }
        }

        public Listum? ObtemListaByID(int id)
        {
            return _context.Lista.Find(id);
        }

        public async Task<IEnumerable<Listum>> ObtemListasPorUsuario(int idUsuario)
        {
            return await _context.Lista.
                Where(p => p.IdUsuario == idUsuario)
                .ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
