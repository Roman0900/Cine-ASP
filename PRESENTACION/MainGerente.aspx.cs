using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NEGOCIO;
using ENTIDADES;
using System.Data.SqlClient;

namespace PRESENTACION
{
    public partial class MainGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_exepcion.Visible = false;
            if (!IsPostBack)
            {
                cargarDownListTablas();
                cargarGridTablas();
                lbl_User.Text = Session["Usuario"].ToString();
            }
            if (DownList_Tablas.SelectedValue.ToString() == "AsientosxSalaxFuncion" && DownListFuncion.Visible == false)
            {
                DownListFuncion.Visible = true;
                btn_Funcion.Visible = true;
                cargarDownListFuncion();
            }else if  (DownList_Tablas.SelectedValue.ToString() != "AsientosxSalaxFuncion")          
            {
                DownListFuncion.Visible = false;
                btn_Funcion.Visible = false;
            }

        }

        public void cargarDownListFuncion()
        {

            Neg_Funciones Neg_Fun = new Neg_Funciones();
            DownListFuncion.DataSource = Neg_Fun.conseguirtablaFunciones();
             DownListFuncion.DataTextField = "Cod_Funcion";
            DownListFuncion.DataValueField = "Cod_Funcion";
            DownListFuncion.DataBind();
        }

        public void cargarDownListTablas()
        {
            
            Neg_Tablas Neg_Tab = new Neg_Tablas();
            DownList_Tablas.DataSource = Neg_Tab.conseguirTodasLasTablas();
            DownList_Tablas.DataTextField = "Table_Name";
            DownList_Tablas.DataValueField = "Table_Name";
            DownList_Tablas.DataBind();
        }

        public void cargarGridTablas()
        {
            Neg_Tablas Neg_Tab = new Neg_Tablas();
            grid_Tablas.DataSource = Neg_Tab.ConseguirTablaAdecuada(DownList_Tablas.SelectedValue);
            grid_Tablas.DataBind();
            grid_Tablas.Columns[0].Visible = false;
            grid_Tablas.Columns[1].Visible = false;
        }
        public void cargarGridTablas(string Funcion)
        {
            Neg_Butacas Neg_But = new Neg_Butacas();
            grid_Tablas.DataSource = Neg_But.ConseguirButacasPorFuncion(Funcion);
            grid_Tablas.DataBind();
            grid_Tablas.Columns[0].Visible = false;
            grid_Tablas.Columns[1].Visible = false;
        }

        protected void link_Peliculas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ger_Peliculas.aspx");
        }

        protected void link_Generos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ger_Generos.aspx");
        }

        protected void link_Funciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ger_FxP.aspx");
        }

        protected void link_AsxSalaXFun_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ger_BxSxF.aspx");
        }

        protected void link_TipoDeFuncion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ger_TipoDeFuncion.aspx");
        }

        protected void link_GenxPel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ger_GenxP.aspx");
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            grid_Tablas.EditIndex = -1;
            cargarGridTablas();
        }

        protected void grid_Tablas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            grid_Tablas.EditIndex = e.NewEditIndex;
            cargarGridTablas();

            grid_Tablas.Rows[e.NewEditIndex].Cells[3].Enabled = false;

            switch (DownList_Tablas.SelectedValue)
            {
                case "Peliculas":
                    break;

                case "Clientes":
                    break;

                case "Tipos de funcion":
                    break;

                case "Salas":
                    grid_Tablas.Columns[0].Visible = true;
                    foreach (GridViewRow rows in grid_Tablas.Rows)
                    {
                        rows.FindControl("DropDownList1").Visible = false;
                    }
                    grid_Tablas.Rows[e.NewEditIndex].FindControl("DropDownList1").Visible = true;

                    grid_Tablas.Rows[e.NewEditIndex].Cells[5].Enabled = false;
                    break;
                case "Funciones":
                    grid_Tablas.Rows[e.NewEditIndex].Cells[4].Enabled = false;
                    grid_Tablas.Rows[1].Visible = false;
                    break;

                case "Facturas":
                    grid_Tablas.Rows[e.NewEditIndex].Cells[4].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[5].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[6].Enabled = false;
                    break;
                case "GenerosxPelicula":
                    grid_Tablas.Rows[e.NewEditIndex].Cells[3].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[4].Enabled = false;
                    grid_Tablas.Columns[0].Visible = true;
                    foreach (GridViewRow rows in grid_Tablas.Rows)
                    {
                        rows.FindControl("DropDownList1").Visible = false;
                    }
                    grid_Tablas.Rows[e.NewEditIndex].FindControl("DropDownList1").Visible = true;

                    break;
                case "FuncionXSala":
                    grid_Tablas.Rows[e.NewEditIndex].Cells[4].Enabled = false;
                    break;
 
                case "FuncionXDia":

                    break;

                case "AsientosxSalaxFuncion":
                    grid_Tablas.Rows[e.NewEditIndex].Cells[4].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[5].Enabled = false;
                    break;

                case "Edades":

                    break;

                case "DetallexFactura":

                    grid_Tablas.Rows[e.NewEditIndex].Cells[4].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[5].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[6].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[7].Enabled = false;
                    break;
                    
                case "EdadXPelicula":
                    grid_Tablas.Rows[e.NewEditIndex].Cells[3].Enabled = false;
                    grid_Tablas.Rows[e.NewEditIndex].Cells[4].Enabled = false;
                    grid_Tablas.Columns[0].Visible = true;
                    foreach (GridViewRow rows in grid_Tablas.Rows)
                    {
                        rows.FindControl("DropDownList1").Visible = false;
                    }
                    grid_Tablas.Rows[e.NewEditIndex].FindControl("DropDownList1").Visible = true;
                    break;

                case "Generos":
                    break;

            }
        }
        
        protected void grid_Tablas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid_Tablas.EditIndex = -1;
            cargarGridTablas();
        }

        private DropDownList cargarDownListEdades(DropDownList dl)
        {
            Neg_Edad Neg_Ed = new Neg_Edad();
            dl.DataSource = Neg_Ed.ConseguirEdades();
            dl.DataTextField = "Ed_Edad";
            dl.DataValueField = "Ed_Cod_Edad";
            dl.DataBind();
            return dl;
        }
        

        private DropDownList cargarDownListTipo(DropDownList dl)
        {
            Neg_Tipo_Funcion Neg_T = new Neg_Tipo_Funcion();
            dl.DataSource = Neg_T.ConseguirTipos();
            dl.DataTextField = "Descripcion";
            dl.DataValueField = "Cod_Tipo";
            dl.DataBind();
            return dl;
        }

        private DropDownList CargarDownListGenero(DropDownList dl)
        {
            Neg_Genero Neg_Gen = new Neg_Genero();
            dl.DataSource = Neg_Gen.ConseguirGeneros();
            dl.DataTextField = "Descripcion";
            dl.DataValueField = "Codigo_De_Genero";
            dl.DataBind();
            return dl;
        }

        private DropDownList CargarDownListPeli(DropDownList dl)
        {
            Neg_Peliculas Neg_Pel = new Neg_Peliculas();
            dl.DataSource = Neg_Pel.conseguirTodasLasPelisDisponibles();
            dl.DataTextField = "Nombre_Pelicula";
            dl.DataValueField = "Cod_Pelicula";
            dl.DataBind();
            return dl;
        }

        protected void grid_Tablas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            switch (DownList_Tablas.SelectedValue)
            {
                case "Peliculas":
                    int estreno = 0;
                    bool estado = false;
                    Neg_Peliculas Neg_Pel = new Neg_Peliculas();
                    CheckBox estr = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[7].Controls[0];
                    CheckBox esta = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[8].Controls[0];
                    if (estr.Checked) estreno = 1;
                    if (esta.Checked) estado = true;
                    GridViewRow row = grid_Tablas.Rows[e.RowIndex];
                    String cod_pelicula = ((TextBox)(row.Cells[3].Controls[0])).Text;
                    String nombre_pelicula = ((TextBox)(row.Cells[4].Controls[0])).Text;
                    String duracion = ((TextBox)(row.Cells[5].Controls[0])).Text;
                    String URL = ((TextBox)(row.Cells[6].Controls[0])).Text;

                    Ent_Peliculas EP = new Ent_Peliculas(cod_pelicula, nombre_pelicula, "No se usa", duracion, URL , estreno);
                    EP.Estado = estado;
                    Neg_Pel.ActualizarPeliculas(EP);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "Clientes":
                    Neg_Clientes Neg_Cli = new Neg_Clientes();
                    bool tipo = false;
                    bool estadoC = false;
                    CheckBox tip = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[8].Controls[0];
                    CheckBox estaC = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[9].Controls[0];
                    if (tip.Checked) tipo = true;
                    if (estaC.Checked) estadoC = true;
                    GridViewRow rowC = grid_Tablas.Rows[e.RowIndex];
                    String Email = ((TextBox)(rowC.Cells[3].Controls[0])).Text;
                    String Dni = ((TextBox)(rowC.Cells[4].Controls[0])).Text;
                    String Nombre = ((TextBox)(rowC.Cells[5].Controls[0])).Text;
                    String Apellido = ((TextBox)(rowC.Cells[6].Controls[0])).Text;
                    String Contraseña = ((TextBox)(rowC.Cells[7].Controls[0])).Text;
                    Ent_Clientes Ent_Clientes = new Ent_Clientes(Email, Dni, Nombre, Apellido, Contraseña, " ");
                    Ent_Clientes.Tipo = tipo;
                    Ent_Clientes.Estado = estadoC;
                    Neg_Cli.ActualizarCliente(Ent_Clientes);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "Tipos_De_Funcion":
                    Neg_Tipo_Funcion neg_Tipo_Funcion = new Neg_Tipo_Funcion();
                    bool estadoTF = false;
                    CheckBox estaTF = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[6].Controls[0];
                    if (estaTF.Checked) estadoTF = true;
                    GridViewRow rowTF = grid_Tablas.Rows[e.RowIndex];
                    String Cod_Tipo = ((TextBox)(rowTF.Cells[3].Controls[0])).Text;
                    String Descripcion = ((TextBox)(rowTF.Cells[4].Controls[0])).Text;
                    String Precio = ((TextBox)(rowTF.Cells[5].Controls[0])).Text;
                    Ent_Tipo_Funcion ent_Tipo_Funcion = new Ent_Tipo_Funcion(Cod_Tipo, Descripcion, Precio);
                    ent_Tipo_Funcion.Estado = estadoTF;
                    neg_Tipo_Funcion.ActualizarTipo_Funcion(ent_Tipo_Funcion);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "Salas":
                    Neg_Salas neg_Salas = new Neg_Salas();
                    bool estadoS = false;
                    CheckBox estaS = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[6].Controls[0];
                    if (estaS.Checked) estadoS = true;
                    GridViewRow rowS = grid_Tablas.Rows[e.RowIndex];
                    String Cod_Sala = ((TextBox)(rowS.Cells[3].Controls[0])).Text;
                    String DescripcionS = ((TextBox)(rowS.Cells[4].Controls[0])).Text;
                    String S_Cod_Tipo = ((DropDownList)grid_Tablas.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedValue;
                    Ent_Salas ent_Salas = new Ent_Salas(Cod_Sala, DescripcionS, S_Cod_Tipo);
                    ent_Salas.Estado = estadoS;
                    neg_Salas.ActualizarSala(ent_Salas);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "Funciones":
                    Neg_Funciones neg_Funciones = new Neg_Funciones();
                    bool estadoF = false;
                    CheckBox estaF = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[5].Controls[0];
                    if (estaF.Checked) estadoF = true;
                    GridViewRow rowF = grid_Tablas.Rows[e.RowIndex];
                    String Cod_Funcion = ((TextBox)(rowF.Cells[3].Controls[0])).Text;
                    String Cod_Pelicula = ((TextBox)(rowF.Cells[4].Controls[0])).Text;
                    Ent_Funciones ent_Funciones = new Ent_Funciones(Cod_Funcion, Cod_Pelicula, "no se usa", "no se usa", "no se usa");
                    ent_Funciones.Estado = estadoF;
                    neg_Funciones.ActualizarFunciones(ent_Funciones);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "Facturas":
                    Neg_Facturas neg_Facturas = new Neg_Facturas();
                    bool estadoFAC = false;
                    CheckBox estaFAC = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[7].Controls[0];
                    if (estaFAC.Checked) estadoFAC = true;
                    GridViewRow rowFAC = grid_Tablas.Rows[e.RowIndex];
                    int Cod_Factura = System.Convert.ToInt32(((TextBox)(rowFAC.Cells[3].Controls[0])).Text);
                    Ent_Facturas ent_Facturas = new Ent_Facturas(Cod_Factura, estadoFAC);
                    neg_Facturas.ActualizarEstadoFactura(ent_Facturas);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "GenerosxPelicula":
                    Neg_GenerosxPeliculas neg_GenerosxPeliculas = new Neg_GenerosxPeliculas();
                    bool estadoGXP = false;
                    CheckBox estaGXP = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[5].Controls[0];
                    if (estaGXP.Checked) estadoGXP = true;
                    GridViewRow rowGXP = grid_Tablas.Rows[e.RowIndex];
                    String Gp_Cod_G = ((DropDownList)grid_Tablas.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedValue;
                    String V_Gp_Cod_G = ((TextBox)(rowGXP.Cells[3].Controls[0])).Text;
                    String V_Gp_Cod_P = ((TextBox)(rowGXP.Cells[4].Controls[0])).Text;
                    Neg_GenerosxPeliculas neg_gxp = new Neg_GenerosxPeliculas();
                    if (!neg_gxp.IDexisteGeneroXPelicula(Gp_Cod_G, V_Gp_Cod_P))
                    {
                        Ent_GenerosxPeliculas ent_GenerosxPeliculas = new Ent_GenerosxPeliculas(Gp_Cod_G, "no se usa", V_Gp_Cod_G, V_Gp_Cod_P);
                        ent_GenerosxPeliculas.Estado = estadoGXP;
                        neg_GenerosxPeliculas.ActualizarGeneroxPelicula(ent_GenerosxPeliculas);
                        lbl_exepcion.Visible = false;
                        grid_Tablas.EditIndex = -1;
                        cargarGridTablas();
                    }
                    else
                    {
                        lbl_exepcion.Text = "El registro que ha intentado ingresar ya existe";
                        lbl_exepcion.Visible = true;
                    }
                    break;

                case "FuncionXSala":
                    Neg_FuncionXSala neg_FuncionXSala = new Neg_FuncionXSala();
                    bool estadoFXS = false;
                    CheckBox estaFXS = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[5].Controls[0];
                    if (estaFXS.Checked) estadoFXS = true;
                    GridViewRow rowFXS = grid_Tablas.Rows[e.RowIndex];
                    String Cod_FuncionFXS = ((TextBox)(rowFXS.Cells[3].Controls[0])).Text;
                    String Cod_SalaFXS = ((TextBox)(rowFXS.Cells[4].Controls[0])).Text;
                    Ent_FuncionXSala ent_FuncionXSala = new Ent_FuncionXSala(Cod_FuncionFXS, Cod_SalaFXS, estadoFXS);
                    neg_FuncionXSala.ActualizarFuncionXSala(ent_FuncionXSala);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();

                    break;

                case "FuncionXDia":
                    Neg_FuncionXDia neg_FuncionXDia = new Neg_FuncionXDia();
                    bool estadoFXD = false;
                    CheckBox estaFXD = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[6].Controls[0];
                    if (estaFXD.Checked) estadoFXD = true;
                    GridViewRow rowFXD = grid_Tablas.Rows[e.RowIndex];
                    String Cod_FuncionFXD = ((TextBox)(rowFXD.Cells[3].Controls[0])).Text;
                    string fec = ((TextBox)(rowFXD.Cells[4].Controls[0])).Text;
                    if (fec.Contains("-"))
                    {
                        String Horario = ((TextBox)(rowFXD.Cells[5].Controls[0])).Text;
                        Ent_FuncionXDia ent_FuncionXDia = new Ent_FuncionXDia(Cod_FuncionFXD, fec, Horario, estadoFXD);
                        neg_FuncionXDia.ActualizarFuncionXdia(ent_FuncionXDia);
                        lbl_exepcion.Visible = false;
                        grid_Tablas.EditIndex = -1;
                        cargarGridTablas();
                    }
                    else
                    {
                        lbl_exepcion.Text = "Ingrese una fecha correcta";
                        lbl_exepcion.Visible = true;
                    }

                        break;

                case "AsientosxSalaxFuncion":
                    
                    Neg_Butacas neg_Butacas = new Neg_Butacas();
                    bool estadoB = false;
                    CheckBox estaB = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[6].Controls[0];
                    if (estaB.Checked) estadoB = true;
                    GridViewRow rowB = grid_Tablas.Rows[e.RowIndex];
                    String Cod_SalaB = ((TextBox)(rowB.Cells[3].Controls[0])).Text;
                    String Cod_FuncionB = ((TextBox)(rowB.Cells[4].Controls[0])).Text;
                    int Cod_Butaca = System.Convert.ToInt32( ((TextBox)(rowB.Cells[5].Controls[0])).Text);
                    Ent_Butacas ent_Butacas = new Ent_Butacas(Cod_FuncionB, Cod_SalaB, "no se usa", Cod_Butaca, estadoB);
                    neg_Butacas.ActualizarButaca(ent_Butacas);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    
                    break;

                case "Edades":
                    Neg_Edad neg_Edad = new Neg_Edad();
                    bool estadoE = false;
                    CheckBox estaE = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[5].Controls[0];
                    if (estaE.Checked) estadoE = true;
                    GridViewRow rowE = grid_Tablas.Rows[e.RowIndex];
                    String Cod_Edad = ((TextBox)(rowE.Cells[3].Controls[0])).Text;
                    String Edad = ((TextBox)(rowE.Cells[4].Controls[0])).Text;
                    Ent_Edad ent_Edad = new Ent_Edad(Cod_Edad, Edad, estadoE);
                    neg_Edad.ActualizarEdades(ent_Edad);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();

                    break;

                case "DetallexFactura":
                    Neg_Facturas neg_DXFacturas = new Neg_Facturas();
                    bool estadoDF = false;
                    CheckBox estaDF = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[8].Controls[0];
                    if (estaDF.Checked) estadoDF = true;
                    GridViewRow rowDF = grid_Tablas.Rows[e.RowIndex];
                    int Cod_DetalleDF = System.Convert.ToInt32(((TextBox)(rowDF.Cells[3].Controls[0])).Text);
                    int Cod_FacturaDF = System.Convert.ToInt32(((TextBox)(rowDF.Cells[4].Controls[0])).Text);
                    String Cod_SalaDF = ((TextBox)(rowDF.Cells[5].Controls[0])).Text;
                    String Cod_FuncionDF = ((TextBox)(rowDF.Cells[6].Controls[0])).Text;
                    int Cod_ButacaDF = System.Convert.ToInt32(((TextBox)(rowDF.Cells[7].Controls[0])).Text);
                    Ent_DetalleXFacturas ent_DXF = new Ent_DetalleXFacturas(Cod_DetalleDF, Cod_FacturaDF, Cod_SalaDF, Cod_FuncionDF, Cod_ButacaDF, estadoDF);
                    neg_DXFacturas.ActualizarEstadoDetalleXFactura(ent_DXF);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "EdadXPelicula":
                    Neg_Peliculas neg_Peliculas = new Neg_Peliculas();
                    bool estadoPE = false;
                    CheckBox estaPE = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[5].Controls[0];
                    if (estaPE.Checked) estadoPE = true;
                    GridViewRow rowPE = grid_Tablas.Rows[e.RowIndex];
                    String Cod_PeliculaPE = ((TextBox)(rowPE.Cells[4].Controls[0])).Text;
                    String Cod_EdadPE = ((DropDownList)grid_Tablas.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedValue;
                    Ent_Peliculas ent_Peliculas = new Ent_Peliculas(Cod_PeliculaPE, "no se usa", Cod_EdadPE, "no se usa", "", 0);
                    ent_Peliculas.Estado = estadoPE;
                    neg_Peliculas.ActualizarPelisXEdad(ent_Peliculas);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;

                case "Generos":
                    Neg_Genero neg_Genero = new Neg_Genero();
                    bool estadoG = false;
                    CheckBox estaG = (CheckBox)grid_Tablas.Rows[e.RowIndex].Cells[5].Controls[0];
                    if (estaG.Checked) estadoG = true;
                    GridViewRow rowG = grid_Tablas.Rows[e.RowIndex];
                    String Codigo_De_Genero = ((TextBox)(rowG.Cells[3].Controls[0])).Text;
                    String DescripcionG = ((TextBox)(rowG.Cells[4].Controls[0])).Text;
                    Ent_Genero ent_Genero = new Ent_Genero(Codigo_De_Genero, DescripcionG, estadoG);
                    neg_Genero.ActualizarGeneros(ent_Genero);
                    grid_Tablas.EditIndex = -1;
                    cargarGridTablas();
                    break;
            }
        }

        protected void grid_Tablas_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            grid_Tablas.EditIndex = -1;
            cargarGridTablas();
        }

        protected void grid_Tablas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void grid_Tablas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (DownList_Tablas.SelectedValue)
            {
                case "Salas":
                    grid_Tablas.Columns[0].HeaderText = "Tipo";
                    DropDownList ddl_salas = (DropDownList)e.Row.FindControl("DropDownList1");
                    if(ddl_salas != null)
                        ddl_salas = cargarDownListTipo(ddl_salas);
                    break;
                case "GenerosxPelicula":
                    DropDownList dl_Gen = (DropDownList)e.Row.FindControl("DropDownList1");
                    if (dl_Gen != null) dl_Gen = CargarDownListGenero(dl_Gen);
                    grid_Tablas.Columns[0].HeaderText = "Generos";
                    break;
                case "EdadXPelicula":
                    DropDownList dl_Edades = (DropDownList)e.Row.FindControl("DropDownList1");
                    if (dl_Edades != null) dl_Edades = cargarDownListEdades(dl_Edades);
                    grid_Tablas.Columns[0].HeaderText = "Edad";
                    break;
            }
        }

        protected void btn_Funcion_Click(object sender, EventArgs e)
        {
            grid_Tablas.EditIndex = -1;
            cargarGridTablas(DownListFuncion.SelectedValue.ToString());
        }
    }
}