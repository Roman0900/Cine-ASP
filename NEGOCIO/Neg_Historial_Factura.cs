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
   public class Neg_Historial_Factura
    {


        public Neg_Historial_Factura()
        {

        }



        public DataTable Conseguir_Historial(string email)
        {
            Dao_Historial_Compras DP = new Dao_Historial_Compras();
            return DP.Conseguir_Historial("Facturas", "select Facturas.Email,Peliculas.Nombre_Pelicula ,Salas.Descripcion as Nombre_De_sala, COUNT(detallexfactura.cod_factura) as Entradas,Facturas.Total, convert(varchar, Facturas.Fecha, 3) as Fecha from Facturas inner join DetallexFactura on Facturas.Cod_Factura = DetallexFactura.Cod_Factura inner join Funciones on DetallexFactura.Cod_Funcion = Funciones.Cod_Funcion inner join Peliculas on Peliculas.Cod_Pelicula = Funciones.Cod_Pelicula inner join Salas on DetallexFactura.Cod_Sala = Salas.Cod_Sala where Facturas.Email = '"+ email +"' group by Facturas.Email,Peliculas.Nombre_Pelicula,Facturas.Total,Facturas.Fecha,Salas.Descripcion");


            
        }
        public DataTable FiltroPorpeli(string peli,string email)
        {
            Dao_Historial_Compras DP = new Dao_Historial_Compras();
            return DP.Conseguir_Historial("Facturas", "select Facturas.Email,Peliculas.Nombre_Pelicula ,Salas.Descripcion as Nombre_De_sala, COUNT(detallexfactura.cod_factura) as Entradas,Facturas.Total, convert(varchar, Facturas.Fecha, 3) as Fecha from Facturas inner join DetallexFactura on Facturas.Cod_Factura = DetallexFactura.Cod_Factura inner join Funciones on DetallexFactura.Cod_Funcion = Funciones.Cod_Funcion inner join Peliculas on Peliculas.Cod_Pelicula = Funciones.Cod_Pelicula inner join Salas on DetallexFactura.Cod_Sala = Salas.Cod_Sala where Facturas.Email = '" + email + "' and Peliculas.Nombre_Pelicula LIKE '" + peli + "%' group by Facturas.Email,Peliculas.Nombre_Pelicula,Facturas.Total,Facturas.Fecha,Salas.Descripcion");
           
        }


    }
}
