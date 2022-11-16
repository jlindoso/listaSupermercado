namespace Entities.Entity.Models;

public partial class ProdutoSupermercado
{
    public int Id { get; set; }

    public decimal? Preco { get; set; }

    public int IdSupermercado { get; set; }

    public string CodigoBarrasProduto { get; set; }

    public virtual Produto CodigoBarrasProdutoNavigation { get; set; }

    public virtual Supermercado Supermercado { get; set; }
}
