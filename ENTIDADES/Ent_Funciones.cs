using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_Funciones
    {
        public Ent_Funciones(string NCodF, string NCodP, string NCodS, string NFecha, string NHora)
        {
            Cod_Funcion = NCodF;
            Cod_Pelicula = NCodP;
            Cod_Sala = NCodS;
            Fecha = NFecha;
            Hora = NHora;
            Estado = true;
        }

        public string Cod_Funcion { get; set; }
        public string Cod_Pelicula { get; set; }
        public string Cod_Sala { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public bool Estado { get; set; }
    }
}
