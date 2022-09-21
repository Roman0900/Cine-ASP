<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainGerente.aspx.cs" Inherits="PRESENTACION.MainGerente" %>


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
            width: 141px;
        }
        .auto-style2 {
            width: 129px;
        }
        .auto-style3 {
            width: 141px;
            height: 17px;
        }
        .auto-style4 {
            width: 129px;
            height: 17px;
        }
        .auto-style5 {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Bienvenido Gerente/a" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="¿Que Desea Modificar,Agregar O Eliminar?" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3"><asp:LinkButton ID="link_Peliculas" runat="server" Font-Bold="True" OnClick="link_Peliculas_Click">Peliculas</asp:LinkButton>
                    </td>
                    <td class="auto-style4"><asp:LinkButton ID="link_Generos" runat="server" Font-Bold="True" OnClick="link_Generos_Click">Generos</asp:LinkButton>
                    </td>
                    <td class="auto-style5"><asp:LinkButton ID="link_Funciones" runat="server" Font-Bold="True" OnClick="link_Funciones_Click">Funciones</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:LinkButton ID="link_GenxPel" runat="server" Font-Bold="True" OnClick="link_GenxPel_Click">Generos por Peliculas</asp:LinkButton>
                    </td>
                    <td class="auto-style2">
            <asp:LinkButton ID="link_TipoDeFuncion" runat="server" Font-Bold="True" OnClick="link_TipoDeFuncion_Click">Tipo De Funcion</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" OnClick="LinkButton1_Click">Reportes</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </p>
        <p>
&nbsp;<asp:Label ID="Label12" runat="server" Text="Busque una tabla para eliminar o editar aqui:" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p>
            &nbsp;<asp:DropDownList ID="DownList_Tablas" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" Font-Bold="True" OnClick="btn_Buscar_Click" />
            &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DownListFuncion" runat="server" Visible="False">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Funcion" runat="server" OnClick="btn_Funcion_Click" Text="Buscar Por Funcion" Visible="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:GridView ID="grid_Tablas" runat="server" Font-Bold="True" AutoGenerateEditButton="True" OnRowCancelingEdit="grid_Tablas_RowCancelingEdit" OnRowEditing="grid_Tablas_RowEditing" OnRowUpdated="grid_Tablas_RowUpdated" OnRowUpdating="grid_Tablas_RowUpdating" OnSelectedIndexChanged="grid_Tablas_SelectedIndexChanged" OnRowDataBound="grid_Tablas_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="hola" ValidateRequestMode="Enabled">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="chau">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lbl_exepcion" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Resultado" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
        <p>
&nbsp;<asp:LinkButton ID="link_LogOut" runat="server" Font-Bold="True" OnClick="link_LogOut_Click">LogOut</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_User" runat="server" Font-Bold="True" ForeColor="#E7B031" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <br />
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
        <div>
        </div>
    </form>
</body>
</html>
