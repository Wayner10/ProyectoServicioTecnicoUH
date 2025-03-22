using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Servicio_Tecnico.CapaPresentacion
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            if (pnlRegistro.Visible) // Modo Registro
            {
                string confirmPassword = txtConfirmPassword.Text;
                if (password != confirmPassword)
                {
                    lblMensaje.Text = "Las contraseñas no coinciden.";
                    return;
                }

                if (RegistrarUsuario(usuario, password))
                {
                    lblMensaje.Text = "Usuario registrado correctamente. Ahora inicia sesión.";
                    pnlRegistro.Visible = false;
                    btnAction.Text = "Iniciar Sesión";
                    lblTitulo.Text = "Iniciar Sesión";
                    lnkToggle.Text = "¿No tienes cuenta? Regístrate";
                }
                else
                {
                    lblMensaje.Text = "Error al registrar el usuario.";
                }
            }
            else // Modo Inicio de Sesión
            {
                if (ValidarUsuario(usuario, password))
                {
                    string script = "window.open('Usuarios.aspx', '_blank');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                }
            }
        }

        private bool ValidarUsuario(string usuario, string password)
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                string query = "SELECT PasswordHash FROM Logins WHERE Username = @Usuario";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                conn.Open();
                object storedHash = cmd.ExecuteScalar();
                conn.Close();

                return storedHash != null && storedHash.ToString() == HashPassword(password);
            }
        }

        private bool RegistrarUsuario(string usuario, string password)
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                string query = "INSERT INTO Logins (UsuarioID, Username, PasswordHash) VALUES (1, @Usuario, @PasswordHash)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(password));

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        protected void lnkToggle_Click(object sender, EventArgs e)
        {
            if (pnlRegistro.Visible)
            {
                pnlRegistro.Visible = false;
                btnAction.Text = "Iniciar Sesión";
                lblTitulo.Text = "Iniciar Sesión";
                lnkToggle.Text = "¿No tienes cuenta? Regístrate";
            }
            else
            {
                pnlRegistro.Visible = true;
                btnAction.Text = "Registrarse";
                lblTitulo.Text = "Registro de Usuario";
                lnkToggle.Text = "¿Ya tienes cuenta? Inicia sesión";
            }
        }
    }
}
