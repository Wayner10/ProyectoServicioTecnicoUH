using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaLogica
{
    public class DetalleReparacion
    {
        public static int Agregar(string reparacionID, string descripcion, string FechaInicio, string FechaFin)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES (@ReparacionID, @Descripcion, @FechaInicio, @FechaFin)";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ReparacionID", reparacionID);
                        comando.Parameters.AddWithValue("@Descripcion", descripcion);
                        comando.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                        comando.Parameters.AddWithValue("@FechaFin", FechaFin);
                        comando.ExecuteNonQuery(); // Ejecutar el comando
                    }
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
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