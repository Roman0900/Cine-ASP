<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Elegir_Pelicula.aspx.cs" Inherits="PRESENTACION.Elegir_Pelicula" %>


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
        .auto-style8 {
            width: 100%;
        }
        .auto-style12 {
            width: 135px;
        }
        .auto-style13 {
            width: 89px;    
        }
        .auto-style37 {
            height: 7px;
            width: 39px;
        }
        .auto-style41 {
            height: 7px;
            width: 55px;
        }
        .auto-style42 {
            height: 7px;
            width: 125px;
        }
        .auto-style43 {
            height: 17px;
            width: 308px;
        }
        .auto-style45 {
            width: 186px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <table class="auto-style8">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Movie center FFM" Font-Bold="True" Font-Size="X-Large" ForeColor="#FF6600"></asp:Label>
                    </td>
                    <td class="auto-style45">
                        <asp:Label ID="Label17" runat="server" Text="Filtrar por Genero: "></asp:Label>
                        <asp:DropDownList ID="Downlist_Generos" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btn_Filtrar" runat="server" OnClick="btn_Filtrar_Click" Text="Filtrar" />
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="Label18" runat="server" Text="Filtrar por edad"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DownList_Edad" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btn_Filtrar_Edad" runat="server" OnClick="btn_Filtrar_Edad_Click" Text="Filtrar" />
                    </td>
                    <td class="auto-style13">
                        <asp:Button ID="btn_GenYEdad" runat="server" Text="Filtrar Por genero y Edad" OnClick="btn_GenYEdad_Click" />
                    </td>
                    <td>
                        <asp:LinkButton ID="link_Reiniciar" runat="server" OnClick="link_Reiniciar_Click">Reiniciar Cartelera</asp:LinkButton>
                    </td>
                </tr>
                </table>
            &nbsp;<asp:Label ID="Label7" runat="server" Text="Cartelera:" Font-Bold="True" ForeColor="#FF9900" Font-Size="Medium"></asp:Label>
                    <table style="width:100%;">
                <tr>
                    <td>
            <asp:DataList ID="list_Cartelera" runat="server" Font-Bold="True" CellSpacing="10" GridLines="Both" OnItemCommand="Seleccionar" RepeatDirection="Horizontal" >
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                <ItemTemplate>
                    <table style="width:100%;" class="auto-style43">
                        <tr>
                            <td class="auto-style42">
                                <asp:Label ID="Label19" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td class="auto-style41">
                                <asp:Label ID="Label20" runat="server" Text='Edad'></asp:Label>
                            </td>
                            <td class="auto-style41">
                                <asp:Label ID="Label21" runat="server" Text="Duracion"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style42">
                                <hr />
                            </td>
                            <td class="auto-style41">
                                <hr />
                            </td>
                            <td class="auto-style41">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style42">
                                <asp:LinkButton ID="Link_PeliculaElegida" runat="server" CommandArgument='<%# Bind("Cod_Pelicula") %>' CommandName="Seleccionar" Text='<%# Bind("Nombre_Pelicula") %>'></asp:LinkButton>
                                <br />
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Bind("Cod_Pelicula") %>' CommandName="Seleccionar" Height="200px" ImageUrl='<%# Bind("ImagenURL") %>' Width="150px" />
                            </td>
                            <td class="auto-style41">&nbsp;&nbsp;
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("Ed_Edad") %>'></asp:Label>
                            </td>
                            <td class="auto-style41">&nbsp;&nbsp;
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("Duracion") %>'></asp:Label>
                            </td>
                            <td class="auto-style37">
                                <asp:Label ID="lbl_Codigo" runat="server" Text='<%# Bind("Cod_Pelicula") %>' Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                   </ItemTemplate>
            </asp:DataList>
                        &nbsp;<asp:Button ID="btn_First" runat="server" Height="29px" OnClick="btn_First_Click" Text="&lt;&lt;" Width="58px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Prev" runat="server" Height="29px" OnClick="btn_Prev_Click" Text="&lt;" Width="58px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Next" runat="server" Height="29px" OnClick="btn_Next_Click" Text="&gt;" Width="58px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Last" runat="server" Height="29px" OnClick="btn_Last_Click" Text="&gt;&gt;" Width="58px" />
                        <br />
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="Label8" runat="server" Text="Estrenos:" Font-Bold="True" ForeColor="#FF9900" Font-Size="Medium"></asp:Label>
            <asp:DataList ID="list_Estrenos" runat="server" Font-Bold="True" CellSpacing="10" GridLines="Both" OnItemCommand="Seleccionar" RepeatDirection="Horizontal" >
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                <ItemTemplate>
                    <table class="auto-style43">
                        <tr>
                            <td class="auto-style42">
                                <asp:Label ID="Label19" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td class="auto-style41">
                                <asp:Label ID="Label20" runat="server" Text="Edad"></asp:Label>
                            </td>
                            <td class="auto-style41">
                                <asp:Label ID="Label21" runat="server" Text="Duracion"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style42">
                                <hr />
                            </td>
                            <td class="auto-style41">
                                <hr />
                            </td>
                            <td class="auto-style41">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style42">
                                <asp:LinkButton ID="Link_PeliculaElegida" runat="server" CommandArgument='<%# Bind("Cod_Pelicula") %>' CommandName="Seleccionar" Text='<%# Bind("Nombre_Pelicula") %>'></asp:LinkButton>
                                <br />
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Bind("Cod_Pelicula") %>' CommandName="Seleccionar" Height="200px" ImageUrl='<%# Bind("ImagenURL") %>' Width="150px" />
                            </td>
                            <td class="auto-style41">&nbsp;&nbsp;
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("Ed_Edad") %>'></asp:Label>
                            </td>
                            <td class="auto-style41">&nbsp;&nbsp;
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("Duracion") %>'></asp:Label>
                            </td>
                            <td class="auto-style37">
                                <asp:Label ID="lbl_Codigo" runat="server" Text='<%# Bind("Cod_Pelicula") %>' Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
                    </td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;<asp:Button ID="btn_FirstEs" runat="server" Height="29px" OnClick="btn_FirstEs_Click" Text="&lt;&lt;" Width="58px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_PrevEs" runat="server" Height="29px" OnClick="btn_PrevEs_Click" Text="&lt;" Width="58px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_NextEs" runat="server" Height="29px" OnClick="btn_NextEs_Click" Text="&gt;" Width="58px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_LastEs" runat="server" Height="29px" OnClick="btn_LastEs_Click" Text="&gt;&gt;" Width="58px" />
                        </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
        <p>
            <asp:LinkButton ID="link_Volver" runat="server" Font-Bold="True" OnClick="link_LogOut_Click">LogOut</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbl_User" runat="server" Font-Bold="True" ForeColor="#E7B031" Text="Label"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Historial De Factura</asp:LinkButton>
                    </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
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
    </form>
</body>
</html>
