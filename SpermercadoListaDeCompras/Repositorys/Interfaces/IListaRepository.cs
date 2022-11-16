using Entities.Entity.Models;

namespace Repositorys.Interfaces
{
    public interface IListaRepository
    {
        public void AdicionarLista(Listum lista);
        public void AtualizarLista(Listum lista);
        public void DeletarLista(int id);
        public Listum? ObtemListaByID(int id);
        public Task<IEnumerable<Listum>> ObtemListasPorUsuario(int idUsuario);
        public void Save();
    }
}
