using BusinessLayer.DTO.ItemListaDTO;
using Entities.Entity.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IItemListaService
    {
        public void AdicionarItemLista(CriarItemListaDTO itemLista);
        public void AtualizarItemLista(AtualizarItemListaDTO itemLista);
        public void DeletarItemLista(int id);
        public ItemListum? ObtemItemListaByID(int id);
        public Task<IEnumerable<ItemListum>> ObtemItemPorLista(int idLista);
    }
}
