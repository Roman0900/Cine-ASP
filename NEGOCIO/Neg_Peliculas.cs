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
   public class Neg_Peliculas
    {
        public Neg_Peliculas()
        {

        }
        Dao_Peliculas DP = new Dao_Peliculas();
        AccesoDatos ac = new AccesoDatos();
        public DataTable conseguirTabla()
        {
            return DP.conseguirTablaPeliculas("Peliculas", "Select Peliculas.Cod_Pelicula, Nombre_Pelicula, Duracion, Ed_Edad, ImagenURL from Peliculas inner join EdadxPelicula on (Peliculas.Cod_Pelicula = ExP_Cod_Pelicula) inner join Edades on (Ed_Cod_Edad = ExP_Cod_Edad) where Estrenos=0 and Peliculas.Estado=1");
        }

        public DataTable conseguirTodasLasPelisDisponibles()
        {
            return DP.conseguirTablaPeliculas("Peliculas", "Select Peliculas.Cod_Pelicula, Nombre_Pelicula, Duracion, Ed_Edad, ImagenURL from Peliculas inner join EdadxPelicula on (Peliculas.Cod_Pelicula = ExP_Cod_Pelicula) inner join Edades on (Ed_Cod_Edad = ExP_Cod_Edad)");
        }

        public DataTable conseguirTodasLasPelisporfiltro(string pel)
        {
            return DP.conseguirTablaPeliculas("Peliculas", "Select Peliculas.Cod_Pelicula, Nombre_Pelicula, Duracion, Ed_Edad, ImagenURL from Peliculas inner join EdadxPelicula on (Peliculas.Cod_Pelicula = ExP_Cod_Pelicula) inner join Edades on (Ed_Cod_Edad = ExP_Cod_Edad) Where Peliculas.Nombre_Pelicula LIKE '" + pel+"%'and Peliculas.Estado = 1");
        }

        public DataTable conseguirTablaEstrenos()
        {
            return DP.conseguirTablaPeliculas("Peliculas", "Select Peliculas.Cod_Pelicula, Nombre_Pelicula, Duracion, Ed_Edad, ImagenURL from Peliculas inner join EdadxPelicula on (Peliculas.Cod_Pelicula = ExP_Cod_Pelicula) inner join Edades on (Ed_Cod_Edad = ExP_Cod_Edad) where Estrenos=1 and Peliculas.Estado=1");
        }

        public bool IdExistente(string ID)
        {
            
            bool existente = DP.IdExistente(ID);
            return existente;
        }
        public string buscar_nombre_dePelicula_PorID(string id)
        {
            return ac.buscar_nombre_dePelicula_PorID(id);
        }
        public void AniadirPeliculas(Ent_Peliculas Ppelicula)
        {
            DP.AniadirPelicula(Ppelicula);

        }

        public void AñadirPeliculasXEdad(Ent_Peliculas Ppelicula)
        {
            DP.AñadirPelisXEdad(Ppelicula);
        }
        public void ActualizarPeliculas(Ent_Peliculas Ppelicula)
        {
            DP.ActualizarPelicula(Ppelicula);
        }
        public string buscarEdadPelicula(string cod_pelicula)
        {
            return ac.buscarEdadPelicula(cod_pelicula);
        }
       public void ActualizarPelisXEdad(Ent_Peliculas ActPeliculas)
        {
            DP.ActualizarPelisXEdad(ActPeliculas);
        }
    }
}
