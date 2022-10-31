using BusinessLayer.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ProdutoSupermercado: BaseModel
    {
        public Produto Produto { get; set; } = new();
        public virtual Supermercado Supermercado { get; set; } = new();
        public double Preco { get; set; } = 0;
    }
}
