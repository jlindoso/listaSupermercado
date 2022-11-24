using BusinessLayer.DTO.FotoProdutoDTO;
using BusinessLayer.Services.Interfaces;
using Entities.Models;
using Repositorys.Context;
using Repositorys.Interfaces;
using Repositorys.Repos;
using System.Drawing;

namespace BusinessLayer.Services
{
    public class FotoProdutoService : IFotoProdutoService
    {
        private readonly IFotoProdutoRepo _fotoProdutoRepo;
        public FotoProdutoService()
        {
            _fotoProdutoRepo = new FotoProdutoRepo(new ListaSupermercadoContext());
        }
        public void AdicionarFotoProduto(string fotoPath)
        {
            var foto = Image.FromFile(fotoPath);
            _fotoProdutoRepo.AdicionarFotoProduto(foto);
        }

        public void AtualizarFotoProduto(AtualizarFotoProdutoDTO fotoProduto)
        {
            MemoryStream ms = new();
            var foto = Image.FromFile(fotoProduto.Path);
            foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            FotoProduto fotoAtualizada = new()
            {
                Id = fotoProduto.Id,
                Imagem = ms.ToArray()
            };
            _fotoProdutoRepo.AtualizarFotoProduto(fotoAtualizada);
        }

        public void DeletarFotoProduto(Guid id)
        {
            _fotoProdutoRepo.DeletarFotoProduto(id);
        }

        public FotoProduto? ObtemFotoProdutoByID(Guid id)
        {
            return _fotoProdutoRepo.ObtemFotoProdutoByID(id);
        }

        public IEnumerable<FotoProduto> ObtemFotosProdutos()
        {
            return _fotoProdutoRepo.ObtemFotosProdutos();
        }
    }
}
