<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reparaciones.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.Reparaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/CapaPresentacion/Reparaciones.css" rel="stylesheet" />
    <link rel="icon" type="image/png" sizes="32x32" href="/image/favicon-32x32.png"/>
    <title>Reparaciones</title>
</head>
<body>
 <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="Usuarios.aspx">Usuarios</a></li>
                <li><a href="Equipos.aspx">Equipos</a></li>
                <li><a class="active" href="Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="DetalleReparacion.aspx">Detalle de reparacion</a></li>
                <li><a href="#About.html"></a></li>
               
            </ul>

            <h2>Registro de Reparaciones</h2>
            
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
            <div class="form-group">
                <label>ID de Reparacion:</label>
                <asp:TextBox ID="TequipoId" runat="server" placeholder="ID Reparacion" CssClass="form-control"/>
            </div>
            
            <div class="form-group">
                <label>ID del equipo:</label>
                <asp:TextBox ID="TequipoE" runat="server" placeholder="ID Equipo" CssClass="form-control"/>
            </div>
            
            <div class="form-group">
                <label>Fecha solicitud:</label>
                <asp:TextBox ID="TfechaR" runat="server" TextMode="Date" CssClass="form-control"/>
            </div>
            
            <div class="form-group">
                <label>Estado:</label>
                <asp:DropDownList ID="TestadoR" runat="server" CssClass="form-control"
                    AutoPostBack="true" OnSelectedIndexChanged="TestadoR_SelectedIndexChanged">
                    <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                    <asp:ListItem Text="Recibido" Value="Recibido"></asp:ListItem>
                    <asp:ListItem Text="En proceso" Value="En proceso"></asp:ListItem>
                    <asp:ListItem Text="Completado" Value="Completado"></asp:ListItem>
                </asp:DropDownList>
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
