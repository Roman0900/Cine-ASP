using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
   public class Ent_Tipo_Funcion
    {
        public string Cod_Tipo { get; set; }
        public string Descripcion { get; set; }
        public string precio { get; set; }
        public bool Estado { get; set; }
        public Ent_Tipo_Funcion(string nCod_Tipo, string nDescripcion, string nPrecio)
        {
            Cod_Tipo = nCod_Tipo;
            Descripcion = nDescripcion;
            precio = nPrecio;
            Estado = true;
        }
    }
}
