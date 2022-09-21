<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Elegir_Funcion.aspx.cs" Inherits="PRESENTACION.Elegir_Funcion" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>MovieHunter</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
<script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="js/jquery-func.js"></script>
<!--[if IE 6]><link rel="stylesheet" href="css/ie6.css" type="text/css" media="all" /><![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Text="Usted Eligio la Pelicula: " Font-Bold="True"></asp:Label>
            <asp:Label ID="lbl_Pelicula" runat="server" Font-Bold="True" ForeColor="#FF6600" Text="Label" Font-Size="Medium"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#FF9933" Text="Funciones: "></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="2D" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="grid_2D" runat="server" Font-Bold="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grid_2D_SelectedIndexChanged" OnRowDataBound="grid_2D_RowDataBound">
            </asp:GridView>
        </p>
        <p>
            &nbsp;<asp:Label ID="Label3" runat="server" Text="3D" Font-Bold="True"></asp:Label>
            <br />
            <asp:GridView ID="grid_3D" runat="server" Font-Bold="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grid_3D_SelectedIndexChanged1" OnRowDataBound="grid_3D_RowDataBound" >
            </asp:GridView>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="4D" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p>
            <asp:GridView ID="grid_4D" runat="server" Font-Bold="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grid_4D_SelectedIndexChanged" OnRowDataBound="grid_4D_RowDataBound">
            </asp:GridView>
        </p>
        <p>
            <asp:LinkButton ID="link_Volver" runat="server" Font-Bold="True" OnClick="link_Volver_Click">Volver</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
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
