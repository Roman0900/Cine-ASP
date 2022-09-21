using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTIDADES;

namespace DAO
{
    public class Dao_Funciones
    {
        public Dao_Funciones()
        {

        }

        AccesoDatos ds = new AccesoDatos();

        public DataTable conseguirTablaFunciones(string NTabla, string comandosql)
        {
            List<Ent_Funciones> lista = new List<Ent_Funciones>();
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }

        public void AniadirFuncionXdia(Ent_Funciones NuevoFuncionesxDia)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = NuevoFuncionesxDia.Cod_Funcion;
            parametro = comando.Parameters.Add("@N_Fecha", SqlDbType.Date);
            parametro.Value = NuevoFuncionesxDia.Fecha;
            parametro = comando.Parameters.Add("@N_Horario", SqlDbType.VarChar, 20);
            parametro.Value = NuevoFuncionesxDia.Hora;
            ds.EjecutarProcedimientoAlmacenado(comando, "Agregar_FuncionxDia");
            return;
        }

        public void AniadirFuncionXSala(Ent_Funciones NuevoFuncionesxSala)
        {

            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = NuevoFuncionesxSala.Cod_Funcion;
            parametro = comando.Parameters.Add("@N_Cod_Sala", SqlDbType.VarChar, 20);
            parametro.Value = NuevoFuncionesxSala.Cod_Sala;
            ds.EjecutarProcedimientoAlmacenado(comando, "Agregar_FuncionxSala");
            return;
        }

        public void AniadirFunciones(Ent_Funciones NuevoFunciones)
        {

            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = NuevoFunciones.Cod_Funcion;
            parametro = comando.Parameters.Add("@N_Cod_Pelicula", SqlDbType.VarChar, 20);
            parametro.Value = NuevoFunciones.Cod_Pelicula;
            ds.EjecutarProcedimientoAlmacenado(comando, "Agregar_Funciones");
            return;
        }
        public void ActualizarFunciones(Ent_Funciones actFunciones)
        {

            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = actFunciones.Cod_Funcion;
            parametro = comando.Parameters.Add("@Cod_Pelicula", SqlDbType.VarChar, 20);
            parametro.Value = actFunciones.Cod_Pelicula;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = actFunciones.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarFunciones");
            return;
        }
        public bool ComprobarIdSalaXFucnion(String ID, String ID2)
        {
            bool existente = ds.IdExistenteSalaXFuncion(ID, ID2);
            return existente;
        }

        public bool ComprobarIdFuncion(String ID)
        {
            bool existente = ds.IDExistenteFuncion(ID);
            return existente;
        }

    }
}
