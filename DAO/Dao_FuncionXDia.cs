using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ENTIDADES;
using System.Data.SqlClient;
namespace DAO
{
    public class Dao_FuncionXDia
    {
        AccesoDatos ds = new AccesoDatos();
        public void ActualizarFuncionXDia(Ent_FuncionXDia actfuncionXDia)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = actfuncionXDia.CodigoFuncion;
            parametro = comando.Parameters.Add("@N_Fecha", SqlDbType.Date);
            parametro.Value = actfuncionXDia.Fecha;
            parametro = comando.Parameters.Add("@N_Horario", SqlDbType.VarChar, 20);
            parametro.Value = actfuncionXDia.Horario;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = actfuncionXDia.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "AtualizarFuncionxDia");
            return;
        }
    }
}
