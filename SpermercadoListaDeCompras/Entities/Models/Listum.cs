namespace Entities.Entity.Models;

public partial class Listum
{
    public int Id { get; set; }

    public DateTime DataLista { get; set; }

    public decimal? Total { get; set; }

    public bool? EstaAtivo { get; set; } = true;

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }
}
