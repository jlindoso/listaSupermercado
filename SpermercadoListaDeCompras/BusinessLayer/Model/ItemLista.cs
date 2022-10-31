using BusinessLayer.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ItemLista: BaseModel
    {
        public int Quantidade { get; set; }
        public bool Comprado { get; set; } = false;
        public double Preco { get; set; } = 0;
        public virtual Supermercado? Supermercado { get; set; } = null;
        public virtual Lista Lista { get; set; } = new();
    }
}
