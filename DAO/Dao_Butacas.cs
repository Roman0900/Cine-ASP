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
    public class Dao_Butacas
    {
        public Dao_Butacas()
        {

        }

        AccesoDatos ds = new AccesoDatos();

        public void ActualizarButacas(Ent_Butacas NButaca)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = NButaca.Cod_Funcion;
            parametro = comando.Parameters.Add("@N_Cod_Sala", SqlDbType.VarChar, 20);
            parametro.Value = NButaca.Cod_Sala;
            parametro = comando.Parameters.Add("@N_Cod_Butaca", SqlDbType.Int);
            parametro.Value = NButaca.Butaca;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = NButaca.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarButacas");
            return;
        }

        public void GenerarFactura(Ent_Butacas NButaca)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Email", SqlDbType.VarChar, 50);
            parametro.Value = NButaca.Usuario;
            ds.EjecutarProcedimientoAlmacenado(comando, "NuevaFactura");
            return;
        }

        public DataTable conseguirTablaButacas(string NTabla, string comandosql)
        {
            
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }
    }
}
