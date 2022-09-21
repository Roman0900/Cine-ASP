using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
  public class Ent_Genero
    {
        public Ent_Genero(string NCod, string NNomb, bool Nestado)
        {
            CodigoGenero = NCod;
            NombreGenero = NNomb;
            Estado = Nestado;
        }

       public string CodigoGenero { get; set; }
       public string NombreGenero { get; set; }
        public bool Estado;

    }
}
