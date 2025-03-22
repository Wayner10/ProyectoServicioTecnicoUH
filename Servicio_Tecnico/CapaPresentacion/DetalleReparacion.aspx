<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleReparacion.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.DetalleReparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                <li><a href="DetalleReparacion.aspx">Detalle de reparacion</a></li>
                <li style="float:right"><a class="active" href="#about">About</a></li>
            </ul>
            <h2>Detalle de Reparación</h2>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <br />
            <label>ID Detalle: </label>
            <asp:TextBox ID="TdetaRepaId" runat="server" placeholder="ID del detalle " />
            <br />
            <br />      
            <label>ID de Reparacion: </label>
            <asp:TextBox ID="TrepaId" runat="server" placeholder="ID Reparacion" />
            <br />
            <br />
            <label>Descripcion: </label>
            <asp:TextBox ID="Tdescrip" runat="server" placeholder="Descripcion"/>
            <br />
            <br />
            <label>Fecha Inicio: </label>
            <asp:TextBox ID="TfechaDR" runat="server" TextMode="Date"  />      
            <br />
            <br />
            <label>Fecha Fin: </label>
            <asp:TextBox ID="TfechaDR2" runat="server" TextMode="Date"  />
             <br />
            <br />
            <asp:Button ID="Bagregar" runat="server" Text="Agregar" OnClick="Bagregar_Click" />
            <br />
            <br />
            <asp:Button ID="Beliminar" runat="server" Text="Eliminar" OnClick="Beliminar_Click" />            
            <br />
            <br />
            <asp:Button ID="Bupdate" runat="server" Text="Actualizar" OnClick="Bupdate_Click"  />
            <br />
            <br />
            <asp:Label ID="Lmensaje" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
