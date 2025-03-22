<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Servicio_Tecnico.CapaPresentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/capapresentacion/Login.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="auth-container">
                <h2 class="text-center">
                    <asp:Label ID="lblTitulo" runat="server" Text="Iniciar Sesión"></asp:Label>
                </h2>
                <div class="mb-3">
                    <asp:Label ID="lblUsuario" runat="server" Text="" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario" required></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPassword" runat="server" Text="" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña" required></asp:TextBox>
                </div>
                <asp:Panel ID="pnlRegistro" runat="server" Visible="false">
                    <div class="mb-3">
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirmar Contraseña:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirmar Contraseña"></asp:TextBox>
                    </div>
                </asp:Panel>
                <asp:Button ID="btnAction" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnAction_Click" />
                <asp:Label ID="lblMensaje" runat="server" CssClass="error-message"></asp:Label>

                <div class="toggle-container">
                    <asp:LinkButton ID="lnkToggle" runat="server" OnClick="lnkToggle_Click">¿No tienes cuenta? Regístrate</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
