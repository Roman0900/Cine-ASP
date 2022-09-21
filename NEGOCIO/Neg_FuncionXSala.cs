using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDADES;
namespace NEGOCIO
{
    public class Neg_FuncionXSala
    {
        public void ActualizarFuncionXSala(Ent_FuncionXSala actfuncionXSala)
        {
            Dao_FuncionXSala DF = new Dao_FuncionXSala();
            DF.ActualizarFuncionXSala(actfuncionXSala);
        }
    }
}
