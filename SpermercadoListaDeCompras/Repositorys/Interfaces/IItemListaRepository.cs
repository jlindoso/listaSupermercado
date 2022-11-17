using Entities.Entity.Models;
using Repositorys.DTO;

namespace Repositorys.Interfaces
{
    public interface IItemListaRepository
    {
        public void AdicionarItemLista(ItemListum itemLista);
        public void AtualizarItemLista(ItemListum itemLista);
        public void DeletarItemLista(int id);
        public ItemListum? ObtemItemListaByID(int id);
        public IEnumerable<BuscarItemLista> ObtemItemPorLista(int idLista);
        public void Save();
    }
}
