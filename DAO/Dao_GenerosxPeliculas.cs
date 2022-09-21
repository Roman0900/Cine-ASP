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
   public class Dao_GenerosxPeliculas : AccesoDatos
    {
        AccesoDatos ds = new AccesoDatos();
        public Dao_GenerosxPeliculas()
        {

        }

        public void AniadirGeneroxPelicula(Ent_GenerosxPeliculas NuevoGenero)
        {
           
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
           parametro = comando.Parameters.Add("@N_CodPelicula", SqlDbType.VarChar, 20);
            parametro.Value = NuevoGenero.Pelicula;
            parametro = comando.Parameters.Add("@N_CodGenero", SqlDbType.VarChar, 20);
            parametro.Value = NuevoGenero.Genero;
            ds.EjecutarProcedimientoAlmacenado(comando, "Agregar_GeneroxPelicula");
        }
        public void ActualizarGeneroxPelicula(Ent_GenerosxPeliculas ActGenero)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@Cod_G_V", SqlDbType.VarChar, 20);
            parametro.Value = ActGenero.V_Genero;
            parametro = comando.Parameters.Add("@Cod_P_V", SqlDbType.VarChar, 20);
            parametro.Value = ActGenero.V_Pelicula;
            parametro = comando.Parameters.Add("@N_Gp_Cod_G", SqlDbType.VarChar, 20);
            parametro.Value = ActGenero.Genero;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = ActGenero.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarGenerosxPelicula");
        }

    }
}
