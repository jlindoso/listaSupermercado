namespace BusinessLayer.DTO
{
    public class BuscarItemListaDTO
    {
        public int Id { get; set; }
        public int? Quantidade { get; set; }
        public bool? Comprado { get; set; }
        public decimal? Preco { get; set; }
        public int? IdSupermercado { get; set; }
        public string CodigoBarrasProduto { get; set; }
        public int IdLista { get; set; }
    }
}
