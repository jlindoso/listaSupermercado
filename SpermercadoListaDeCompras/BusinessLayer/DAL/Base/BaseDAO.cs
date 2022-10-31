using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL.Base
{
    public class BaseDAO
    {
        public string ConnectionString { get; set; } = "Data Source=localhost;Initial Catalog=ListaSupermercado;Integrated Security=True";
        public SqlConnection Con { get; set; }
        public SqlDataReader Dr { get; set; }

        public string SqlString  { get; set; } = string.Empty;

        public BaseDAO()
        {
            Con = new(ConnectionString);
        }

    }
}
