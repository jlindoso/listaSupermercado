using Entities.Models;
using System.Drawing;

namespace Repositorys.Interfaces
{
    public interface IFotoProdutoRepo
    {
        public void AdicionarFotoProduto(Image foto);
        public void AtualizarFotoProduto(FotoProduto fotoProduto);
        public void DeletarFotoProduto(Guid id);
        public FotoProduto? ObtemFotoProdutoByID(Guid id);
        public IEnumerable<FotoProduto> ObtemFotosProdutos();
        public void Save();
    }
}
