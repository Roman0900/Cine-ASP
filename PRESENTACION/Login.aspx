<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PRESENTACION.Login" %>

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
            height: 17px;
        }
        .auto-style2 {
            height: 17px;
            width: 187px;
        }
        .auto-style3 {
            width: 187px;
        }
        .auto-style4 {
            height: 17px;
            width: 185px;
        }
        .auto-style5 {
            width: 185px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
&nbsp;<asp:Label ID="Label1" runat="server" Text="Iniciar sesion" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Correo electronico"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txt_Email" runat="server" BackColor="Gray" BorderColor="Black" Width="174px" ></asp:TextBox>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Text="Contraseña"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txt_Contraseña" runat="server" BackColor="Gray" BorderColor="Black" Width="174px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="incorrecto" runat="server" Text="Contraseña o correo incorrectos" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:RadioButton ID="Recordarme" runat="server" Text="Recordarme" />
                    </td>
                    <td class="auto-style4">
                        <asp:LinkButton ID="Link_IniciarSesion" runat="server" OnClick="Link_IniciarSesion_Click">Iniciar sesión</asp:LinkButton>
                    </td>
                    <td class="auto-style1">
                        <asp:LinkButton ID="link_Registrarse" runat="server" OnClick="link_Registrarse_Click">Registrarse</asp:LinkButton>
                    </td>
                </tr>
            </table>
            &nbsp;<asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
