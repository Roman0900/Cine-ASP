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
    public class Neg_Edad
    {
        public Neg_Edad()
        {

        }
        public void ActualizarEdades(Ent_Edad ent_Edad)
        {
            Dao_Edad DE = new Dao_Edad();
            DE.ActualizarEdades(ent_Edad);
        }

        public DataTable ConseguirEdades()
        {
            Dao_Edad DE = new Dao_Edad();
            return DE.conseguirTablaEdades("Edades", "Select * from Edades");
         }

        public DataTable ConseguirEdadesDisponibles()
        {
            Dao_Edad DE = new Dao_Edad();
            return DE.conseguirTablaEdades("Edades", "Select * from Edades Where Estado=1");
        }

        public DataTable ConseguirPelisPorEdades(string edad)
        {
            Dao_Edad DE = new Dao_Edad();
            return DE.conseguirTablaEdades("Peliculas", "Select Cod_Pelicula, Nombre_Pelicula, ImagenURL, Ed_Edad, Duracion from Peliculas inner join EdadxPelicula on (Peliculas.Cod_Pelicula = ExP_Cod_Pelicula) inner join Edades on (Ed_Cod_Edad = ExP_Cod_Edad) where Ed_Cod_Edad = '" + edad + "' and Peliculas.Estado = 1");
        }
    }
}
