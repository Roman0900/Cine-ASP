using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using System.Data;
using System.Drawing;

namespace PRESENTACION
{
    public partial class Elegir_Butacas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Neg_Peliculas NP = new Neg_Peliculas();
                 lbl_Pelicula.Text = NP.buscar_nombre_dePelicula_PorID(Session["CodPelicula"].ToString());
                 lbl_Funcion.Text = Session["Cod_Funcion"].ToString() + "    -    " + Session["Fecha_Funcion"].ToString() + "    -    " + Session["Hora_Funcion"].ToString();
                 InhabilitarButacas();
                lbl_User.Text = Session["Usuario"].ToString();
            }
        }

        protected void InhabilitarButacas()
        {
            Neg_Butacas NegBut = new Neg_Butacas();
            DataTable TablaButacas = NegBut.ConseguirButacas(Session["Cod_Funcion"].ToString(), Session["Cod_Sala"].ToString());
           
            for (int i = 0; i < 50; i++)
            {
                if (Convert.ToInt32(TablaButacas.Rows[i][0]) == 0)
                {
                    boxlist_Butacas.Items[i].Enabled = false;
                    boxlist_Butacas.Items[i].Text = string.Format("<span style= 'color:red' >" + (i + 1));
                }

            }
            
        }

        protected void link_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Elegir_Funcion.aspx");
        }

        protected void btn_Siguiente_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (rbl_Medio_De_Pago.SelectedItem==null )
            {
                check = false;
                lbl_Error_Pago.Visible = true;
            }

            if (boxlist_Butacas.SelectedItem == null)
            {
                check = false;
                lbl_Error_Butacas.Visible = true;
            }

            if( check==true)
            {
                List<int> Butacas = new List<int>();
                int Cantidad = 0;
                foreach (ListItem Items in boxlist_Butacas.Items)
                {
                    if (Items.Selected)
                    {
                        Butacas.Add(Convert.ToInt32(Items.Value));
                        Cantidad++;
                    }
                }
                Session.Add("Butacas", Butacas);
                Session.Add("Cantidad", Cantidad);
                Response.Redirect("Confirmar_Compra.aspx");
            }
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}