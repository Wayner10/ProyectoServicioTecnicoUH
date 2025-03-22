using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;

namespace Servicio_Tecnico.CapaPresentacion
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void LlenarGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT AsignacionID, ReparacionID, TecnicoID, FechaAsignacion FROM Asignaciones", con))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Error grid: {ex.Message}", "danger");
                }
            }
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            Lmensaje.Text = mensaje;
            Lmensaje.CssClass = $"alert alert-{tipo}";
        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            if (CapaLogica.Asignaciones.Agregar( TrepaId.Text, TtecniId.Text, TfechaA.Text) > 0)
            {
                LlenarGrid();
                TrepaId.Text = string.Empty;
                TtecniId.Text = string.Empty;
                TfechaA.Text = string.Empty;

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
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Asignaciones WHERE AsignacionID = @ID", conexion))
                {
                    cmd.Parameters.AddWithValue("@ID", int.Parse(TasignacionID.Text));

                    int res = cmd.ExecuteNonQuery();
                    MostrarMensaje(res > 0 ? "Eliminado!" : "No se encontró", res > 0 ? "success" : "warning");
                    LlenarGrid();
                }
            }
            LlenarGrid();
        }

        protected void Bupdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Asignaciones SET ReparacionID = @ReparacionID, TecnicoID = @TecnicoID, FechaAsignacion = @FechaAsignacion WHERE AsignacionID = @ID", con))
                    {
                        cmd.Parameters.AddWithValue("@ReparacionID", TrepaId.Text);
                        DateTime fecha;
                        if (DateTime.TryParse(TfechaA.Text, out fecha))
                        {
                            cmd.Parameters.AddWithValue("@FechaAsignacion", fecha);
                        }
                        else
                        {
                            MostrarMensaje("Fecha inválida", "danger");
                            return;
                        }
                        cmd.Parameters.AddWithValue("@TecnicoID", int.Parse(TtecniId.Text));
                        cmd.Parameters.AddWithValue("@ID", int.Parse(TasignacionID.Text));

                        int res = cmd.ExecuteNonQuery();
                        MostrarMensaje(res > 0 ? "Actualizado!" : "No se encontró", res > 0 ? "success" : "warning");
                        LlenarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error actualizar: {ex.Message}", "danger");
            }
        }

    }
}