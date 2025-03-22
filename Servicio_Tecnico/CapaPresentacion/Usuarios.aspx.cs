using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicio_Tecnico.CapaPresentacion
{
	public partial class Usuarios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            if (CapaLogica.Usuarios.Agregar(TnombreU.Text, TcorreoU.Text, TtelefonoU.Text) > 0)
            {
                LlenarGrid();
                TnombreU.Text = string.Empty;
                TcorreoU.Text = string.Empty;
                TtelefonoU.Text = string.Empty;

            }
            else
            {
                alertas("Error al ingresar usuario.");
            }


        }

        public void alertas(string texto)
        {
            string script = $"alert('{texto}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", script, true);
        }


        protected void Beliminar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(s))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Usuarios WHERE Nombre = @Nombre", conexion);
                comando.Parameters.AddWithValue("@Nombre", TnombreU.Text);
                comando.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void Bupdate_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(s))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("UPDATE Usuarios SET Telefono = @Telefono, Correo = @Correo WHERE Nombre = @Nombre", conexion);
                    comando.Parameters.AddWithValue("@Nombre", TnombreU.Text);
                    comando.Parameters.AddWithValue("@Telefono", TtelefonoU.Text);
                    comando.Parameters.AddWithValue("@Correo", TcorreoU.Text);
                    int rowsAffected = comando.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Mostrar mensaje de éxito
                        Lmensaje.Text = "Usuario actualizado correctamente.";
                        LlenarGrid(); // Actualizar la tabla grid
                    }
                    else
                    {
                        // Mostrar mensaje de error
                        Lmensaje.Text = "No se encontró el usuario con el nombre especificado.";
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error
                    Lmensaje.Text = "Error al actualizar el usuario: " + ex.Message;
                }
            }
        }
    }
}