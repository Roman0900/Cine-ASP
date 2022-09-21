using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;

namespace NEGOCIO
{
    public class Neg_Clientes
    {
        /** public DataTable getTablaClientes()
         {
            
         }*/
            

        public Neg_Clientes()
        {

        }
        Dao_Clientes DC = new Dao_Clientes();
        public void aniadirCliente(Ent_Clientes Ncliente)
        {
            
            DC.AniadirCliente(Ncliente);

        }
        public void ActualizarCliente(Ent_Clientes Acliente)
        {
            DC.ActualizarCliente(Acliente);
        }
        public int verificarInicio(string email, string contraseña)
        {
            // declaro la clase y le doy el valor que devuelve la clase de verificar inicio a inicia que es un bool con true si el inicio fue correcto
            
            int inicia = DC.verificarInicio(email, contraseña);
            // devuelvo el valor a la pagina
            return inicia;
        }
        public bool MailExistente(string mail)
        {
           
            bool existente = DC.MailExistente(mail);
            return existente;
        }
        
    }

    
}

