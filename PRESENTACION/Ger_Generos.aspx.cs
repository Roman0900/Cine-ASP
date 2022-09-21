using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using NEGOCIO;
using ENTIDADES;

namespace PRESENTACION
{
    public partial class Ger_Generos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            Neg_Genero Generos = new Neg_Genero();
            bool check = true;
            if (txt_CodigoGenero.Text.Trim() == "")
            {
                check = false;
                txt_CodigoGenero.BackColor = Color.Red;
            }
            if (txt_Descripcion.Text.Trim() == "")
            {
                check = false;
                txt_Descripcion.BackColor = Color.Red;
            }
            if (!Generos.IDExistenteGerente(txt_CodigoGenero.Text) && check)
            {
                Ent_Genero Nc = new Ent_Genero(txt_CodigoGenero.Text, txt_Descripcion.Text, true);
                Generos.aniadirGeneros(Nc);
                DatosCargados.Text = "Se han cargado exitosamente";
                DatosCargados.ForeColor = Color.Green;
                txt_CodigoGenero.Text = "";
                txt_Descripcion.Text = "";
                txt_CodigoGenero.BackColor = Color.Gray;
                txt_Descripcion.BackColor = Color.Gray;
            }
            else
            {
                DatosCargados.ForeColor = Color.Red;
                DatosCargados.Text = "El ID ya existe";
            }
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}