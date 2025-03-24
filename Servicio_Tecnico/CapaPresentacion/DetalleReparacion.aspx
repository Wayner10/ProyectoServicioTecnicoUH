<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleReparacion.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.DetalleReparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="icon" type="image/png" sizes="32x32" href="/image/favicon-32x32.png"/>
    <link href="/CapaPresentacion/DetalleReparacion.css" rel="stylesheet" />
    <title>Detalle Reparacion</title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <ul>
            <li><a href="Tecnicos.aspx">Tecnicos</a></li>
            <li><a href="Usuarios.aspx">Usuarios</a></li>
            <li><a href="Equipos.aspx">Equipos</a></li>
            <li><a href="Reparaciones.aspx">Reparaciones</a></li>
            <li><a href="Asignaciones.aspx">Asignaciones</a></li>
            <li><a class="active" href="DetalleReparacion.aspx">Detalle de reparacion</a></li>
            <li><a href="#About.html"></a></li>
            
        </ul>

        <h2>Detalle de Reparación</h2>
        
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        
        <div class="form-group">
            <label>ID Detalle:</label>
            <asp:TextBox ID="TdetaRepaId" runat="server" placeholder="ID del detalle" CssClass="form-control"/>
        </div>
        
        <div class="form-group">
            <label>ID de Reparacion:</label>
            <asp:TextBox ID="TrepaId" runat="server" placeholder="ID Reparacion" CssClass="form-control"/>
        </div>
        
        <div class="form-group">
            <label>Descripcion:</label>
            <asp:TextBox ID="Tdescrip" runat="server" placeholder="Descripcion" CssClass="form-control"/>
        </div>
        
        <div class="form-group date-container">
            <div class="date-group">
                <label>Fecha Inicio:</label>
                <asp:TextBox ID="TfechaDR" runat="server" TextMode="Date" CssClass="form-control date-picker"/>
            </div>
            
            <div class="date-group">
                <label>Fecha Fin:</label>
                <asp:TextBox ID="TfechaDR2" runat="server" TextMode="Date" CssClass="form-control date-picker"/>
            </div>
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
