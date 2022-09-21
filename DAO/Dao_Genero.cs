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
    public class Dao_Genero
    {
        AccesoDatos ds = new AccesoDatos();

        public Dao_Genero()
        {

        }

        public DataTable conseguirTablaGeneros(string NTabla,string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla,comandosql);
            return tabla;
        }
        public DataTable conseguirTablaGenerosxpeli(string NTabla, string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }

        public bool IDExistenteGen(string ID)
        {
            bool existente = ds.IdExistenGenero(ID);
            return existente;
        }

        public void AniadirGeneros(Ent_Genero NuevoGenero)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Codigo_De_Genero", SqlDbType.VarChar, 20);
            parametro.Value = NuevoGenero.CodigoGenero;
            parametro = comando.Parameters.Add("@N_Descripcion", SqlDbType.VarChar, 20);
            parametro.Value = NuevoGenero.NombreGenero;
            ds.EjecutarProcedimientoAlmacenado(comando, "Agregar_Genero");
            return;
        }
        public void ActualizarGeneros(Ent_Genero actGenero)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Codigo_De_Genero", SqlDbType.VarChar, 20);
            parametro.Value = actGenero.CodigoGenero;
            parametro = comando.Parameters.Add("@N_Descripcion", SqlDbType.VarChar, 20);
            parametro.Value = actGenero.NombreGenero;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = actGenero.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarGeneros");
            return;
        }
    }
}
