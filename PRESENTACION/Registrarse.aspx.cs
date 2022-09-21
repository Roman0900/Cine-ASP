using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ENTIDADES;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool identificar(string dni)
        {
            if (dni.Contains("a")|| dni.Contains("A")|| dni.Contains("b")|| dni.Contains("B")|| dni.Contains("c")|| dni.Contains("C")|| dni.Contains("d")|| dni.Contains("D")|| dni.Contains("e")||dni.Contains("E") || dni.Contains("f") || dni.Contains("F") || dni.Contains("g") || dni.Contains("G") || dni.Contains("h") || dni.Contains("H") || dni.Contains("i") || dni.Contains("I") || dni.Contains("j") || dni.Contains("J") || dni.Contains("k") || dni.Contains("K") || dni.Contains("l") || dni.Contains("L") || dni.Contains("m") || dni.Contains("M") || dni.Contains("n") || dni.Contains("N") || dni.Contains("ñ") || dni.Contains("Ñ") || dni.Contains("o") || dni.Contains("O") || dni.Contains("p") || dni.Contains("P") || dni.Contains("q") || dni.Contains("Q") || dni.Contains("r") || dni.Contains("R") || dni.Contains("s") || dni.Contains("S") || dni.Contains("t") || dni.Contains("T") || dni.Contains("u") || dni.Contains("U") || dni.Contains("v") || dni.Contains("V") || dni.Contains("w") || dni.Contains("W") || dni.Contains("x") || dni.Contains("X") || dni.Contains("y") || dni.Contains("Y") || dni.Contains("z") || dni.Contains("Z"))
            {
                return false;
            }
            return true;

        }
        protected void link_Confirmar_Click(object sender, EventArgs e)
        {
            bool check = true;
            bool contraseñas = true;
            Neg_Clientes cliente = new Neg_Clientes();
            if (txt_Mail.Text.Trim() == "")
            {
                check = false;
                txt_Mail.BackColor = Color.Red;
            }
            else txt_Mail.BackColor = Color.Gray;
            if (txt_Dni.Text.Trim() == "")
            {
                check = false;
                txt_Dni.BackColor = Color.Red;
            }
            else txt_Dni.BackColor = Color.Gray;
            if (txt_Nombre.Text.Trim() == "")
            {
                check = false;
                txt_Nombre.BackColor = Color.Red;
            }
            else txt_Nombre.BackColor = Color.Gray;
            if (txt_Apellido.Text.Trim() == "")
            {
                check = false;
                txt_Apellido.BackColor = Color.Red;
            }
            else txt_Apellido.BackColor = Color.Gray;
            if (txt_Contraseña.Text.Trim() == "")
            {
                check = false;
                txt_Contraseña.BackColor = Color.Red;
            }
            if (!txt_Mail.Text.Contains("@"))
            {
                check = false;
                txt_Mail.BackColor = Color.Red;

            }
            else
            {
                string mail2 = txt_Mail.Text.Split('@')[1];

                if (!mail2.Contains(".com"))
                {
                    check = false;
                    txt_Mail.BackColor = Color.Red;

                }
            }
           

             
            if (txt_Dni.Text.Contains("a") || txt_Dni.Text.Contains("A") || txt_Dni.Text.Contains("b") || txt_Dni.Text.Contains("B") || txt_Dni.Text.Contains("c") || txt_Dni.Text.Contains("C") || txt_Dni.Text.Contains("d") || txt_Dni.Text.Contains("D") || txt_Dni.Text.Contains("e") || txt_Dni.Text.Contains("E") || txt_Dni.Text.Contains("f") || txt_Dni.Text.Contains("F") || txt_Dni.Text.Contains("g") || txt_Dni.Text.Contains("G") || txt_Dni.Text.Contains("h") || txt_Dni.Text.Contains("H") || txt_Dni.Text.Contains("i") || txt_Dni.Text.Contains("I") || txt_Dni.Text.Contains("j") || txt_Dni.Text.Contains("J") || txt_Dni.Text.Contains("k") || txt_Dni.Text.Contains("K") || txt_Dni.Text.Contains("l") || txt_Dni.Text.Contains("L") || txt_Dni.Text.Contains("m") || txt_Dni.Text.Contains("M") || txt_Dni.Text.Contains("n") || txt_Dni.Text.Contains("N") || txt_Dni.Text.Contains("ñ") || txt_Dni.Text.Contains("Ñ") || txt_Dni.Text.Contains("o") || txt_Dni.Text.Contains("O") || txt_Dni.Text.Contains("p") || txt_Dni.Text.Contains("P") || txt_Dni.Text.Contains("q") || txt_Dni.Text.Contains("Q") || txt_Dni.Text.Contains("r") || txt_Dni.Text.Contains("R") || txt_Dni.Text.Contains("s") || txt_Dni.Text.Contains("S") || txt_Dni.Text.Contains("t") || txt_Dni.Text.Contains("T") || txt_Dni.Text.Contains("u") || txt_Dni.Text.Contains("U") || txt_Dni.Text.Contains("v") || txt_Dni.Text.Contains("V") || txt_Dni.Text.Contains("w") || txt_Dni.Text.Contains("W") || txt_Dni.Text.Contains("x") || txt_Dni.Text.Contains("X") || txt_Dni.Text.Contains("y") || txt_Dni.Text.Contains("Y") || txt_Dni.Text.Contains("z") || txt_Dni.Text.Contains("Z"))
            {
                check = false;
                txt_Dni.BackColor = Color.Red;
            }

            else txt_Contraseña.BackColor = Color.Gray;
            if (txt_Contraseña.Text != txt_Confirmar_Contraseña.Text)
            {
                contraseñas = false;
            }
            if (!cliente.MailExistente(txt_Mail.Text) && check && contraseñas )
            {
                Ent_Clientes Nc = new Ent_Clientes(txt_Mail.Text, txt_Dni.Text, txt_Nombre.Text, txt_Apellido.Text, txt_Contraseña.Text, txt_CodGerente.Text);
                cliente.aniadirCliente(Nc);
                Response.Redirect("Login.aspx");
            }
           
            else
            {
                if (!contraseñas) lbl_fallido.Text = "Las contraseñas no son las mismas";
                if (!check) lbl_fallido.Text = "Faltan ingresar campos o ingrese bien los datos";
                if (!contraseñas && !check) lbl_fallido.Text = "Las contraseñas no son las mismas y faltan ingresar campos";
                lbl_fallido.Visible = true;
            }

        }

        protected void link_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}