using System.Text.Json.Serialization;

namespace Entities.Entity.Models;

public partial class ItemListum
{
    public int Id { get; set; }

    public int? Quantidade { get; set; }

    public bool? Comprado { get; set; }
    public decimal? Preco { get; set; }

    public int? IdSupermercado { get; set; }

    public string CodigoBarrasProduto { get; set; }
    public int IdLista { get; set; }
    public virtual Produto CodigoBarrasProdutoNavigation { get; set; }
    public virtual Supermercado? IdSupermercadoNavigation { get; set; }
    [JsonIgnore]
    public virtual Listum IdListumNavigation { get; set; }
}
