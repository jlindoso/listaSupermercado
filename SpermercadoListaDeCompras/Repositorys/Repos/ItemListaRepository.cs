using Entities.Entity.Models;
using Repositorys.Context;
using Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositorys.DTO;

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
            _context.SaveChanges();
        }

        public void AtualizarItemLista(ItemListum itemLista)
        {
            _context.Entry(itemLista).State = EntityState.Modified;
            _context.SaveChanges();
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

        public IEnumerable<BuscarItemLista> ObtemItemPorLista(int idLista)
        {
            return _context.ItemLista.Where(x => x.IdLista == idLista)
                .Select(x => new BuscarItemLista{ 
                    Id = x.Id, 
                    Quantidade = x.Quantidade,
                    Comprado = x.Comprado,
                    Preco = x.Preco, 
                    IdSupermercado = x.IdSupermercado, 
                    CodigoBarrasProduto = x.CodigoBarrasProduto, 
                    IdLista = x.IdLista })
                .ToList();
         }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}