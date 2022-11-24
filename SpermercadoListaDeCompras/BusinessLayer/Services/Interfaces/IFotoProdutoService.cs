using BusinessLayer.DTO.FotoProdutoDTO;
using Entities.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IFotoProdutoService
    {
        public void AdicionarFotoProduto(string fotoPath);
        public void AtualizarFotoProduto(AtualizarFotoProdutoDTO fotoProduto);
        public void DeletarFotoProduto(Guid id);
        public FotoProduto? ObtemFotoProdutoByID(Guid id);
        public IEnumerable<FotoProduto> ObtemFotosProdutos();
    }
}
