using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_Butacas
    {
        public Ent_Butacas(string NCodF, string NCodS, string NUs, int NBut, bool NEst)
        {
            Cod_Funcion = NCodF;
            Cod_Sala = NCodS;
            Usuario = NUs;
            Butaca = NBut;
            Estado = NEst;
        }
        public string Cod_Funcion {get; set;}
        public string Cod_Sala {get; set;}
        public string Usuario { get; set; }
        public int Butaca {get; set;}
        public bool Estado { get; set; }
    }
}
