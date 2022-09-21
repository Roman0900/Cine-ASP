using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
   public class Ent_GenerosxPeliculas
    {
        public string Genero { get; set; }
        public string Pelicula { get; set; }
        public string V_Pelicula { get; set; }
        public string V_Genero { get; set; }
        public bool Estado { get; set; }


        public Ent_GenerosxPeliculas(string nGenero, string nPelicula, string V_nGenero, string V_nPelicula)
        {
            Genero = nGenero;
            Pelicula = nPelicula;
            V_Genero = V_nGenero;
            V_Pelicula = V_nPelicula;
            Estado = true;
        }
    }
}
