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
    public class Neg_Genero
    {
        public Neg_Genero()
        {

        }

        public DataTable ConseguirGeneros()
        {
            Dao_Genero DP = new Dao_Genero();
            return DP.conseguirTablaGeneros("Generos", "Select * from Generos");

        }
        public void ActualizarGeneros(Ent_Genero actGenero)
        {
            Dao_Genero DP = new Dao_Genero();
            DP.ActualizarGeneros(actGenero);
        }
        public DataTable ConseguirGenerosDisponibles()
        {
            Dao_Genero DP = new Dao_Genero();
            return DP.conseguirTablaGeneros("Generos", "Select * from Generos where Generos.Estado=1");

        }
        public DataTable ConseguirGenerosDisponiblesxpeli(string gen)
        {
            Dao_Genero DP = new Dao_Genero();
           return DP.conseguirTablaGenerosxpeli("Generos", "Select  Cod_Pelicula,Nombre_Pelicula,Duracion,Generos.Codigo_De_Genero,Generos.Descripcion from Generos inner join GenerosxPelicula on (Generos.Codigo_De_Genero=GenerosxPelicula.Gp_Cod_G) inner join Peliculas on (Peliculas.Cod_Pelicula=GenerosxPelicula.Gp_Cod_P) where Peliculas.Nombre_Pelicula LIKE'" + gen+"%' and  Generos.Estado=1 and Peliculas.Estado=1");
         

        }
        

        public void aniadirGeneros(Ent_Genero nGeneros)
        {
            Dao_Genero DC = new Dao_Genero();
            DC.AniadirGeneros(nGeneros);

        }

        public DataTable ConseguirTablaPorGenero(string gen)
        {
            Dao_Peliculas DP = new Dao_Peliculas(); 
            return DP.conseguirTablaPeliculas("Peliculas", "Select Cod_Pelicula, Nombre_Pelicula, ImagenURL, Ed_Edad, Duracion from Peliculas inner join GenerosxPelicula on (Cod_Pelicula = Gp_Cod_P) inner join EdadxPelicula on (Peliculas.Cod_Pelicula = ExP_Cod_Pelicula) inner join Edades on (Ed_Cod_Edad = ExP_Cod_Edad) where Gp_Cod_G = '" + gen + "'and Peliculas.Estado = 1");
        }
        
        public DataTable ConseguirTablaPorGeneroyedad(string gen, string edad)
        {
            Dao_Peliculas DP = new Dao_Peliculas();
            return DP.conseguirTablaPeliculas("Peliculas", "Select Cod_Pelicula, Nombre_Pelicula, ImagenURL, Ed_Edad, Duracion from Peliculas inner join GenerosxPelicula on (Cod_Pelicula = Gp_Cod_P) inner join EdadxPelicula on (Peliculas.Cod_Pelicula = ExP_Cod_Pelicula) inner join Edades on (Ed_Cod_Edad = ExP_Cod_Edad) where Gp_Cod_G = '" + gen + "' and Ed_Cod_Edad = '" + edad + "'and Peliculas.Estado = 1");
        }

        public bool IDExistenteGerente(string ID)
        {
            Dao_Genero DG = new Dao_Genero();
            bool existente = DG.IDExistenteGen(ID);
            return existente;
        }



    }
}
