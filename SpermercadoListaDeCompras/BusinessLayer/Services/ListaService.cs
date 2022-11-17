using BusinessLayer.DTO.ListaDTO;
using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Repositorys.Interfaces;
using Repositorys.Repos;

namespace BusinessLayer.Services
{
    public class ListaService : IListaService
    {
        private readonly IListaRepository _listaRepository;
        public ListaService()
        {
            _listaRepository = new ListaRepository(new Repositorys.Context.ListaSupermercadoContext());
        }

        public void AdicionarLista(ListaDTO lista)
        {
            Listum listum = new()
            {
                IdUsuario = lista.IdUsuario
            };
            _listaRepository.AdicionarLista(listum);
        }

        public void AtualizarLista(Listum lista)
        {
            _listaRepository.AtualizarLista(lista);
        }

        public void DeletarLista(int id)
        {
            _listaRepository.DeletarLista(id);
        }

        public Listum? ObtemListaByID(int id)
        {
            return _listaRepository.ObtemListaByID(id);
        }

        public async Task<IEnumerable<Listum>> ObtemListasPorUsuario(int idUsuario)
        {
            return await _listaRepository.ObtemListasPorUsuario(idUsuario);
        }
    }
}
