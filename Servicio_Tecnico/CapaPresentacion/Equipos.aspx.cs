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
	public partial class Equipos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos"))
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
            int usuarioId;
            if (int.TryParse(TusuarioE.Text, out usuarioId))
            {
                if (CapaLogica.Equipos.Agregar(TtipoE.Text, TmodeloE.Text, usuarioId.ToString()) > 0)
                {
                    LlenarGrid();
                    TtipoE.Text = string.Empty;
                    TmodeloE.Text = string.Empty;
                    TusuarioE.Text = string.Empty;
                }
                else
                {
                    alertas("Error al ingresar usuario.");
                }
            }
            else
            {
                alertas("El ID de usuario debe ser un número.");
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
                SqlCommand comando = new SqlCommand("DELETE FROM Equipos WHERE TipoEquipo = @tipoequipo", conexion);
                comando.Parameters.AddWithValue("@tipoequipo", TtipoE.Text);
                comando.ExecuteNonQuery();
            }
            LlenarGrid();
        }

        protected void Bupdate_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(
                        "UPDATE Equipos SET TipoEquipo = @tipoequipo, Modelo = @modelo " +
                        "WHERE EquipoID = @equipoId AND UsuarioID = @usuarioId", // Filtro por ambos IDs
                    conexion);

                    
                    comando.Parameters.AddWithValue("@tipoequipo", TtipoE.Text);
                    comando.Parameters.AddWithValue("@modelo", TmodeloE.Text);
                    comando.Parameters.AddWithValue("@equipoId", int.Parse(TequipoId.Text)); // ID del equipo
                    comando.Parameters.AddWithValue("@usuarioId", int.Parse(TusuarioE.Text)); // ID del usuario

                    int rowsAffected = comando.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Lmensaje.Text = "Equipo actualizado correctamente.";
                        LlenarGrid();
                    }
                    else
                    {
                        Lmensaje.Text = "No se encontró el equipo o no tienes permisos.";
                    }
                }
                catch (Exception ex)
                {
                    Lmensaje.Text = "Error: " + ex.Message;
                }
            }
        }

    }
}