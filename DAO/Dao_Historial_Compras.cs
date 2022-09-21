using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
   public  class Dao_Historial_Compras
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable Conseguir_Historial(string NTabla, string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }
    }
}
