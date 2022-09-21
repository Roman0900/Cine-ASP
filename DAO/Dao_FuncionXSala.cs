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
    public class Dao_FuncionXSala
    {
        AccesoDatos ds = new AccesoDatos();
        public void ActualizarFuncionXSala(Ent_FuncionXSala actfuncionXSala)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = actfuncionXSala.CodigoFuncion;
            parametro = comando.Parameters.Add("@Cod_Sala", SqlDbType.VarChar, 20);
            parametro.Value = actfuncionXSala.CodSala;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = actfuncionXSala.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "AtualizarFuncionxSala");
            return;
        }
    }
}
