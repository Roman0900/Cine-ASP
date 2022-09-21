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
    public class Dao_Tablas
    {
        public Dao_Tablas()
        {

        }


        AccesoDatos ds = new AccesoDatos();

        public DataTable conseguirTodasLasTablas()
        {
            DataTable tabla = ds.ConseguirTodasLasTablas();
            return tabla;
        }

        public DataTable conseguirTablaAdecuada(string NTabla, string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }

    }
}
