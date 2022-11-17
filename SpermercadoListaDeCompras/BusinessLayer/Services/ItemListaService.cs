using BusinessLayer.DTO.ItemListaDTO;
using Entities.Entity.Models;
using Repositorys.Interfaces;
using Repositorys.Repos;
using Repositorys.Context;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.DTO;
using Repositorys.DTO;

namespace BusinessLayer.Services
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

        public void AtualizarItemLista(BaseItemListaDTO itemLista)
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

        public BuscarItemListaDTO? ObtemItemListaByID(int id)
        {
            ItemListum? itemLista = _itemListaRepository.ObtemItemListaByID(id);
            BuscarItemListaDTO itemListaDTO = new()
            {
                Id = itemLista.Id,
                Quantidade = itemLista.Quantidade,
                Comprado = itemLista.Comprado,
                Preco = itemLista.Preco,
                IdSupermercado = itemLista.IdSupermercado,
                CodigoBarrasProduto = itemLista.CodigoBarrasProduto,
                IdLista = itemLista.IdLista,
            };
            return itemListaDTO;
        }

        public IEnumerable<BuscarItemLista> ObtemItemPorLista(int idLista)
        {
            return _itemListaRepository.ObtemItemPorLista(idLista);
        }
    }
}
