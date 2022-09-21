using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAO;
namespace NEGOCIO
{
   public  class Neg_GenerosxPeliculas
    {
        public Neg_GenerosxPeliculas()
        {

        }
        Dao_GenerosxPeliculas DC = new Dao_GenerosxPeliculas();
        public void AniadirGeneroxPelicula(Ent_GenerosxPeliculas nGeneroxPelicula)
        {
            DC.AniadirGeneroxPelicula(nGeneroxPelicula);
        
        }
       public bool IDexisteGeneroXPelicula(string ID, string ID2)
        {
            AccesoDatos ac = new AccesoDatos();
            bool existente = ac.IDexisteGeneroXPelicula(ID,ID2);
            return existente;
        }
        public void ActualizarGeneroxPelicula(Ent_GenerosxPeliculas ActGenero)
        {
            DC.ActualizarGeneroxPelicula(ActGenero);
        }

    }
}
