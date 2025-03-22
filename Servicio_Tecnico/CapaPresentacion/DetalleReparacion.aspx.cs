using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Servicio_Tecnico.CapaPresentacion
{
    public partial class DetalleReparacion : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT DetalleID, ReparacionID, Descripcion, FechaInicio, FechaFin FROM DetallesReparacion"))
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
            try
            {
                int resultado = CapaLogica.DetalleReparacion.Agregar(TrepaId.Text, Tdescrip.Text, TfechaDR.Text, TfechaDR2.Text);
                if (resultado > 0)
                {
                    LlenarGrid();
                    TrepaId.Text = string.Empty;
                    Tdescrip.Text = string.Empty;
                    TfechaDR.Text = string.Empty;
                    TfechaDR2.Text = string.Empty;
                    Lmensaje.Text = "Detalle de reparación agregado exitosamente.";
                }
                else
                {
                    Lmensaje.Text = "Error al ingresar detalle de reparación.";
                }
            }
            catch (Exception ex)
            {
                Lmensaje.Text = "Error: " + ex.Message;
            }
        }


        protected void Beliminar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(s))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM DetallesReparacion WHERE DetalleID = @DetalleID", conexion);
                comando.Parameters.AddWithValue("@DetalleID", TdetaRepaId.Text);
                comando.ExecuteNonQuery();
            }
            LlenarGrid();
            TdetaRepaId.Text = string.Empty;
            TrepaId.Text = string.Empty;
            Tdescrip.Text = string.Empty;
            TfechaDR.Text = string.Empty;
            TfechaDR2.Text = string.Empty;
            Lmensaje.Text = "Detalle de reparación eliminado exitosamente.";
        }

        protected void Bupdate_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(s))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("UPDATE DetallesReparacion SET ReparacionID = @ReparacionID, Descripcion = @Descripcion, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE DetalleID = @DetalleID", conexion);
                    comando.Parameters.AddWithValue("@DetalleID", TdetaRepaId.Text);
                    comando.Parameters.AddWithValue("@ReparacionID", TrepaId.Text);
                    comando.Parameters.AddWithValue("@Descripcion", Tdescrip.Text);
                    comando.Parameters.AddWithValue("@FechaInicio", TfechaDR.Text);
                    comando.Parameters.AddWithValue("@FechaFin", TfechaDR2.Text);
                    int rowsAffected = comando.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Lmensaje.Text = "Detalle de reparación actualizado exitosamente.";
                        LlenarGrid();
                    }
                    else
                    {
                        Lmensaje.Text = "No se encontró el detalle de reparación con el ID especificado.";
                    }
                }
                catch (Exception ex)
                {
                    Lmensaje.Text = "Error al actualizar el detalle de reparación: " + ex.Message;
                }
            }
            TdetaRepaId.Text = string.Empty;
            TrepaId.Text = string.Empty;
            Tdescrip.Text = string.Empty;
            TfechaDR.Text = string.Empty;
            TfechaDR2.Text = string.Empty;
        }
    }
}