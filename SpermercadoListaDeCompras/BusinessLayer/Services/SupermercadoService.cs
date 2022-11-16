using BusinessLayer.Services.Interfaces;
using Entities.Entity.Models;
using Repositorys.Context;
using Repositorys.Interfaces;
using Repositorys.Repos;

namespace BusinessLayer.Services
{
    public class SupermercadoService : ISupermercadoService
    {
        private readonly ISupermercadoRepository _supermercadoRepository;
        public SupermercadoService()
        {
            _supermercadoRepository = new SupermercadoRepository(new ListaSupermercadoContext());
        }
        public void AdicionarSupermercado(Supermercado supermercado)
        {
            _supermercadoRepository.AdicionarSupermercado(supermercado);
        }

        public void AtualizarSupermercado(Supermercado supermercado)
        {
            _supermercadoRepository.AtualizarSupermercado(supermercado);
        }

        public void DeletarSupermercado(int id)
        {
            _supermercadoRepository.DeletarSupermercado(id);
        }

        public Supermercado? ObtemSupermercadoByID(int id)
        {
            return _supermercadoRepository.ObtemSupermercadoByID(id);
        }

        public Task<IEnumerable<Supermercado>> ObtemSupermercados()
        {
            return _supermercadoRepository.ObtemSupermercados();
        }
    }
}
