using Entities.Entity.Models;
using Repositorys.Context;
using Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorys.Repos
{
    public class ItemListaRepository : IItemListaRepository
    {
        private readonly ListaSupermercadoContext _context;
        public ItemListaRepository(ListaSupermercadoContext context)
        {
            _context = context;
        }
        public void AdicionarItemLista(ItemListum itemLista)
        {
            _context.ItemLista.Add(itemLista);
        }

        public void AtualizarItemLista(ItemListum itemLista)
        {
            _context.Entry(itemLista).State = EntityState.Modified;
        }

        public void DeletarItemLista(int id)
        {
            ItemListum? itemLista = _context.ItemLista.Find(id);
            if (itemLista != null)
            {
                _context.ItemLista.Remove(itemLista);
                _context.SaveChanges();
            }
        }

        public ItemListum? ObtemItemListaByID(int id)
        {
            return _context.ItemLista.Find(id);
        }

        public async Task<IEnumerable<ItemListum>> ObtemItemPorLista(int idLista)
        {
            return await _context.ItemLista.Where(i => i.IdLista == idLista).ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
