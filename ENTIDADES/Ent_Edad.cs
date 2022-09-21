using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_Edad
    {
        public Ent_Edad(string NCod_Edad, string Nedad, bool Nestado)
        {
                Cod_Edad = NCod_Edad;
                Edad = Nedad;
                Estado = Nestado;
        }

        public string Cod_Edad { get; set; }
        public string Edad { get; set; }
        public bool Estado;
    }
}
