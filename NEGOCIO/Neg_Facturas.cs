using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDADES;
using System.Data;
namespace NEGOCIO
{
    public class Neg_Facturas
    {
        Dao_Facturas DP = new Dao_Facturas();
        AccesoDatos ac = new AccesoDatos();
        public void ActualizarEstadoFactura(Ent_Facturas ent_Facturas)
        {
            Dao_Facturas dao_Facturas = new Dao_Facturas();
            dao_Facturas.ActualizarEstadoFactura(ent_Facturas);
        }
        public void ActualizarEstadoDetalleXFactura(Ent_DetalleXFacturas ent_DetalleXFacturas)
        {
            Dao_Facturas dao_Facturas = new Dao_Facturas();
            dao_Facturas.ActualizarEstadoDetalleXFactura(ent_DetalleXFacturas);
        }
        public DataTable conseguirTodoslosclientesDisponibles()
        {
            return DP.ConseguirClientes("Clientes", "Select * from Clientes");
        }
    }

}
