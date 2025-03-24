<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/CapaPresentacion/Usuarios.css" rel="stylesheet" />
    <link rel="icon" type="image/png" sizes="32x32" href="/image/favicon-32x32.png"/>
    <title>Usuarios</title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
             <ul>
                <li><a href="Tecnicos.aspx">Tecnicos</a></li>
                <li><a class="active" href="Usuarios.aspx">Usuarios</a></li>
                <li><a href="Equipos.aspx">Equipos</a></li>
                <li><a href="Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="DetalleReparacion.aspx">Detalle de reparacion</a></li>
                <li><a href="About.html">About</a></li>
            </ul>
            <h1>Usuarios</h1>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
            <label>Nombre: </label>
            <asp:TextBox ID="TnombreU" runat="server" placeholder="Nombre" />
            <br /><br />
            
            <label>Correo Electronico: </label>
            <asp:TextBox ID="TcorreoU" runat="server" placeholder="Correo Electronico" />    
            <br /><br />
            
            <label>Telefono: </label>
            <asp:TextBox ID="TtelefonoU" runat="server" placeholder="Telefono" />
            <br /><br />
            
            <asp:Button CssClass="boton-accion" ID="BagregarU" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
            <asp:Button CssClass="boton-accion" ID="BeliminarU" runat="server" Text="Eliminar" OnClick="Beliminar_Click" />            
            <asp:Button CssClass="boton-accion" ID="BupdateU" runat="server" Text="Actualizar" OnClick="Bupdate_Click" />
            
            <asp:Label ID="Lmensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
