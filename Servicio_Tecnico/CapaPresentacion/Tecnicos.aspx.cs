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
	public partial class Tecnicos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                LlenarGrid();
            }
		}


        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos"))
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
            if (CapaLogica.Tecnicos.Agregar(Tnombre.Text, Tespecialidad.Text) > 0)
            {
                LlenarGrid();
                Tnombre.Text = string.Empty;
                Tespecialidad.Text = string.Empty;
            }
            else
            {
                alertas("Error al ingresar tecnicos.");
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
                SqlCommand comando = new SqlCommand("DELETE FROM Tecnicos WHERE Nombre = @Nombre", conexion);
                comando.Parameters.AddWithValue("@Nombre", Tnombre.Text);
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
                    SqlCommand comando = new SqlCommand("UPDATE Tecnicos SET Especialidad = @Especialidad WHERE Nombre = @Nombre", conexion);
                    comando.Parameters.AddWithValue("@Nombre", Tnombre.Text);
                    comando.Parameters.AddWithValue("@Especialidad", Tespecialidad.Text);
                    int rowsAffected = comando.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Mostrar mensaje de éxito
                        Lmensaje.Text = "Especialidad actualizada correctamente.";
                        LlenarGrid(); // Actualizar la tabla grid
                    }
                    else
                    {
                        // Mostrar mensaje de error
                        Lmensaje.Text = "No se encontró el técnico con el nombre especificado.";
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error
                    Lmensaje.Text = "Error al actualizar la especialidad: " + ex.Message;
                }
            }
        }
    }
}