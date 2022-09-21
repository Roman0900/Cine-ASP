using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_FuncionXDia
    {
        public Ent_FuncionXDia(string NCod, string Nfecha, string Nhorario, bool Nestado )
        {
            CodigoFuncion = NCod;
            Fecha = Nfecha;
            Horario = Nhorario;
            Estado = Nestado;
        }

        public string CodigoFuncion { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public bool Estado { get; set; }
    }
}
