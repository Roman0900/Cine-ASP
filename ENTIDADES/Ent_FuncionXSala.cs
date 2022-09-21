using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_FuncionXSala
    {
        public Ent_FuncionXSala(string NCod, string Ncodsala, bool Nestado)
        {
            CodigoFuncion = NCod;
            CodSala = Ncodsala;
            Estado = Nestado;
        }

        public string CodigoFuncion { get; set; }
        public string CodSala
        {
            get; set;
        }
        public bool Estado;

    }
}
