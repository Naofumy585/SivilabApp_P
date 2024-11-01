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
    public class Metodos
    {
        public bool ValidarUsuario(string nombreUsuario, string contraseña)
        {
            bool usuarioValido = false;
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre_usuario = @NombreUsuario AND Contrasena_Usuario = @Contrasena";

            ConexionSql conexionSql = new ConexionSql();
            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                if (conn == null) // Verificar que la conexión no sea nula
                {
                    return usuarioValido; // Si no se pudo abrir la conexión, retornar false
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contraseña); // Asegúrate que el nombre del parámetro sea correcto

                    // Ejecutar la consulta y obtener el resultado
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    usuarioValido = count > 0;
                }
            } // La conexión se cerrará automáticamente aquí

            return usuarioValido;
        }
    }
}
