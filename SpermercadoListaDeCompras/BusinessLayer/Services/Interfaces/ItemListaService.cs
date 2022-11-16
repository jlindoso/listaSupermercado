using BusinessLayer.DTO.ItemListaDTO;
using Entities.Entity.Models;
using Repositorys.Interfaces;
using Repositorys.Repos;
using Repositorys.Context;

namespace BusinessLayer.Services.Interfaces
{
    public class ItemListaService : IItemListaService
    {
        private readonly IItemListaRepository _itemListaRepository;
        public ItemListaService()
        {
            _itemListaRepository = new ItemListaRepository(new ListaSupermercadoContext());
        }
        public void AdicionarItemLista(CriarItemListaDTO itemLista)
        {
            ItemListum item = new()
            {
                Quantidade = itemLista.Quantidade,
                Comprado = itemLista.Comprado,
                Preco = itemLista.Preco,
                IdSupermercado = itemLista.IdSupermercado,
                CodigoBarrasProduto = itemLista.CodigoBarrasProduto,
                IdLista = itemLista.IdLista,
            };
            _itemListaRepository.AdicionarItemLista(item);
        }

        public void AtualizarItemLista(AtualizarItemListaDTO itemLista)
        {
            ItemListum item = new()
            {
                Id = itemLista.Id,
                Quantidade = itemLista.Quantidade,
                Comprado = itemLista.Comprado,
                Preco = itemLista.Preco,
                IdSupermercado = itemLista.IdSupermercado,
                CodigoBarrasProduto = itemLista.CodigoBarrasProduto,
                IdLista = itemLista.IdLista,
            };
            _itemListaRepository.AtualizarItemLista(item);
        }

        public void DeletarItemLista(int id)
        {
            _itemListaRepository.DeletarItemLista(id);
        }

        public ItemListum? ObtemItemListaByID(int id)
        {
            return _itemListaRepository.ObtemItemListaByID(id);
        }

        public async Task<IEnumerable<ItemListum>> ObtemItemPorLista(int idLista)
        {
            return await _itemListaRepository.ObtemItemPorLista(idLista);
        }
    }
}
