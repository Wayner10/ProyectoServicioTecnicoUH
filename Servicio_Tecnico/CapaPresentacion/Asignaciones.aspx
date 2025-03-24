<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.Asignaciones" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/CapaPresentacion/Asignaciones.css" rel="stylesheet" />
    <link rel="icon" type="image/png" sizes="32x32" href="/image/favicon-32x32.png"/>
    <title>Asignaciones</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <ul>
            <li><a href="Tecnicos.aspx">Tecnicos</a></li>
            <li><a href="Usuarios.aspx">Usuarios</a></li>
            <li><a href="Equipos.aspx">Equipos</a></li>
            <li><a href="Reparaciones.aspx">Reparaciones</a></li>
            <li><a class="active" href="Asignaciones.aspx">Asignaciones</a></li>
            <li><a href="DetalleReparacion.aspx">Detalle de reparacion</a></li>
            <li><a href="#About.html"></a></li>
            
        </ul>

        <h1>Gestión de Asignaciones</h1>
        
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        
        <div class="form-group">
            <label>ID de Asignacion:</label>
            <asp:TextBox ID="TasignacionID" runat="server" placeholder="ID Asignacion" CssClass="form-control"/>
        </div>
        
        <div class="form-group">
            <label>ID de Reparacion:</label>
            <asp:TextBox ID="TrepaId" runat="server" placeholder="ID Reparacion" CssClass="form-control"/>
        </div>
        
        <div class="form-group">
            <label>ID del Tecnico:</label>
            <asp:TextBox ID="TtecniId" runat="server" placeholder="Tecnico" CssClass="form-control"/>
        </div>
        
        <div class="form-group">
            <label>Fecha Asignacion:</label>
            <asp:TextBox ID="TfechaA" runat="server" TextMode="Date" CssClass="form-control date-picker"/>
        </div>
        
        <div class="botones-container">
            <asp:Button CssClass="boton-accion" ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
            <asp:Button CssClass="boton-accion" ID="Beliminar" runat="server" Text="Eliminar" OnClick="Beliminar_Click" />
            <asp:Button CssClass="boton-accion" ID="Bupdate" runat="server" Text="Actualizar" OnClick="Bupdate_Click" />
        </div>
        
        <asp:Label ID="Lmensaje" runat="server" CssClass="mensaje-estado"></asp:Label>
    </div>
    </form>
</body>
</html>
