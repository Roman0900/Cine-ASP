using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
   public class Dao_Clientes
    {
       
            AccesoDatos ds = new AccesoDatos();

            public void AniadirCliente(Ent_Clientes NuevoCliente)
            {
                SqlCommand comando = new SqlCommand();
                SqlParameter parametro = new SqlParameter();
               parametro = comando.Parameters.Add("@N_Email", SqlDbType.VarChar, 50);
                parametro.Value = NuevoCliente.Mail;
                parametro = comando.Parameters.Add("@N_Dni", SqlDbType.VarChar, 20);
                parametro.Value = NuevoCliente.Dni;
                parametro = comando.Parameters.Add("@N_Nombre", SqlDbType.VarChar, 20);
                parametro.Value = NuevoCliente.Nombre;
                parametro = comando.Parameters.Add("@N_Apellido", SqlDbType.VarChar, 20);
                parametro.Value = NuevoCliente.Apellido;
                parametro = comando.Parameters.Add("@N_Contraseña", SqlDbType.VarChar, 20);
                parametro.Value = NuevoCliente.Contraseña;
                parametro = comando.Parameters.Add("@N_Tipo_gerente", SqlDbType.Bit);
                parametro.Value = NuevoCliente.Tipo;
                parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
                parametro.Value = NuevoCliente.Estado;
                ds.EjecutarProcedimientoAlmacenado(comando, "Nuevo_Cliente");
                return;
            }
        public void ActualizarCliente(Ent_Clientes Actclientes)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter parametro = new SqlParameter();
            parametro = comando.Parameters.Add("@N_Email", SqlDbType.VarChar, 50);
            parametro.Value = Actclientes.Mail;
            parametro = comando.Parameters.Add("@N_Dni", SqlDbType.VarChar, 20);
            parametro.Value = Actclientes.Dni;
            parametro = comando.Parameters.Add("@N_Nombre", SqlDbType.VarChar, 20);
            parametro.Value = Actclientes.Nombre;
            parametro = comando.Parameters.Add("@N_Apellido", SqlDbType.VarChar, 20);
            parametro.Value = Actclientes.Apellido;
            parametro = comando.Parameters.Add("@N_Contraseña", SqlDbType.VarChar, 20);
            parametro.Value = Actclientes.Contraseña;
            parametro = comando.Parameters.Add("@N_Tipo_gerente", SqlDbType.Bit);
            parametro.Value = Actclientes.Tipo;
            parametro = comando.Parameters.Add("@N_Estado", SqlDbType.Bit);
            parametro.Value = Actclientes.Estado;
            ds.EjecutarProcedimientoAlmacenado(comando, "ActualizarClientes");
            return;
        }
        public int verificarInicio(string email, string contraseña)
        {
            int inicia = ds.VerificandoCliente(email, contraseña);
            return inicia;

        }

        public bool MailExistente(string mail)
        {
            bool existente = ds.MailExistente(mail);
            return existente;
        }

        public Dao_Clientes()
            {

            }
        
    }
}
