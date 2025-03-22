using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaLogica
{
	public class Asignaciones
	{
        public static int Agregar(string reparacionID, string tecnicoID, string fechaAsignacion)
        {
            int resultado = 0;
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES (@ReparacionID, @TecnicoID, @FechaAsignacion)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);
                    cmd.Parameters.AddWithValue("@FechaAsignacion", fechaAsignacion);

                    con.Open();
                    resultado = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return resultado;
        }

        public static int Borrar()
        {
            return 0;
        }

        public static int Actualizar()
        {
            return 0;
        }
    }
}