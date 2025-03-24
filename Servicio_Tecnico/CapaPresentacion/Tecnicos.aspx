<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.Tecnicos" %>

<!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/CapaPresentacion/Tecnicos.css" rel="stylesheet" />
    <link rel="icon" type="image/png" sizes="32x32" href="/image/favicon-32x32.png"/>
    <title>Tecnicos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a class="active" href="Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="Usuarios.aspx">Usuarios</a></li>
                <li><a href="Equipos.aspx">Equipos</a></li>
                <li><a href="Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="DetalleReparacion.aspx">Detalle de reparacion</a></li>
                <li><a href="#About.html"></a></li>
                
            </ul>

            <h1>Lista de Tecnicos</h1>
            <h2>Tecnicos:</h2>
            
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
            <div class="form-group">
                <label>Nombre: </label>
                <asp:TextBox ID="Tnombre" runat="server" placeholder="Nombre"/>
            </div>
            
            <div class="form-group">
                <label>Especialidad: </label>
                <asp:TextBox ID="Tespecialidad" runat="server" placeholder="Especialidad"/>
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
