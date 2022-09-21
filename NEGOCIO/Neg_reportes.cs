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
   public class Neg_reportes
    {
        Dao_reportes DP = new Dao_reportes();



        public DataTable ConseguirDesdeHasta(string anio,string mes, string dia,string anio1,string mes1,string dia1)
        {
            return DP.Conseguirdesdehasta("DetallexFactura", "Select Peliculas.Nombre_Pelicula, COUNT(Peliculas.Cod_Pelicula) as [Cantidad de entradas vendidas] from DetallexFactura inner join Funciones on DetallexFactura.Cod_Funcion=Funciones.Cod_Funcion inner join Peliculas on Funciones.Cod_Pelicula=Peliculas.Cod_Pelicula inner join FuncionXDia on DetallexFactura.Cod_Funcion=FuncionXDia.Cod_Funcion where FuncionXDia.Fecha>'" + anio+"-"+mes+"-"+dia+ "' and FuncionXDia.Fecha <'" + anio1 + "-" + mes1 + "-" + dia1 + "'group by Peliculas.Nombre_Pelicula");
            
        }
       
        public DataTable Cargartotalrecaudado()
        {
            return DP.Cargartotalrecaudado("Facturas", "Select Clientes.Nombre,Clientes.Apellido, Clientes.Email, SUM(Facturas.Total)as Recaudado from Facturas inner join Clientes on Facturas.Email=Clientes.Email group by Clientes.Nombre,Clientes.Apellido, Clientes.Email");

        }
        public DataTable Cargartotalrecaudadoxemail(string valor)
        {
            return DP.Cargartotalrecaudadoxemail("Facturas", "Select Clientes.Nombre,Clientes.Apellido, Clientes.Email, SUM(Facturas.Total)as Recaudado from Facturas inner join Clientes on Facturas.Email=Clientes.Email where Clientes.Email='"+valor +"' group by Clientes.Nombre,Clientes.Apellido, Clientes.Email");

        }

        public DataTable Conseguirmesespeficicoigual(string anio, string mes)
        {
            return DP.Conseguirmesespeficicoigual("DetallexFactura", "Select Peliculas.Nombre_Pelicula, COUNT(Peliculas.Cod_Pelicula) as [Cantidad de entradas vendidas] from DetallexFactura inner join Funciones on DetallexFactura.Cod_Funcion=Funciones.Cod_Funcion inner join Peliculas on Funciones.Cod_Pelicula=Peliculas.Cod_Pelicula inner join FuncionXDia on DetallexFactura.Cod_Funcion=FuncionXDia.Cod_Funcion where FuncionXDia.Fecha LIKE'%" + anio + "-" + mes + "%'group by Peliculas.Nombre_Pelicula");

        }
        
        public DataTable Cargaranioespeficico(string anio)
        {
            return DP.Conseguiranioespecifico("DetallexFactura", "Select Peliculas.Nombre_Pelicula, COUNT(Peliculas.Cod_Pelicula) as [Cantidad de entradas vendidas] from DetallexFactura inner join Funciones on DetallexFactura.Cod_Funcion=Funciones.Cod_Funcion inner join Peliculas on Funciones.Cod_Pelicula=Peliculas.Cod_Pelicula inner join FuncionXDia on DetallexFactura.Cod_Funcion=FuncionXDia.Cod_Funcion where FuncionXDia.Fecha LIKE'" + anio + "%'group by Peliculas.Nombre_Pelicula");

        }




    }
}
