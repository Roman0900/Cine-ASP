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
   public class Neg_Salas
    {
        public Neg_Salas()
        {

        }
        Dao_Salas DS = new Dao_Salas();
        public void ActualizarSala(Ent_Salas ActSalas)
        {
            DS.ActualizarSala(ActSalas);
        }
        public DataTable conseguirTablaSalas()
        {
            return DS.conseguirTablaSalas("Salas", "Select Cod_Sala, Descripcion from Salas");
        }

        public DataTable conseguirTablaSalasDisponibles()
        {
            return DS.conseguirTablaSalas("Salas", "Select Cod_Sala, Descripcion from Salas Where Salas.Estado = 1");
        }
        public DataTable conseguirSalasDisponibles(string salas)
        {
            return DS.conseguirTablaSalas("Salas", "Select Cod_Sala, Descripcion from Salas Where Salas.Descripcion LIKE '"+salas+"%' and Salas.Estado = 1");
        }
    }
}
