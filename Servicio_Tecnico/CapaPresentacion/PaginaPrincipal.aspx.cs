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
	public partial class PaginaPrincipal : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT U.Nombre AS Usuario, E.TipoEquipo, R.Estado, T.Nombre AS Tecnico, DR.Descripcion FROM Usuarios U INNER JOIN Equipos E ON U.UsuarioID = E.UsuarioID INNER JOIN Reparaciones R ON E.EquipoID = R.EquipoID INNER JOIN Asignaciones A ON R.ReparacionID = A.ReparacionID INNER JOIN Tecnicos T ON A.TecnicoID = T.TecnicoID INNER JOIN DetallesReparacion DR ON R.ReparacionID = DR.ReparacionID;"))
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
    }
}