using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ENTIDADES;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class Ger_Peliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarDownListEdad();
                    lbl_User.Text = Session["Usuario"].ToString();
            }
        }

        protected void link_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainGerente.aspx");
        }

        protected void link_Insertar_Click(object sender, EventArgs e)
        {
            bool check = true;

            Neg_Peliculas peliculas = new Neg_Peliculas();

            if (txt_CodPelicula.Text.Trim() == "")
            {
                check = false;
                txt_CodPelicula.BackColor = Color.Red;
            }

            if (txt_Duracion.Text.Trim() == "")
            {
                check = false;
                txt_Duracion.BackColor = Color.Red;

            }

            if (txt_Nombre.Text.Trim() == "")
            {
                check = false;
                txt_Nombre.BackColor = Color.Red;

            }
            if (txt_ImagenURL.Text.Trim() == "")
            {
                check = false;
                txt_ImagenURL.BackColor = Color.Red;

            }

            int Pestreno=0;

            if (Si.Checked == true)
            {
                Pestreno =1;
            }else
            {
                Pestreno = 0;
            }

            if (No.Checked== true)
            {
                Pestreno = 0;
            }

            if (!peliculas.IdExistente(txt_CodPelicula.Text) && check == true)
            {
                Ent_Peliculas Pp = new Ent_Peliculas(txt_CodPelicula.Text, txt_Nombre.Text, DownList_Edad.SelectedValue, txt_Duracion.Text, txt_ImagenURL.Text, Pestreno);
                peliculas.AniadirPeliculas(Pp);
                peliculas.AñadirPeliculasXEdad(Pp);
                DatosCargados.Text = "Se han cargado exitosamente";
                DatosCargados.ForeColor = Color.Green;
                txt_CodPelicula.Text = "";                
                txt_Duracion.Text = "";
                txt_Nombre.Text = "";
                txt_ImagenURL.Text = "";
                txt_CodPelicula.BackColor = Color.Gray;
                txt_Duracion.BackColor = Color.Gray;
                txt_ImagenURL.BackColor = Color.Gray;
                txt_Nombre.BackColor = Color.Gray;
            }
            else
            {
                DatosCargados.ForeColor = Color.Red;
                DatosCargados.Text = "El id de la pelicula ya existe o hay campos en blanco";


            }
            
        }

        public void cargarDownListEdad()
        {
            Neg_Edad Neg_Ed = new Neg_Edad();
            DownList_Edad.DataSource = Neg_Ed.ConseguirEdadesDisponibles();
            DownList_Edad.DataTextField = "Ed_Edad";
            DownList_Edad.DataValueField = "Ed_Cod_Edad";
            DownList_Edad.DataBind();
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}