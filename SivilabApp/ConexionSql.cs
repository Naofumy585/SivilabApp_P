using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using SivilabApp;

namespace SivilabApp
{
    public class ConexionSql : IDisposable
    {
        private readonly string servidor = "localhost";
        private readonly string bd = "bolsa_trabajo";
        private readonly string usuario = "root";
        private readonly string password = "Mamado780"; // Considera mover esto a un archivo de configuración
        private readonly string puerto = "3306";

        private string cadenaConexion;
        private MySqlConnection _conexion;
        private bool _disposed = false; // Para detectar llamadas redundantes

        public ConexionSql()
        {
            cadenaConexion = $"server={servidor};port={puerto};user id={usuario};password={password};database={bd};";
            _conexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                _conexion.Open();
                return _conexion; // Retorna la conexión abierta
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}");
                return null; // Retorna null si no se pudo abrir la conexión
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Liberar los recursos administrados
                    if (_conexion != null)
                    {
                        _conexion.Close();
                        _conexion.Dispose();
                    }
                }

                // Liberar recursos no administrados aquí (si los hubiera)

                _disposed = true;
            }
        }
    }
}