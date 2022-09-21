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
    public class Dao_Peliculas
    {
        AccesoDatos ds = new AccesoDatos();

        public Dao_Peliculas ()
        {

        }

        public DataTable conseguirTablaPeliculas(string NTabla, string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }

        public void AniadirPelicula(Ent_Peliculas NuevaPeliculas)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_CodPelicula", SqlDbType.VarChar, 20);
            parametro.Value = NuevaPeliculas.Cod_Pelicula;
            parametro = comando.Parameters.Add("@N_Nombre_Pelicula", SqlDbType.VarChar, 50);
            parametro.Value = NuevaPeliculas.Nombre_Pelicula;
            parametro = comando.Parameters.Add("@N_Duracion", SqlDbType.VarChar, 20);
            parametro.Value = NuevaPeliculas.Duracion;
            parametro = comando.Parameters.Add("@N_ImagenURL", SqlDbType.VarChar, 50);
            parametro.Value = NuevaPeliculas.URL;
            parametro = comando.Parameters.Add("@N_Estrenos", SqlDbType.Bit);
            parametro.Value = NuevaPeliculas.Estreno;
            ds.EjecutarProcedimientoAlmacenado(comando, "Agregar_Pelicula");
            return;
        }
        public void ActualizarPelicula(Ent_Peliculas Actpelicula)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_CodPelicula", SqlDbType.VarChar, 20);
            parametro.Value = Actpelicula.Cod_Pelicula;
            parametro = comando.Parameters.Add("@N_Nombre_Pelicula", SqlDbType.VarChar, 50);
            parametro.Value = Actpelicula.Nombre_Pelicula;
            parametro = comando.Parameters.Add("@N_Duracion", SqlDbType.VarChar, 20);
            parametro.Value = Actpelicula.Duracion;
            parametro = comando.Parameters.Add("@N_URL", SqlDbType.VarChar, 2048);
            parametro.Value = Actpelicula.URL;
            parametro = comando.Parameters.Add("@N_Estrenos", SqlDbType.Bit);
            parametro.Value = Actpelicula.Estreno;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = Actpelicula.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarPeliculas");
            return;
        }
        public void AñadirPelisXEdad(Ent_Peliculas NuevaPeliculas)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Pelicula", SqlDbType.VarChar, 20);
            parametro.Value = NuevaPeliculas.Cod_Pelicula;
            parametro = comando.Parameters.Add("@N_Cod_Edad", SqlDbType.VarChar, 50);
            parametro.Value = NuevaPeliculas.Edad;
            ds.EjecutarProcedimientoAlmacenado(comando, "Nuevo_EdadXPeli"); 
        }
        public void ActualizarPelisXEdad(Ent_Peliculas ActPeliculas)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Pelicula", SqlDbType.VarChar, 20);
            parametro.Value = ActPeliculas.Cod_Pelicula;
            parametro = comando.Parameters.Add("@N_Cod_Edad", SqlDbType.VarChar, 50);
            parametro.Value = ActPeliculas.Edad;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = ActPeliculas.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarEdadXPelicula");
        }
        public bool IdExistente(string ID)
        {
            bool existente = ds.IdExistentePelicula(ID);
            return existente;
        }

    }
}
