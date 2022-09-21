using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_Tablas
    {

        public Ent_Tablas(string T1, string T2, string T3, string T4, string T5, string T6)
        {
            Tabla1 = T1;
            Tabla2 = T2;
            Tabla3 = T3;
            Tabla4 = T4;
            Tabla5 = T5;
            Tabla6 = T6;
        }

        public string Tabla1 { get; set; }
        public string Tabla2 { get; set; }
        public string Tabla3 { get; set; }
        public string Tabla4 { get; set; }
        public string Tabla5 { get; set; }
        public string Tabla6 { get; set; }
    }
}
