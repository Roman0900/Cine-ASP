using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

//Probando el GitHub a ver si quedo al menos desde aca 

namespace DAO
    {
    public class AccesoDatos
    {
        String ruta =
      "Data Source=localhost\\sqlexpress;Initial Catalog=CINE;Integrated Security=True";

        public AccesoDatos()
        {
            // TODO: Agregar aquí la lógica del constructor
        }

        private SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(ruta);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int VerificandoCliente(string email, string contraseña)
        {
            // declaro inicia que es true si el inicio es correcto al final, establece la coneccion y el comando todo eso, el select con el mail y la contraseña
            int inicia = 0;
            SqlConnection cnCINE = new SqlConnection();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Email, contraseña, Tipo_gerente  from Clientes";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            // busca cada fila del select y compara con los datos de contraseña y mail que tenemos de los textbox de la pagina, si los dos son correctos el inicio es correcto
            // sino "inicia" es false
            while (IS.Read() == true)
            {
                if (string.Compare(email.ToLower(), IS[0].ToString().ToLower()) == 0 && string.Compare(contraseña, IS[1].ToString()) == 0)
                {
                    
                    if (IS[2].ToString() == "True" )
                    {
                        inicia = 2;
                    }else
                    {
                        inicia = 1;
                    }
                }
            }
            cnCINE.Close();
            return inicia;
        }
        public string buscarEdadPelicula(string cod_pelicula)
        {
            string edad = "";
            SqlConnection cnCINE = new SqlConnection();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select ed_edad from edadxpelicula inner join edades on (exp_cod_edad = ed_cod_edad) where exp_cod_pelicula = '" + cod_pelicula + "'";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while(IS.Read())
            edad = IS[0].ToString();
            cnCINE.Close();
            return edad;
        }
        public DataTable ConseguirTodasLasTablas()
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            DataTable t = Conexion.GetSchema("Tables");
            Conexion.Close();
            return t;

        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }


        public bool IDexisteGeneroXPelicula(string ID, string ID2)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Gp_Cod_G,Gp_Cod_P from GenerosxPelicula";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0 && string.Compare(ID2, IS[1].ToString()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }

        public bool IdExistenGenero(string ID)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Codigo_De_Genero from Generos";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }

        public bool MailExistente(string Mail)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Email from Clientes";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(Mail.ToLower(), IS[0].ToString().ToLower()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }


        public bool IdExistenteTipo(string ID)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Cod_Tipo from Tipos_De_Funcion";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }

        public bool IdExistentePelicula(string ID)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Cod_Pelicula from Peliculas";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }
        public string buscar_nombre_dePelicula_PorID(string ID)
        {
            string  nombre = "";
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Cod_Pelicula, nombre_pelicula from Peliculas";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0)
                {
                    nombre = IS[1].ToString();
                }
            }
            cnCINE.Close();
            return nombre;
        }
        public bool IDExistenteFuncion(string ID)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Cod_Funcion from Funciones";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }

        public bool IdExistenteSalaXFuncion(string ID, string ID2)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Cod_Funcion, Cod_Sala from FuncionXSala";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0 && string.Compare(ID2, IS[1].ToString()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }

        public bool IdExistenteSala(string ID)
        {
            bool existente = false;
            SqlConnection cnCINE = new SqlConnection();
            AccesoDatos ac = new AccesoDatos();
            cnCINE = this.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Select Cod_Sala from Salas";
            comando.Connection = cnCINE;
            SqlDataReader IS = comando.ExecuteReader();
            while (IS.Read() == true)
            {
                if (string.Compare(ID, IS[0].ToString()) == 0)
                {
                    existente = true;
                }
            }
            cnCINE.Close();
            return existente;
        }

    }

    }
