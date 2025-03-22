using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaLogica
{
    public class Equipos
    {
        public static int Agregar(string tipoEquipo, string modelo, string usuarioID)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();

                    string query = "INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES (@TipoEquipo, @Modelo, @UsuarioID)";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                        comando.Parameters.AddWithValue("@Modelo", modelo);
                        comando.Parameters.AddWithValue("@UsuarioID", int.Parse(usuarioID));
                        comando.ExecuteNonQuery();
                    }
                }
                return 1; // Operación exitosa
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar equipo: " + ex.Message);
                return 0; // Error
            }
        }

        public static int Eliminar(string tipoEquipo)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "DELETE FROM Equipos WHERE TipoEquipo = @TipoEquipo";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                        comando.ExecuteNonQuery();
                    }
                }
                return 1; // Operación exitosa
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar equipo: " + ex.Message);
                return 0; // Error
            }
        }

        public static int Actualizar(string tipoEquipo, string modelo, string usuarioID)
        {
            try
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(s))
                {
                    conexion.Open();
                    string query = "UPDATE Equipos SET Modelo = @Modelo, UsuarioID = @UsuarioID WHERE TipoEquipo = @TipoEquipo";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Modelo", modelo);
                        comando.Parameters.AddWithValue("@UsuarioID", int.Parse(usuarioID));
                        comando.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                        comando.ExecuteNonQuery();
                    }
                }
                return 1; // Operación exitosa
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar equipo: " + ex.Message);
                return 0; // Error
            }
        }

    }
}