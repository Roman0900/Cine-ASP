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
    public class Dao_Facturas
    {

        AccesoDatos ds = new AccesoDatos();
        public void ActualizarEstadoFactura(Ent_Facturas ent_Facturas)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@Cod_Factura", SqlDbType.VarChar, 20);
            parametro.Value = ent_Facturas.Cod_Factura;
            parametro = comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20);
            parametro.Value = ent_Facturas.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarEstadoFactura");
            return;
        }
        public void ActualizarEstadoDetalleXFactura(Ent_DetalleXFacturas ent_DetalleXFacturas)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Cod_Detalle", SqlDbType.Int);
            parametro.Value = ent_DetalleXFacturas.Cod_Detalle;
            parametro = comando.Parameters.Add("@N_Cod_Factura", SqlDbType.VarChar, 20);
            parametro.Value = ent_DetalleXFacturas.Cod_Factura;
            parametro = comando.Parameters.Add("@N_Cod_Sala", SqlDbType.VarChar, 20);
            parametro.Value = ent_DetalleXFacturas.Cod_Sala;
            parametro = comando.Parameters.Add("@N_Cod_Funcion", SqlDbType.VarChar, 20);
            parametro.Value = ent_DetalleXFacturas.Cod_Funcion;
            parametro = comando.Parameters.Add("N_Cod_Butaca", SqlDbType.Int);
            parametro.Value = ent_DetalleXFacturas.Cod_Butaca;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.VarChar, 20);
            parametro.Value = ent_DetalleXFacturas.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarEstadoDetalleXFactura");
            return;
        }
        public DataTable ConseguirClientes(string NTabla, string comandosql)
        {
            DataTable tabla = ds.ObtenerTabla(NTabla, comandosql);
            return tabla;
        }
    }
}
