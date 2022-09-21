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
   public class Dao_Tipo_Funcion
    {
        AccesoDatos ds = new AccesoDatos();
        public void AniaditTipo_Funcion(Ent_Tipo_Funcion NuevoTipo)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Tipo", SqlDbType.VarChar, 20);
            parametro.Value = NuevoTipo.Cod_Tipo;
            parametro = comando.Parameters.Add("@N_Descripcion", SqlDbType.VarChar, 20);
            parametro.Value = NuevoTipo.Descripcion;
            parametro = comando.Parameters.Add("@N_Precio", SqlDbType.Float);
            parametro.Value = NuevoTipo.precio;
            ds.EjecutarProcedimientoAlmacenado(comando, "Agregar_Tipos_Funcion");
            return;
        }
        public void ActualizarTipo_Funcion(Ent_Tipo_Funcion NuevoTipo)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Tipo", SqlDbType.VarChar, 20);
            parametro.Value = NuevoTipo.Cod_Tipo;
            parametro = comando.Parameters.Add("@N_Descripcion", SqlDbType.VarChar, 20);
            parametro.Value = NuevoTipo.Descripcion;
            parametro = comando.Parameters.Add("@N_Precio", SqlDbType.Float);
            parametro.Value = NuevoTipo.precio;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = NuevoTipo.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "AtualizarTipoFuncion");
            return;
        }
        public bool IdExistenteTipo(string ID)
        {
            bool existente = ds.IdExistenteTipo(ID);
            return existente;
        }

        public DataTable conseguirTablaTipos(string NTabla, string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }

    }
}
