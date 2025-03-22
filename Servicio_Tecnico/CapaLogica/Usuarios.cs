using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaLogica
{
	public class Usuarios
	{
        public static int Agregar(string nombre, string correoelectronico, string telefono)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES (@nombre, @correoelectronico, @telefono)";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@correoelectronico", correoelectronico);
                        comando.Parameters.AddWithValue("@telefono", telefono);
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