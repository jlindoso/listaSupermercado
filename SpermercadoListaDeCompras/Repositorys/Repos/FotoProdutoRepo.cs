using Entities.Models;
using Repositorys.Context;
using Repositorys.Interfaces;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace Repositorys.Repos
{
    public class FotoProdutoRepo : IFotoProdutoRepo
    {
        private readonly ListaSupermercadoContext _context;
        public FotoProdutoRepo(ListaSupermercadoContext context)
        {
            _context = context;
        }

        public void AdicionarFotoProduto(Image foto)
        {
            MemoryStream ms = new();
            foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            FotoProduto fotoProduto = new()
            {
                Imagem = ms.ToArray(),
            };
            _context.FotosProdutos.Add(fotoProduto);
            _context.SaveChanges();
        }

        public void AtualizarFotoProduto(FotoProduto fotoProduto)
        {
            _context.Entry(fotoProduto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletarFotoProduto(Guid id)
        {
            FotoProduto? foto = _context.FotosProdutos.Find(id);
            if (foto != null)
            {
                _context.FotosProdutos.Remove(foto);
                _context.SaveChanges();
            }
        }

        public FotoProduto? ObtemFotoProdutoByID(Guid id)
        {
            return _context.FotosProdutos.Find(id);
        }

        public IEnumerable<FotoProduto> ObtemFotosProdutos()
        {
            return _context.FotosProdutos.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
