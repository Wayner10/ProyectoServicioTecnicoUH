using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Servicio_Tecnico.CapaPresentacion;

namespace Servicio_Tecnico.CapaLogica
{
    public static class Reparaciones
    {
        public static int Agregar(string estado, string FechaSolicitud, string EquipoID)
        {
            int resultado = 0;
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES (@EquipoID, @FechaSolicitud, @Estado)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@FechaSolicitud", FechaSolicitud);
                    cmd.Parameters.AddWithValue("@EquipoID", EquipoID);

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