using Entities.Entity.Models;

namespace Repositorys.Interfaces
{
    public interface IItemListaRepository
    {
        public void AdicionarItemLista(ItemListum itemLista);
        public void AtualizarItemLista(ItemListum itemLista);
        public void DeletarItemLista(int id);
        public ItemListum? ObtemItemListaByID(int id);
        public Task<IEnumerable<ItemListum>> ObtemItemPorLista(int idLista);
        public void Save();
    }
}
