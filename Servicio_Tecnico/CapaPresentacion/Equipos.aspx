<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.Equipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/CapaPresentacion/Equipos.css" rel="stylesheet" />
    <title>Equipos</title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="Usuarios.aspx">Usuarios</a></li>
                <li><a class="active" href="Equipos.aspx">Equipos</a></li>
                <li><a href="Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="DetalleReparacion.aspx">Detalle de reparacion</a></li>
                <li><a href="#about">About</a></li>
            </ul>

            <h1>Gestión de Equipos</h1>
            
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
            <div class="form-group">
                <label>Tipo de equipo:</label>
                <asp:TextBox ID="TtipoE" runat="server" placeholder="Equipo"/>
            </div>
            
            <div class="form-group">
                <label>Modelo:</label>
                <asp:TextBox ID="TmodeloE" runat="server" placeholder="Modelo"/>
            </div>
            
            <div class="form-group">
                <label>ID del usuario:</label>
                <asp:TextBox ID="TusuarioE" runat="server" placeholder="ID Usuario"/>
            </div>
            
            <div class="form-group">
                <label>ID del equipo:</label>
                <asp:TextBox ID="TequipoId" runat="server" placeholder="ID Equipo"/>
            </div>
            
            <div class="botones-container">
                <asp:Button CssClass="boton-accion" ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
                <asp:Button CssClass="boton-accion" ID="Beliminar" runat="server" Text="Eliminar" OnClick="Beliminar_Click" />
                <asp:Button CssClass="boton-accion" ID="Bupdate" runat="server" Text="Actualizar" OnClick="Bupdate_Click" />
            </div>
            
            <asp:Label ID="Lmensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
