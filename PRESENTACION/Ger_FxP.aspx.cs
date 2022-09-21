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
    public partial class Ger_FxP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarViewSalas();
                CargarViewPeliculas();
                CargarDownListSala();
                CargarDownListPeli();
                CargarPelis();
                lbl_User.Text = Session["Usuario"].ToString();
                
            }
        }

        protected void link_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainGerente.aspx");
        }

        public void CargarDownListSala()
        {
            
            Neg_Salas Neg_Sal = new Neg_Salas();
            DownList_Cod_Sala.DataSource = Neg_Sal.conseguirTablaSalasDisponibles();
            DownList_Cod_Sala.DataTextField = "Descripcion";
            DownList_Cod_Sala.DataValueField = "Cod_Sala";
            DownList_Cod_Sala.DataBind();
        }

        public void CargarDownListPeli()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            DownList_Cod_Peli.DataSource = Neg_Pel.conseguirTodasLasPelisDisponibles();
            DownList_Cod_Peli.DataTextField = "Nombre_Pelicula";
            DownList_Cod_Peli.DataValueField = "Cod_Pelicula";
            DownList_Cod_Peli.DataBind();
        }

        public void CargarViewSalas()
        {
            Neg_Salas Neg_S = new Neg_Salas();
            grid_Salas.DataSource = Neg_S.conseguirTablaSalasDisponibles();
            grid_Salas.DataBind();
        }
        public void CargarSalas()
        {
            Neg_Salas Neg_S = new Neg_Salas();
            grid_Salas.DataSource = Neg_S.conseguirSalasDisponibles(TextBox1.Text);
            grid_Salas.DataBind();
        }

        public void CargarViewPeliculas()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            grid_Peliculas.DataSource = Neg_Pel.conseguirTodasLasPelisDisponibles();
            grid_Peliculas.DataBind();
        }
        public void CargarPelis()
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            grid_Peliculas.DataSource = Neg_Pel.conseguirTodasLasPelisporfiltro(TextBox1.Text);
            grid_Peliculas.DataBind();
        }

        protected void link_Insertar_Click(object sender, EventArgs e)
        {
            bool bool_fecha = true;
            Neg_Funciones NuevaFuncion = new Neg_Funciones();
            bool check = true;
            if (txt_CodFuncion.Text.Trim() == "")
            {
                check = false;
                txt_CodFuncion.BackColor = Color.Red;

            }
                        
            if (txt_Fecha.Text.Trim() == "")
            {
                check = false;
                txt_Fecha.BackColor = Color.Red;

            }
            if (txt_Horario.Text.Trim() == "")
            {
                check = false;
                txt_Horario.BackColor = Color.Red;

            }
            if (!txt_Fecha.Text.Contains("-"))
            {
                check = false;
                bool_fecha = false;
                txt_Fecha.BackColor = Color.Red;
            }
            if (!NuevaFuncion.IdExistenteFuncion(txt_CodFuncion.Text) && !(NuevaFuncion.IdExistenteSalaXFuncion(txt_CodFuncion.Text, DownList_Cod_Sala.SelectedValue)) && NuevaFuncion.IdExistenteSalas(DownList_Cod_Sala.SelectedValue) && check)
            {


                Ent_Funciones FuncionNueva = new Ent_Funciones(txt_CodFuncion.Text, DownList_Cod_Peli.SelectedValue, DownList_Cod_Sala.SelectedValue, txt_Fecha.Text, txt_Horario.Text);
                NuevaFuncion.AniadirFunciones(FuncionNueva);
                NuevaFuncion.AniadirFuncionesxSala(FuncionNueva);                
                NuevaFuncion.AniadirFuncionesxDia(FuncionNueva);

                DatosCargado.ForeColor = Color.Green;
                DatosCargado.Text = "Se han cargado exitosamente";
                txt_CodFuncion.Text = "";
                txt_Fecha.Text = "";
                txt_Horario.Text = "";
                txt_CodFuncion.BackColor = Color.Gray;
                txt_Fecha.BackColor = Color.Gray;
                txt_Horario.BackColor = Color.Gray;
            }
            else
            {
                DatosCargado.ForeColor = Color.Red;
                if(bool_fecha==true)
                DatosCargado.Text = "No puede haber campos vacios, o el Codigo de Funcion ya existe";
                else
                DatosCargado.Text = "En la fecha tiene que poner 3 guiones - por ejemplo 20-1-2019";

               
            }
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CargarPelis();
            TextBox1.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            CargarViewPeliculas();
            TextBox1.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CargarSalas();
            TextBox1.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            CargarViewSalas();
            TextBox1.Text = "";
        }
    }
}