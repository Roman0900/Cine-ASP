using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;
namespace NEGOCIO
{
    public class Neg_FuncionXDia
    {
        public void ActualizarFuncionXdia(Ent_FuncionXDia actfuncionXDia)
        {
            Dao_FuncionXDia dao_FuncionXDia = new Dao_FuncionXDia();
            dao_FuncionXDia.ActualizarFuncionXDia(actfuncionXDia);
        }
    }
}
