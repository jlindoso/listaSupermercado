using BusinessLayer.DTO.ListaDTO;
using Entities.Entity.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IListaService
    {
        public void AdicionarLista(ListaDTO lista);
        public void AtualizarLista(Listum lista);
        public void DeletarLista(int id);
        public Listum? ObtemListaByID(int id);
        public Task<IEnumerable<Listum>> ObtemListasPorUsuario(int idUsuario);
    }
}
