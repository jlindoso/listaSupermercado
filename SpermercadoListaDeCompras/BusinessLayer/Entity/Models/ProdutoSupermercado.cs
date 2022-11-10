using System;
using System.Collections.Generic;

namespace BusinessLayer.Entity.Models;

public partial class ProdutoSupermercado
{
    public int Id { get; set; }

    public decimal? Preco { get; set; }

    public int IdSupermercado { get; set; }

    public string CodigoBarrasProduto { get; set; } = null!;

    public virtual Produto CodigoBarrasProdutoNavigation { get; set; } = null!;

    public virtual Supermercado Supermercado { get; set; } = null!;
}
