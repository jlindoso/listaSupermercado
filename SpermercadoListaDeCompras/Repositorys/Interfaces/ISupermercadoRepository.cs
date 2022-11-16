using Entities.Entity.Models;

namespace Repositorys.Interfaces
{
    public interface ISupermercadoRepository
    {
        public void AdicionarSupermercado(Supermercado supermercado);
        public void AtualizarSupermercado(Supermercado supermercado);
        public void DeletarSupermercado(int id);
        public Supermercado? ObtemSupermercadoByID(int id);
        public Task<IEnumerable<Supermercado>> ObtemSupermercados();
        public void Save();
    }
}
