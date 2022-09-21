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
    public partial class Elegir_Pelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDownListGenero();
                cargarDownListEdad();
                cargarGridviewPeliculas();
                cargarGridviewEstrenos();
                lbl_User.Text = Session["Usuario"].ToString();
                ViewState["PageCount"] = 0;
                ViewState["PageCountEs"] = 0;
            }
        CurrentPageCartelera = (int) ViewState["PageCount"];
        CurrentPageEstreno = (int)ViewState["PageCountEs"];
    }

        int CurrentPageCartelera;
        int CurrentPageEstreno;

        private void DataListPaging(DataTable dt)
        {
            PagedDataSource PD = new PagedDataSource();
            PD.DataSource = dt.DefaultView;
            PD.PageSize = 2;
            PD.AllowPaging = true;
            PD.CurrentPageIndex = CurrentPageCartelera;
            if (PD.IsFirstPage) btn_First.ForeColor = Color.Red;
            else btn_First.ForeColor = Color.Black;
            btn_First.Enabled = !PD.IsFirstPage;
            if (PD.IsFirstPage) btn_Prev.ForeColor = Color.Red;
            else btn_Prev.ForeColor = Color.Black;
            btn_Prev.Enabled = !PD.IsFirstPage;
            if (PD.IsLastPage) btn_Next.ForeColor = Color.Red;
            else btn_Next.ForeColor = Color.Black;
            btn_Next.Enabled = !PD.IsLastPage;
            if (PD.IsLastPage) btn_Last.ForeColor = Color.Red;
            else btn_Last.ForeColor = Color.Black;
            btn_Last.Enabled = !PD.IsLastPage;
            ViewState["TotalCount"] = PD.PageCount;
            list_Cartelera.DataSource = PD;
            list_Cartelera.DataBind();
            ViewState["PagedDataSurce"] = dt;
        }

        private void DataListPagingEstreno(DataTable dt)
        {
            PagedDataSource PD = new PagedDataSource();
            PD.DataSource = dt.DefaultView;
            PD.PageSize = 2;
            PD.AllowPaging = true;
            PD.CurrentPageIndex = CurrentPageEstreno;
             if (PD.IsFirstPage) btn_FirstEs.ForeColor = Color.Red;
             else btn_FirstEs.ForeColor = Color.Black;
            btn_FirstEs.Enabled = !PD.IsFirstPage;
            if (PD.IsFirstPage) btn_PrevEs.ForeColor = Color.Red;
            else btn_PrevEs.ForeColor = Color.Black;
            btn_PrevEs.Enabled = !PD.IsFirstPage;
            if (PD.IsLastPage) btn_NextEs.ForeColor = Color.Red;
            else btn_NextEs.ForeColor = Color.Black;
            btn_NextEs.Enabled = !PD.IsLastPage;
            if (PD.IsLastPage) btn_LastEs.ForeColor = Color.Red;
            else btn_LastEs.ForeColor = Color.Black;
            btn_LastEs.Enabled = !PD.IsLastPage;
            ViewState["TotalCountEs"] = PD.PageCount;
            list_Estrenos.DataSource = PD;
            list_Estrenos.DataBind();
            ViewState["PagedDataSurceEs"] = dt;
        }

        protected void link_Aceptar_Click(object sender, EventArgs e)
        {

        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void cargarGridviewPeliculas()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            DataListPaging(Neg_Pel.conseguirTabla());
            list_Cartelera.DataBind();
        }
        public void cargarGridviewEstrenos()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            DataListPagingEstreno(Neg_Pel.conseguirTablaEstrenos());
            list_Estrenos.DataBind();
        }

        public void cargarDownListGenero()
        {
            Neg_Genero Neg_Gen = new Neg_Genero();
            Downlist_Generos.DataSource = Neg_Gen.ConseguirGenerosDisponibles();
            Downlist_Generos.DataTextField = "Descripcion";
            Downlist_Generos.DataValueField = "Codigo_De_Genero";
            Downlist_Generos.DataBind();            
        }

        public void cargarDownListEdad()
        {
            Neg_Edad Neg_Ed = new Neg_Edad();
            DownList_Edad.DataSource = Neg_Ed.ConseguirEdadesDisponibles();
            DownList_Edad.DataTextField = "Ed_Edad";
            DownList_Edad.DataValueField = "Ed_Cod_Edad";
            DownList_Edad.DataBind();
        }


        protected void Seleccionar(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                Session.Add("CodPelicula", e.CommandArgument);
                Response.Redirect("Elegir_Funcion.aspx");
            }
        }

        protected void CargarPelisGenero()
        {
            Neg_Genero Neg_Gen = new Neg_Genero();
            DataListPaging(Neg_Gen.ConseguirTablaPorGenero(Downlist_Generos.SelectedValue));
            list_Cartelera.DataBind();
        }
        protected void CargarPelisGeneroyedad()
        {
            Neg_Genero Neg_Gen = new Neg_Genero();
            DataListPaging(Neg_Gen.ConseguirTablaPorGeneroyedad(Downlist_Generos.SelectedValue, DownList_Edad.SelectedValue));
            list_Cartelera.DataBind();
        }
        protected void CargarPelisEdad()
        {
            Neg_Edad Neg_Ed = new Neg_Edad();
            DataListPaging(Neg_Ed.ConseguirPelisPorEdades(DownList_Edad.SelectedValue));
            list_Cartelera.DataBind();
        }

        protected void link_Reiniciar_Click(object sender, EventArgs e)
        {
          cargarGridviewPeliculas();
        }

        protected void btn_Filtrar_Click(object sender, EventArgs e)
        {
            CargarPelisGenero();
        }

        protected void btn_Filtrar_Edad_Click(object sender, EventArgs e)
        {
            CargarPelisEdad();
        }

        protected void btn_GenYEdad_Click(object sender, EventArgs e)
        {
            CargarPelisGeneroyedad();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Historial_De_Compras.aspx");
        }
                
        protected void btn_First_Click(object sender, EventArgs e)
        {
            CurrentPageCartelera = (int)ViewState["PageCount"];
            CurrentPageCartelera = 0;
            ViewState["PageCount"] = CurrentPageCartelera;

            DataListPaging((DataTable)ViewState["PagedDataSurce"]);
        }

        protected void btn_Prev_Click(object sender, EventArgs e)
        {
            CurrentPageCartelera = (int)ViewState["PageCount"];
            CurrentPageCartelera -= 1;
            ViewState["PageCount"] = CurrentPageCartelera;

            DataListPaging((DataTable)ViewState["PagedDataSurce"]);
        }

        protected void btn_Next_Click(object sender, EventArgs e)
        {
            CurrentPageCartelera = (int)ViewState["PageCount"];
            CurrentPageCartelera += 1;
            ViewState["PageCount"] = CurrentPageCartelera;
            DataListPaging((DataTable)ViewState["PagedDataSurce"]);
        }

        protected void btn_Last_Click(object sender, EventArgs e)
        {
            CurrentPageCartelera = (int)ViewState["TotalCount"] - 1;
            DataListPaging((DataTable)ViewState["PagedDataSurce"]);
        }
        
        //////////////////////////////////////////////////////////////////
        
        protected void btn_FirstEs_Click(object sender, EventArgs e)
        {
            CurrentPageEstreno = (int)ViewState["PageCountEs"];
            CurrentPageEstreno = 0;
            ViewState["PageCountEs"] = CurrentPageEstreno;

            DataListPagingEstreno((DataTable)ViewState["PagedDataSurceEs"]);
        }

        protected void btn_PrevEs_Click(object sender, EventArgs e)
        {
            CurrentPageEstreno = (int)ViewState["PageCountEs"];
            CurrentPageEstreno -= 1;
            ViewState["PageCountEs"] = CurrentPageEstreno;

            DataListPagingEstreno((DataTable)ViewState["PagedDataSurceEs"]);
        }

        protected void btn_NextEs_Click(object sender, EventArgs e)
        {
            CurrentPageEstreno = (int)ViewState["PageCountEs"];
            CurrentPageEstreno += 1;
            ViewState["PageCountEs"] = CurrentPageEstreno;
            DataListPagingEstreno((DataTable)ViewState["PagedDataSurceEs"]);
        }

        protected void btn_LastEs_Click(object sender, EventArgs e)
        {
            CurrentPageEstreno = (int)ViewState["TotalCountEs"] - 1;
            DataListPagingEstreno((DataTable)ViewState["PagedDataSurceEs"]);
        }
    }

    
}