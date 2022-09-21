using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;
using System.Data;

namespace NEGOCIO
{
   public class Neg_Tipo_Funcion
    {
        public Neg_Tipo_Funcion()
        {

        }

        Dao_Tipo_Funcion DC = new Dao_Tipo_Funcion();

        public void Aniadirtipo_funcion(Ent_Tipo_Funcion nTipo)
        {
            DC.AniaditTipo_Funcion(nTipo);

        }
        public void ActualizarTipo_Funcion(Ent_Tipo_Funcion NuevoTipo)
        {
            DC.ActualizarTipo_Funcion(NuevoTipo);
        }
        public bool IdExistenteTipo(string ID)
        {
            bool existente = DC.IdExistenteTipo(ID);
            return existente;
        }

        public DataTable ConseguirTipos()
        {
            Dao_Tipo_Funcion DC = new Dao_Tipo_Funcion();
            return DC.conseguirTablaTipos("Tipos_De_Funcion", "Select * from Tipos_De_Funcion");

        }

    }
}
