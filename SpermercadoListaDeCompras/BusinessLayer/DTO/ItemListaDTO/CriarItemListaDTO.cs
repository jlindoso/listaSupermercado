namespace BusinessLayer.DTO.ItemListaDTO
{
    public class CriarItemListaDTO
    {
        public int? Quantidade { get; set; }
        public bool? Comprado { get; set; }
        public decimal? Preco { get; set; }
        public int? IdSupermercado { get; set; }
        public string CodigoBarrasProduto { get; set; }
        public int IdLista { get; set; }
    }
}
