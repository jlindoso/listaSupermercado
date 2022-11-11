namespace Entities.Entity.Models;

public partial class Produto
{
    public string CodigoBarras { get; set; } = null!;

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public string? Foto { get; set; }

    public virtual ICollection<ItemListum> ItemLista { get; } = new List<ItemListum>();

    public virtual ICollection<ProdutoSupermercado> ProdutoSupermercados { get; } = new List<ProdutoSupermercado>();
}
