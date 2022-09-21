using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
namespace PRESENTACION
{
    public partial class Login : System.Web.UI.Page
    {
        // bueno esto checkea si hay un mail y contraseña guardados en la cookie, lo copie y pegue pero funciona xd
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txt_Email.Text = Request.Cookies["UserName"].Value;
                    txt_Contraseña.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void Link_IniciarSesion_Click(object sender, EventArgs e)
        {
            // declaro la clase y llamo a la funcion para verificar el inicio dandole el valor que devuelve la funcion a "pasa"
            Neg_Clientes nc = new Neg_Clientes();
            int pasa = nc.verificarInicio(txt_Email.Text, txt_Contraseña.Text);
            // checkea si esta el "recordarme" apretado y si lo esta y es correcto el inicio lo guarda, sino le resta dias para que se borre por tiempo el guardado
            // nose si hace falta pero lo pongo porque venia asi xd esta parte tambien la copie pero funciona

           
            if (Recordarme.Checked && pasa>0)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["UserName"].Value = txt_Email.Text.Trim();
                Response.Cookies["Password"].Value = txt_Contraseña.Text.Trim();
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            // checkea si el inicio fue correcto y si lo fue, lo manda a elegir pelicula que entiendo que es la pagina principal del cliente
            // si no es correcto, desesconde el texto que dice que la contraseña o el mail estaban mal, nose si queda mejor aca tambien borrar los textbox pero a mi me es incomodo volver a 
            // escribir todo y odio cuando me hacen eso las paginas xd asi que me gusta mas asi
            switch (pasa)
            {
                case 0:
                    incorrecto.Visible = true;
                    break;
                case 1:
                    Session.Add("Usuario", txt_Email.Text);
                    
                    Response.Redirect("Elegir_Pelicula.aspx");
                    break;
                case 2:
                    Session.Add("Usuario", txt_Email.Text);
                    Response.Redirect("MainGerente.aspx");
                    break;
            }
        }

        protected void link_Registrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}