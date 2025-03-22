using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaLogica
{
	public class Tecnicos
	{
        public static int Agregar(string nombre, string especialidad)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "INSERT INTO Tecnicos (Nombre, Especialidad) VALUES (@nombre, @especialidad)";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@especialidad", especialidad);
                        comando.ExecuteNonQuery();
                    }
                }
                return 1; // Operación exitosa
            }
            catch (Exception)
            {
                return 0; // Error
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