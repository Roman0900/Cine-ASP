using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using ENTIDADES;

namespace PRESENTACION
{
    public partial class Confirmar_Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Neg_Peliculas NP = new Neg_Peliculas();
                lbl_Usuario.Text = Session["Usuario"].ToString();
                lbl_Pelicula.Text = NP.buscar_nombre_dePelicula_PorID(Session["CodPelicula"].ToString());
                lbl_Funcion.Text = Session["Cod_Funcion"].ToString();
                lbl_Sala.Text = Session["Sala"].ToString();
                lbl_Fecha.Text = Session["Fecha_Funcion"].ToString();
                lbl_Hora.Text = Session["Hora_Funcion"].ToString();
                lbl_Butacas.Text = "";
                foreach (int Butaka in (List<int>) Session["Butacas"])
                {
                    lbl_Butacas.Text = lbl_Butacas.Text + Butaka.ToString() + " - ";
                }
                int total = (int)Session["Precio"] * (int)Session["Cantidad"];
                lbl_Total.Text = total.ToString();
                lbl_User.Text = Session["Usuario"].ToString();

            }
        }

        protected void link_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Elegir_Butacas.aspx");
        }

        protected void link_Aceptar_Click(object sender, EventArgs e)
        {
            List<int> BLista = (List<int>)Session["Butacas"];
            Neg_Butacas Neg_But = new Neg_Butacas();
            Ent_Butacas NuevaButaca = new Ent_Butacas(Session["Cod_Funcion"].ToString(), Session["Cod_Sala"].ToString(), Session["Usuario"].ToString(), 0, false);
            Neg_But.GenerarFactura(NuevaButaca);
            for (int i=0; i<(int)Session["Cantidad"];i++)
            {
                NuevaButaca.Butaca = BLista[i];
                Neg_But.ActualizarButaca(NuevaButaca);
            }

            Lbl_Listo.Visible = true;
            link_Inicio.Visible = true;
            link_Aceptar.Visible = false;
            link_Cancelar.Visible = false;
        }

        protected void link_Inicio_Click(object sender, EventArgs e)
        {
            string user = Session["Usuario"].ToString();
            Session.Clear();
            Session.Add("Usuario", user);
            Response.Redirect("Elegir_Pelicula.aspx");
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}