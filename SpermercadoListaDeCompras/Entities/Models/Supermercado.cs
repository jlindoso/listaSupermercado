namespace Entities.Entity.Models;

public partial class Supermercado
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Logradouro { get; set; }

    public string? Cidade { get; set; }

    public string? Bairro { get; set; }

    public string? Estado { get; set; }

    public string? Cep { get; set; }

    public virtual ICollection<ItemListum> ItemLista { get; } = new List<ItemListum>();

    public virtual ICollection<ProdutoSupermercado> ProdutoSupermercados { get; } = new List<ProdutoSupermercado>();
}
