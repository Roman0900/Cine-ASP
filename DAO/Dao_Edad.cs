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
   public class Dao_Edad
    {
        AccesoDatos ds = new AccesoDatos();

        public Dao_Edad()
        {

        }
        AccesoDatos dsa = new AccesoDatos();
        public void ActualizarEdades(Ent_Edad ent_Edad)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Edad", SqlDbType.VarChar, 20);
            parametro.Value = ent_Edad.Edad;
            parametro = comando.Parameters.Add("@N_Cod_Edad", SqlDbType.VarChar, 20);
            parametro.Value = ent_Edad.Cod_Edad;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = ent_Edad.Estado;
            dsa.EjecutarProcedimientoAlmacenado(comando, "ActualizarEdades");
            return;
        }

        public DataTable conseguirTablaEdades(string NTabla, string comandosql)
        {
            
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }
    }
}
