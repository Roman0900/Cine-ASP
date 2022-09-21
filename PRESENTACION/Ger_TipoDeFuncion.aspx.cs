using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using ENTIDADES;
using System.Drawing;

namespace PRESENTACION
{
    public partial class Ger_TipoDeFuncion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lbl_User.Text = Session["Usuario"].ToString();
            }
        }

        protected void link_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainGerente.aspx");
        }

        protected void link_Insertar_Click(object sender, EventArgs e)
        {
            Neg_Tipo_Funcion Tipo = new Neg_Tipo_Funcion();
            bool check = true;
            if (txt_Codigo.Text.Trim() == "")
            {
                check = false;
                txt_Codigo.BackColor = Color.Red;
            }
            if (txt_Descripcion.Text.Trim() == "")
            {
                check = false;
                txt_Descripcion.BackColor = Color.Red;
            }
            if (txt_Precio.Text.Trim() == "")
            {
                check = false;
                txt_Precio.BackColor = Color.Red;
            }

            if (!Tipo.IdExistenteTipo(txt_Codigo.Text) && check)
            {

                Ent_Tipo_Funcion Nc = new Ent_Tipo_Funcion(txt_Codigo.Text, txt_Descripcion.Text, txt_Precio.Text);
                Tipo.Aniadirtipo_funcion(Nc);

                CargadeDatos.ForeColor = Color.Green;
                CargadeDatos.Text = "Los datos se cargaron correctamente";
                txt_Codigo.Text = "";
                txt_Descripcion.Text = "";
                txt_Precio.Text = "";
                txt_Codigo.BackColor = Color.Gray;
                txt_Descripcion.BackColor = Color.Gray;
                txt_Precio.BackColor = Color.Gray;
            }
            else
            {
                CargadeDatos.ForeColor = Color.Red;
                CargadeDatos.Text = "El id ya esta repetido o hay campos vacios";

            }

        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}