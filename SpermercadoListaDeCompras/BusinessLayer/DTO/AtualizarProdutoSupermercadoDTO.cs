namespace BusinessLayer.DTO
{
    public class AtualizarProdutoSupermercadoDTO
    {
        public int Id { get; set; }
        public decimal? Preco { get; set; }

        public int IdSupermercado { get; set; }

        public string CodigoBarrasProduto { get; set; }
    }
}
