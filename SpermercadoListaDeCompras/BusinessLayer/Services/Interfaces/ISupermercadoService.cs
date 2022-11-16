using Entities.Entity.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface ISupermercadoService
    {
        public void AdicionarSupermercado(Supermercado supermercado);
        public void AtualizarSupermercado(Supermercado supermercado);
        public void DeletarSupermercado(int id);
        public Supermercado? ObtemSupermercadoByID(int id);
        public Task<IEnumerable<Supermercado>> ObtemSupermercados();
    }
}
