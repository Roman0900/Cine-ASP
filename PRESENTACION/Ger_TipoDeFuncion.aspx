<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ger_TipoDeFuncion.aspx.cs" Inherits="PRESENTACION.Ger_TipoDeFuncion" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>MovieHunter</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
<script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="js/jquery-func.js"></script>
<!--[if IE 6]><link rel="stylesheet" href="css/ie6.css" type="text/css" media="all" /><![endif]-->
    <style type="text/css">
        .auto-style1 {
            width: 157px;
        }
        .auto-style2 {
            width: 157px;
            height: 17px;
        }
        .auto-style3 {
            height: 17px;
        }
        .auto-style4 {
            height: 17px;
            width: 180px;
        }
        .auto-style5 {
            width: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#FF6600" Text="Agregar tipo De Funcion"></asp:Label>
            &nbsp;</p>
        <p>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Ingrese el Codigo:"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txt_Codigo" runat="server" Width="226px" BackColor="Gray" BorderColor="Black"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Ingrese la Descripcion:"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txt_Descripcion" runat="server" Width="226px" BackColor="Gray" BorderColor="Black"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Ingrese el Precio:"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txt_Precio" runat="server" Width="226px" BackColor="Gray" BorderColor="Black"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </p>
        <p>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style4">
            <asp:LinkButton ID="link_Volver" runat="server" Font-Bold="True" OnClick="link_Volver_Click">Volver</asp:LinkButton>
                    </td>
                    <td class="auto-style3">
            <asp:LinkButton ID="link_Insertar" runat="server" Font-Bold="True" OnClick="link_Insertar_Click">Insertar</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </p>
        <p>
            <asp:Label ID="CargadeDatos" runat="server"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="link_LogOut" runat="server" Font-Bold="True" OnClick="link_LogOut_Click">LogOut</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_User" runat="server" Font-Bold="True" ForeColor="#E7B031" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <div>
        </div>
    </form>
</body>
</html>
