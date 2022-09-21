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
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargartotalrecaudado();
                CargarDownListEmail();
                Cargardesdehasta();
                //lbl_User.Text = Session["Usuario"].ToString();
            }
        }
        public void CargarDownListEmail()
        {
            Neg_Facturas Neg_fac = new Neg_Facturas();
          
            DropEmail.DataSource = Neg_fac.conseguirTodoslosclientesDisponibles();
            DropEmail.DataTextField = "Email";
            DropEmail.DataValueField = "Email";
            DropEmail.DataBind();
        }
        public void Cargardesdehasta()
        {
            Neg_reportes Neg_rep = new Neg_reportes();
            GridView1.DataSource = Neg_rep.ConseguirDesdeHasta(DropDesde1.SelectedValue,Dropdesde2.SelectedValue,Dropdesde3.SelectedValue, Drophasta1.SelectedValue,DropHasta2.SelectedValue,DropHasta3.SelectedValue);
            GridView1.DataBind();                                                     
        }
        public void Cargartotalrecaudado()
        {
            Neg_reportes Neg_rep = new Neg_reportes();
            GridView2.DataSource = Neg_rep.Cargartotalrecaudado();
            GridView2.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Cargardesdehasta();
        }
        public void CargarmesEspecifico()
        {                      
            Neg_reportes Neg_rep = new Neg_reportes();
            GridView1.DataSource = Neg_rep.Conseguirmesespeficicoigual(DropMesEspecifico1.SelectedValue, DropMesEspecifico2.SelectedValue);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CargarmesEspecifico();
        }

        public void Cargaranioespeficico()
        {
            Neg_reportes Neg_rep = new Neg_reportes();
            GridView1.DataSource = Neg_rep.Cargaranioespeficico(DropAñoespecifico.SelectedValue);
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Cargaranioespeficico();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainGerente.aspx");
        }
        
        public void Cargartotalrecaudadoxemail()
        {
          
            Neg_reportes Neg_rep = new Neg_reportes();
            GridView2.DataSource = Neg_rep.Cargartotalrecaudadoxemail(DropEmail.SelectedValue);
            GridView2.DataBind();
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            Cargartotalrecaudadoxemail();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Cargartotalrecaudado();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["Login"].ToString();
        }

        protected void link_LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}