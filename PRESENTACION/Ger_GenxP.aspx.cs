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
    public partial class Ger_GenxP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarViewPelis();
                CargarViewGeneros();
                CargarDownListGenero();
                CargarDownListPeli();
                lbl_User.Text = Session["Usuario"].ToString();
            }
           
        }

        public void CargarViewPelis()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            grid_Peliculas.DataSource = Neg_Pel.conseguirTodasLasPelisDisponibles();
            grid_Peliculas.DataBind();
        }

        public void CargarViewGeneros()
        {
            Neg_Genero Neg_Gen = new Neg_Genero();
            grid_Generos.DataSource = Neg_Gen.ConseguirGenerosDisponibles();
            grid_Generos.DataBind();
        }
        public void CargarGenerosxpeli()
        {
            Neg_Genero Neg_Gen = new Neg_Genero();
            grid_Generos.DataSource = Neg_Gen.ConseguirGenerosDisponiblesxpeli(TextBox1.Text);
            grid_Generos.DataBind();
        }

        public void CargarDownListPeli()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            DownList_Pelicula.DataSource = Neg_Pel.conseguirTodasLasPelisDisponibles();
            DownList_Pelicula.DataTextField = "Nombre_Pelicula";
            DownList_Pelicula.DataValueField = "Cod_Pelicula";
            DownList_Pelicula.DataBind();
        }

        public void CargarDownListGenero()
        {
            Neg_Genero Neg_Gen = new Neg_Genero();
            DownList_Genero.DataSource = Neg_Gen.ConseguirGenerosDisponibles();
            DownList_Genero.DataTextField = "Descripcion";
            DownList_Genero.DataValueField = "Codigo_De_Genero";
            DownList_Genero.DataBind();
        }

        protected void link_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainGerente.aspx");
        }

        protected void link_Insertar_Click(object sender, EventArgs e)
        {
            Neg_GenerosxPeliculas GenerosxPelicula = new Neg_GenerosxPeliculas();

            if (!GenerosxPelicula.IDexisteGeneroXPelicula(DownList_Genero.SelectedValue, DownList_Pelicula.SelectedValue))
            {
                Ent_GenerosxPeliculas Nc = new Ent_GenerosxPeliculas(DownList_Genero.SelectedValue, DownList_Pelicula.SelectedValue, "no se usa", "no se usa");
                GenerosxPelicula.AniadirGeneroxPelicula(Nc);

                DatosCargados.ForeColor = Color.Green;
                DatosCargados.Text = "Se han cargado exitosamente";
            }
            else
            {
                DatosCargados.ForeColor = Color.Red;
                DatosCargados.Text = "La relacion entre Pelicula - Genero ya existe";

            }
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CargarGenerosxpeli();
            TextBox1.Text = "";
        }
        public void CargarPelis()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            grid_Peliculas.DataSource = Neg_Pel.conseguirTodasLasPelisporfiltro(TextBox2.Text);
            grid_Peliculas.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CargarPelis();
            TextBox2.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            CargarViewGeneros();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            CargarViewPelis();
        }
    }
}