using BusinessLayer.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Lista: BaseModel
    {
        public DateTime Data { get; set; } = DateTime.Now;
        public double Total { get; set; } = 0;
        public virtual Usuario Usuario { get; set; } = new();
        public bool EstaAtivo { get; set; } = true;

    }
}
