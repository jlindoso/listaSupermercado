using BusinessLayer.DTO;
using BusinessLayer.DTO.ItemListaDTO;
using Repositorys.DTO;

namespace BusinessLayer.Services.Interfaces
{
    public interface IItemListaService
    {
        public void AdicionarItemLista(CriarItemListaDTO itemLista);
        public void AtualizarItemLista(BaseItemListaDTO itemLista);
        public void DeletarItemLista(int id);
        public BuscarItemListaDTO? ObtemItemListaByID(int id);
        public IEnumerable<BuscarItemLista> ObtemItemPorLista(int idLista);
    }
}
