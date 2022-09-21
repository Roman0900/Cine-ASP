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
   public class Dao_Salas
    {
        public Dao_Salas()
        {
            
        }

        AccesoDatos ds = new AccesoDatos();

        public DataTable conseguirTablaSalas(string NTabla, string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }

        public bool ComprobarIdSalas(String ID)
        {
            bool existente = ds.IdExistenteSala(ID);
            return existente;
        }
        public void ActualizarSala(Ent_Salas ActSalas)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Sala", SqlDbType.VarChar, 20);
            parametro.Value = ActSalas.Cod_Sala;
            parametro = comando.Parameters.Add("@N_Descripcion", SqlDbType.VarChar, 20);
            parametro.Value = ActSalas.Descripcion;
            parametro = comando.Parameters.Add("@N_S_Cod_Tipo", SqlDbType.VarChar, 20);
            parametro.Value = ActSalas.S_Cod_Tipo;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = ActSalas.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarSalas");
            return;
        }
    }
}
