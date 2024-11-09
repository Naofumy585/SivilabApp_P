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
    public partial class RegistrarCita : Form
    {
        public RegistrarCita()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCita_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la contraseña y validar usuario
                string contrasena = Contrasena_usuario.Text;
                string curpUsuario = "";
                Metodos metodos = new Metodos();
                bool usuarioValido = metodos.ValidarUsuario(contrasena, out curpUsuario);

                if (usuarioValido)
                {
                    // Buscar y autocompletar datos si se detecta un RFC en el formulario
                    if (!string.IsNullOrEmpty(Rfc.Text))
                    {
                        BuscarYAutocompletarRFC(Rfc.Text);
                    }

                    // Obtener datos necesarios del formulario
                    string nombreCompleto = Nombre_completo.Text;
                    string curpSolicitante = Curp_solicitante.Text;
                    string correo = Correo.Text;
                    string hora = Hora.Text;
                    DateTime fecha = Fecha.Value;

                    // Generar código único para la cita, si es necesario
                    string cvcCita = GenerarCvcCita(nombreCompleto, fecha, hora);

                    // Establecer conexión y llamar al método AgregarCita
                    using (var connection = new ConexionSql().EstablecerConexion())
                    {
                        if (connection == null || connection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("No se pudo abrir la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Llamar a AgregarCita sin el parámetro rfc
                        bool citaAgregada = metodos.AgregarCita(
                            cvcCita, curpSolicitante, nombreCompleto, fecha, hora, curpUsuario, connection
                        );

                        if (citaAgregada)
                        {
                            MessageBox.Show("Cita agregada exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar la cita. Intente nuevamente.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos específicos de la cita
        private void LimpiarFormularioCita()
        {
            Nombre_completo.Clear();
            ApellidoPaterno.Clear();
            ApellidoMaterno.Clear();
            Curp_solicitante.Clear();
            Rfc.Clear();
            Correo.Clear();
            Hora.Clear();
            Fecha.Value = DateTime.Now;
            Direccion_completa.Clear();
            Contrasena_usuario.Clear();
        }
        private void BuscarYAutocompletarRFC(string rfc)
        {
            string query = "SELECT Nombre_solicitante, ApellidoPaterno, ApellidoMaterno,Correo, Curp, Fecha_Nacimiento FROM Solicitud WHERE Rfc = @rfc";

            using (var connection = new ConexionSql().EstablecerConexion())
            {
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    MessageBox.Show("No se pudo abrir la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@rfc", rfc);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Si encontramos datos
                        {
                            // Asignar los valores obtenidos a los controles del formulario
                            Nombre_completo.Text = reader["Nombre_solicitante"].ToString();
                            ApellidoPaterno.Text = reader["ApellidoPaterno"].ToString();
                            ApellidoMaterno.Text = reader["ApellidoMaterno"].ToString();
                            Correo.Text = reader["Correo"].ToString();
                            Curp_solicitante.Text = reader["Curp"].ToString();
                            Fecha.Value = Convert.ToDateTime(reader["Fecha_Nacimiento"]);
                        }
                        else
                        {
                            // Limpiar los campos si no se encuentra el RFC
                            Nombre_completo.Clear();
                            Correo.Clear();
                            Curp_solicitante.Clear();
                            Fecha.Value = DateTime.Now;
                        }
                    }
                }
            }
        }

        // Método para generar un código de cita
        public string GenerarCvcCita(string nombreCompleto, DateTime fecha, string hora)
        {
            string nombreCita = nombreCompleto.Length >= 3 ? nombreCompleto.Substring(0, 3).ToUpper() : nombreCompleto.ToUpper().PadRight(3, 'X');
            string fechaCita = fecha.ToString("yyMMdd");
            string horaCita = hora.Length >= 2 ? hora.Substring(0, 2) : hora.PadLeft(2, '0');
            string cvcCita = (nombreCita + fechaCita + horaCita).PadRight(12).Substring(0, 12);

            return cvcCita;
        }

        private void Rfc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Si el RFC no está vacío, buscar los datos asociados
                if (!string.IsNullOrEmpty(Rfc.Text))
                {
                    BuscarYAutocompletarRFC(Rfc.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al buscar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}