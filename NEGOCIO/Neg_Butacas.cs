using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;
using System.Data;

namespace NEGOCIO
{
    public class Neg_Butacas
    {
        public Neg_Butacas()
        {
           
        }

        Dao_Butacas DButacas = new Dao_Butacas();

        public void ActualizarButaca(Ent_Butacas Nbut)
        {
            DButacas.ActualizarButacas(Nbut);

        }

        public void GenerarFactura(Ent_Butacas Nbut)
        {
            DButacas.GenerarFactura(Nbut);
        }

        public DataTable ConseguirButacas(string Cod_Funcion, string Cod_Sala)
        {
            return DButacas.conseguirTablaButacas("AsientosxSalaxFuncion", "Select Disponible from AsientosxSalaxFuncion where Cod_Sala = '" + Cod_Sala +"' and  Cod_Funcion = '"+ Cod_Funcion +"'");
        }

        public DataTable ConseguirButacasPorFuncion(string Cod_Funcion)
        {
            return DButacas.conseguirTablaButacas("AsientosxSalaxFuncion", "Select * from AsientosxSalaxFuncion where Cod_Funcion = '" + Cod_Funcion + "'");
        }
    }
}
