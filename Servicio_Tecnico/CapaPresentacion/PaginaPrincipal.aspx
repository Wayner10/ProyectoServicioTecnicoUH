<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/CapaPresentacion/PaginaPrincipal.css" rel="stylesheet" />
    <title>Detalles servicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <ul>
                <li><a href="Login.aspx">Admin</a></li>
            </ul>
            <div class="main-container">
                <h1>Detalles del Servicio Técnico</h1>
                <asp:GridView 
                    ID="GridView1" 
                    runat="server" 
                    CssClass="data-grid"
                    AutoGenerateColumns="true"
                    HeaderStyle-CssClass="header"
                    RowStyle-CssClass="row"
                    AlternatingRowStyle-CssClass="alt-row">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
