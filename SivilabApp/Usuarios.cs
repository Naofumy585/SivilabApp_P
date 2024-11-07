using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SivilabApp;
using MySql.Data.MySqlClient;
namespace SivilabApp
{
    public class Usuario
    {
        public string CurpUsuario { get; set; }
        public string NombreUsuario { get; set; } // Agregas esta propiedad
                                                  // Otras propiedades según sea necesario
    }

    public static class Session
    {
        public static Usuario UsuarioActual { get; set; }
    }


    public static class Usuarios
    {
        public static bool ExisteUsuario(string Nombre_usuario)
        {
            bool existe = false;

            try
            {
                // Usamos la clase ConexionSql para obtener la conexión
                using (MySqlConnection conn = new ConexionSql().EstablecerConexion())
                {
                    if (conn == null)
                    {
                        throw new Exception("No se pudo establecer la conexión a la base de datos.");
                    }

                    // Consulta para verificar si el nombre de usuario existe
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre_usuario = @Nombre_usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre_usuario", Nombre_usuario);

                        // Ejecuta la consulta y verifica si el usuario existe
                        existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico de excepciones de MySQL
                MessageBox.Show($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

            return existe;
        }

        public static string ObtenerCurpUsuario(string Nombre_usuario)
        {
            string curp = string.Empty;

            // Crea una instancia de ConexionSql
            ConexionSql conexionSql = new ConexionSql();

            try
            {
                using (MySqlConnection conn = conexionSql.EstablecerConexion())
                {
                    if (conn == null)
                    {
                        throw new Exception("No se pudo establecer conexión a la base de datos.");
                    }

                    string query = "SELECT Curp_usuario FROM Usuarios WHERE Nombre_usuario = @Nombre_usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre_usuario", Nombre_usuario);
                        curp = cmd.ExecuteScalar()?.ToString();

                        if (string.IsNullOrEmpty(curp))
                        {
                            throw new Exception("No se encontró un CURP para el usuario proporcionado.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico de excepciones de MySQL
                MessageBox.Show($"Error de base de datos: {ex.Message}");
                // Puedes registrar el error o lanzar una excepción personalizada aquí
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

            return curp;
        }

        // Método para verificar la contraseña del usuario
        public static bool VerificarContrasena(string Nombre_usuario, string contrasena)
        {
            bool isValid = false;

            try
            {
                // Usamos la clase ConexionSql para obtener la conexión
                using (MySqlConnection conn = new ConexionSql().EstablecerConexion())
                {
                    if (conn == null)
                    {
                        throw new Exception("No se pudo establecer la conexión a la base de datos.");
                    }

                    // Corrige la consulta para incluir el * para seleccionar columnas
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre_usuario = @Nombre_usuario AND Contrasena_Usuario = @Contrasena_Usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre_usuario", Nombre_usuario);
                        cmd.Parameters.AddWithValue("@Contrasena_Usuario", contrasena);

                        // Ejecuta la consulta y verifica si el usuario y la contraseña son válidos
                        isValid = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico de excepciones de MySQL
                MessageBox.Show($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }

            return isValid;
        }

    }
}