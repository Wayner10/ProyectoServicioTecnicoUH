using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicio_Tecnico.CapaPresentacion
{
    public partial class Reparaciones : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TfechaR.Text = DateTime.Today.ToString("yyyy-MM-dd");
                LlenarGrid();
                CargarEstados();
            }
        }

        private void LlenarGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ReparacionID, Estado, FechaSolicitud, EquipoID FROM Reparaciones", con))
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

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Reparaciones (Estado, FechaSolicitud, EquipoID) VALUES (@Estado, @Fecha, @EquipoID)", con))
                    {
                        cmd.Parameters.AddWithValue("@Estado", TestadoR.SelectedValue);
                        DateTime fecha;
                        if (DateTime.TryParse(TfechaR.Text, out fecha))
                        {
                            cmd.Parameters.AddWithValue("@Fecha", fecha);
                        }
                        else
                        {
                            MostrarMensaje("Fecha inválida", "danger");
                            return;
                        }
                        cmd.Parameters.AddWithValue("@EquipoID", int.Parse(TequipoE.Text));

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            LimpiarFormulario();
                            LlenarGrid();
                            MostrarMensaje("Reparación agregada", "success");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error agregar: {ex.Message}", "danger");
            }
        }

        protected void Bupdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Reparaciones SET Estado = @Estado, FechaSolicitud = @Fecha, EquipoID = @EquipoID WHERE ReparacionID = @ID", con))
                    {
                        cmd.Parameters.AddWithValue("@Estado", TestadoR. SelectedValue);
                        DateTime fecha;
                        if (DateTime.TryParse(TfechaR.Text, out fecha))
                        {
                            cmd.Parameters.AddWithValue("@Fecha", fecha);
                        }
                        else
                        {
                            MostrarMensaje("Fecha inválida", "danger");
                            return;
                        }
                        cmd.Parameters.AddWithValue("@EquipoID", int.Parse(TestadoR.Text));
                        cmd.Parameters.AddWithValue("@ID", int.Parse(TequipoId.Text));

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

        protected void Beliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Reparaciones WHERE ReparacionID = @ID", con))
                    {
                        cmd.Parameters.AddWithValue("@ID", int.Parse(TequipoId.Text));

                        int res = cmd.ExecuteNonQuery();
                        MostrarMensaje(res > 0 ? "Eliminado!" : "No se encontró", res > 0 ? "success" : "warning");
                        LlenarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error eliminar: {ex.Message}", "danger");
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(TequipoE.Text) || !int.TryParse(TequipoE.Text, out _))
            {
                MostrarMensaje("Verifique los campos", "warning");
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            TequipoE.Text = "";
            TequipoId.Text = "";
            TestadoR.ClearSelection();
            TfechaR.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            Lmensaje.Text = mensaje;
            Lmensaje.CssClass = $"alert alert-{tipo}";
        }

        private void CargarEstados()
        {
            TestadoR.Items.Clear();
            TestadoR.Items.Add(new ListItem("Pendiente", "Pendiente"));
            TestadoR.Items.Add(new ListItem("Recibido", "Recibido"));
            TestadoR.Items.Add(new ListItem("En proceso", "En proceso"));
            TestadoR.Items.Add(new ListItem("Completado", "Completado"));
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GridView1.SelectedRow;
            TequipoId.Text = fila.Cells[1].Text;
            TestadoR.SelectedValue = fila.Cells[2].Text;
            DateTime fecha;
            if (DateTime.TryParse(fila.Cells[3].Text, out fecha))
            {
                TfechaR.Text = fecha.ToString("yyyy-MM-dd");
            }
            TequipoE.Text = fila.Cells[4].Text;
        }

    
        protected void TestadoR_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ejemplo: Actualizar UI al seleccionar
            Lmensaje.Text = $"Estado seleccionado: {TestadoR.SelectedValue}";
            Lmensaje.CssClass = "text-info";

           
        }
    }
}
