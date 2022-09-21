using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class Historial_De_Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lblusuario.Text = Session["Usuario"].ToString();
            Cargarhistorial();

        }
        public void Cargarhistorial()
        {
            string email;
            email= Session["Usuario"].ToString();

            Neg_Historial_Factura Neg_his = new Neg_Historial_Factura();
            GridHistorial.DataSource = Neg_his.Conseguir_Historial(email);
            GridHistorial.DataBind();
        }
        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void link_Volver_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Elegir_Pelicula.aspx");
        }
        public void Filtrarporpeli()
        {
            string email;
            email = Session["Usuario"].ToString();
            Neg_Historial_Factura Neg_his = new Neg_Historial_Factura();
            GridHistorial.DataSource = Neg_his.FiltroPorpeli(TextBox1.Text,email);
            GridHistorial.DataBind();
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrarporpeli();
            TextBox1.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Cargarhistorial();
        }
    }
}