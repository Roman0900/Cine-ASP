using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_Peliculas
    {
        
            public Ent_Peliculas(string nCodigo_Pelicula, string nNombre_Pelicula, string nEdad, string nDuracion, string N_URL, int nEstreno)
            {
                Cod_Pelicula = nCodigo_Pelicula;
                Nombre_Pelicula = nNombre_Pelicula;
                Edad = nEdad;
                Duracion = nDuracion;
                URL = N_URL;
                Estreno = nEstreno;
                Estado = true;
            }
       

        public string Cod_Pelicula { get; set; }
        public string Nombre_Pelicula { get; set; }
        public string Edad { get; set; }
        public string Duracion { get; set; }
        public string URL { get; set; }
        public int Estreno { get; set; }
        public bool Estado { get; set; }


    }
}
