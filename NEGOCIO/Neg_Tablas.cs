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
    public class Neg_Tablas
    {
        public Neg_Tablas()
        {

        }
        Dao_Tablas DT = new Dao_Tablas();

        public DataTable conseguirTodasLasTablas()
        {
            
            return DT.conseguirTodasLasTablas();

        }

        public DataTable ConseguirTablaAdecuada(string NuevaTabla)
        {
            if (NuevaTabla == "FuncionXDia")
            return DT.conseguirTablaAdecuada(NuevaTabla, "Select Cod_Funcion, convert(varchar, Fecha, 105) as Fecha, Horario, Estado from " + NuevaTabla);
            else
            return DT.conseguirTablaAdecuada(NuevaTabla, "Select * from " + NuevaTabla);

        }

    }
}
