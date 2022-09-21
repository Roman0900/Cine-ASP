    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
 
        public class Ent_Clientes
        {
            public string Mail { get; set; }
            public string Dni { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Nacimiento { get; set; }
            public string Contraseña { get; set; }
            public bool Tipo { get; set; }
            public bool Estado { get; set; }

            public Ent_Clientes(string nmail, string ndni, string nnombre, string napellido, string ncontraseña, string codgerente)
            {
                this.Mail = nmail;
                this.Dni = ndni;
                this.Nombre = nnombre;
                this.Apellido = napellido;
                this.Contraseña = ncontraseña;
            //un ejemplo de cod gerente
            if (codgerente == "gerentecodigo") this.Tipo = true;
            else this.Tipo = false;
                this.Estado = true;
            }


        }
    
}
