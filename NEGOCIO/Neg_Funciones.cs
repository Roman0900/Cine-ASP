using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using ENTIDADES;
using System.Data;
namespace NEGOCIO
{
    public class Neg_Funciones
    {
        public Neg_Funciones()
        {

        }
        Dao_Funciones DF = new Dao_Funciones();

        public DataTable conseguirtablaFunciones2d(string cod_pelicula)
        {
            return DF.conseguirTablaFunciones("Funciones", "select funciones.Cod_Funcion, convert(varchar, Fecha, 3) as Fecha, Horario, Salas.Descripcion as Sala, Salas.Cod_Sala, Precio from funciones inner join funcionxdia on(funciones.cod_funcion = funcionxdia.cod_funcion) inner join funcionxsala on(funciones.cod_funcion = funcionxsala.cod_funcion) inner join salas on(funcionxsala.cod_sala = salas.cod_sala) inner join tipos_de_funcion on(s_cod_tipo = cod_tipo) where funciones.Estado = 1 and funciones.cod_pelicula = '" + cod_pelicula + "' and Tipos_De_Funcion.Descripcion = '2d'");
        }
        public DataTable conseguirtablaFunciones()
        {
            return DF.conseguirTablaFunciones("Funciones", "select Cod_Funcion from Funciones where Estado = 1");
        }
        public DataTable conseguirtablaFunciones3d(string cod_pelicula)
        {
            return DF.conseguirTablaFunciones("Funciones", "select funciones.Cod_Funcion, convert(varchar, Fecha, 3) as Fecha, Horario, Salas.Descripcion as Sala, Salas.Cod_Sala, Precio from funciones inner join funcionxdia on(funciones.cod_funcion = funcionxdia.cod_funcion) inner join funcionxsala on(funciones.cod_funcion = funcionxsala.cod_funcion) inner join salas on(funcionxsala.cod_sala = salas.cod_sala) inner join tipos_de_funcion on(s_cod_tipo = cod_tipo) where funciones.Estado = 1 and funciones.cod_pelicula = '" + cod_pelicula + "' and Tipos_De_Funcion.Descripcion = '3d'");
        }
        public DataTable conseguirtablaFunciones4d(string cod_pelicula)
        {
            return DF.conseguirTablaFunciones("Funciones", "select funciones.Cod_Funcion, convert(varchar, Fecha, 3) as Fecha, Horario, Salas.Descripcion as Sala, Salas.Cod_Sala, Precio from funciones inner join funcionxdia on(funciones.cod_funcion = funcionxdia.cod_funcion) inner join funcionxsala on(funciones.cod_funcion = funcionxsala.cod_funcion) inner join salas on(funcionxsala.cod_sala = salas.cod_sala) inner join tipos_de_funcion on(s_cod_tipo = cod_tipo) where funciones.Estado = 1 and funciones.cod_pelicula = '" + cod_pelicula + "' and Tipos_De_Funcion.Descripcion = '4d'");
        }

        public void ActualizarFunciones(Ent_Funciones actFunciones)
        {
            DF.ActualizarFunciones(actFunciones);
        }

        public void AniadirFuncionesxDia(Ent_Funciones Nfuncion)
        {
            DF.AniadirFuncionXdia(Nfuncion);

        }
        public void AniadirFuncionesxSala(Ent_Funciones Nfuncion)
        {
            DF.AniadirFuncionXSala(Nfuncion);

        }
        public void AniadirFunciones(Ent_Funciones Nfuncion)
        {
            DF.AniadirFunciones(Nfuncion);

        }
        public bool IdExistenteFuncion(string ID)
        {

            bool existente = DF.ComprobarIdFuncion(ID);
            return existente;
        }

        public bool IdExistenteSalaXFuncion(string ID, string ID2)
        {
            
            bool existente = DF.ComprobarIdSalaXFucnion(ID, ID2);
            return existente;
        }

        public bool IdExistenteSalas(string ID)
        {
            Dao_Salas DS = new Dao_Salas();
            bool existente = DS.ComprobarIdSalas(ID);
            return existente;
        }
    }
}
