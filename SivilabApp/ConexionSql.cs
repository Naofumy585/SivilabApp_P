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
    public class ConexionSql
    {
        MySqlConnection conexion = new MySqlConnection();
        static string servidor = "localhost";
        static string BD = "bolsa_trabajo";
        static string Usuario = "root";
        static string Password = "Mamado780";
        static string Puerto = "3306";

        string cadenaconexion = "server=" + servidor + ";" + "port=" + Puerto + ";" + "user id=" + Usuario + ";" + "password=" + Password + ";" + "database=" + BD + ";";

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                conexion.ConnectionString = cadenaconexion;
                conexion.Open();
                return conexion; // Retorna la conexión abierta
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}");
                return null; // Retorna null si no se pudo abrir la conexión
            }
        }
        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}