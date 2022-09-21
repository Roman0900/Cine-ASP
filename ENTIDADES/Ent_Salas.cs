using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_Salas
    {
        public string Cod_Sala { get; set; }
        public string Descripcion { get; set; }
        public string S_Cod_Tipo { get; set; }
        public bool Estado { get; set; }
        public Ent_Salas(string Ncod, string NDes, string NS_Cod_Tipo)
        {
            Cod_Sala = Ncod;
            Descripcion = NDes;
            S_Cod_Tipo = NS_Cod_Tipo;
            Estado = true;
        }
    }
}
