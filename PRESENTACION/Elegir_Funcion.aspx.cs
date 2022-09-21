using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
namespace PRESENTACION
{
    public partial class Elegir_Funcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Neg_Peliculas NP = new Neg_Peliculas();
                lbl_Pelicula.Text = NP.buscar_nombre_dePelicula_PorID(Session["CodPelicula"].ToString());

                cargarGridviewFunciones2d();
                cargarGridviewFunciones3d();
                cargarGridviewFunciones4d();

                if (grid_2D.Rows.Count == 0) Label2.Visible = false;
                if (grid_3D.Rows.Count == 0) Label3.Visible = false;
                if (grid_4D.Rows.Count == 0) Label4.Visible = false;

                lbl_User.Text = Session["Usuario"].ToString();
            }
        }
    
        public void cargarGridviewFunciones2d()
        {
            Neg_Funciones Neg_Fun = new Neg_Funciones();
            grid_2D.DataSource = Neg_Fun.conseguirtablaFunciones2d(Session["CodPelicula"].ToString());
            grid_2D.DataBind();
        }

        public void cargarGridviewFunciones3d()
        {
            Neg_Funciones Neg_Fun = new Neg_Funciones();
            grid_3D.DataSource = Neg_Fun.conseguirtablaFunciones3d(Session["CodPelicula"].ToString());
            grid_3D.DataBind();
        }
        public void cargarGridviewFunciones4d()
        {
            Neg_Funciones Neg_Fun = new Neg_Funciones();
            grid_4D.DataSource = Neg_Fun.conseguirtablaFunciones4d(Session["CodPelicula"].ToString());
            grid_4D.DataBind();
        }
        protected void link_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Elegir_Pelicula.aspx");
        }
        protected void grid_2D_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSessions(grid_2D);
            Response.Redirect("Elegir_Butacas.aspx");
        }
        protected void grid_3D_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarSessions(grid_3D);
            Response.Redirect("Elegir_Butacas.aspx");
        }

        protected void grid_4D_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSessions(grid_4D);
            Response.Redirect("Elegir_Butacas.aspx");
        }

        private void CargarSessions(GridView GR)
        {
            Session.Add("Cod_funcion", GR.SelectedRow.Cells[1].Text);
            Session.Add("Fecha_funcion", GR.SelectedRow.Cells[2].Text);
            Session.Add("Hora_Funcion", GR.SelectedRow.Cells[3].Text);
            Session.Add("Sala", GR.SelectedRow.Cells[4].Text);
            Session.Add("Cod_Sala", GR.SelectedRow.Cells[5].Text);
            Session.Add("Precio", Convert.ToInt32( GR.SelectedRow.Cells[6].Text));
        }

        protected void grid_2D_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
            
            

        }

        protected void grid_3D_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            
        }

        protected void grid_4D_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           e.Row.Cells[5].Visible = false;
              e.Row.Cells[6].Visible = false;
            
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}