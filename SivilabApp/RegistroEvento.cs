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
    public partial class RegistroEvento : Form
    {
        public RegistroEvento()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbxGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la contraseña desde el formulario
                string contrasena = Contrasena_usuario.Text;

                // Validar usuario y obtener su CURP
                string nombreUsuario = "";  // Inicializa la variable
                string curpUsuario = "";

                // Llamar al método ValidarUsuario
                Metodos metodos = new Metodos();
                bool usuarioValido = metodos.ValidarUsuario(contrasena, out curpUsuario);

                if (usuarioValido)
                {
                    // Obtener los datos desde los controles en el formulario
                    DateTime fechaRegistro = Fecha_registro.Value;
                    string descripcion = Descripcion.Text;
                    string nombreEvento = NombreEvento.Text;
                    string tipo = Tipo.Text;
                    string responsableEvento = Responsable_evento.Text;
                    string escuela = Escuela.Text;
                    string observaciones = Observaciones_evento.Text;
                    string direccionEvento = Direccion_evento.Text;
                    DateTime fechaEvento = Fecha_evento.Value;

                    // Generar el folio (por ejemplo, una combinación de fecha y datos relevantes)
                    string folio = GenerarFolio(nombreEvento, responsableEvento, fechaEvento);

                    // Establecer conexión con la base de datos
                    using (var conexionSql = new ConexionSql())
                    using (MySqlConnection connection = conexionSql.EstablecerConexion())
                    {
                        if (connection == null || connection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("No se pudo abrir la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Llamar al método AgregarEvento con todos los datos obtenidos
                        bool eventoAgregado = metodos.AgregarEvento(
                            folio, fechaRegistro, descripcion, nombreEvento, tipo, responsableEvento,
                            escuela, observaciones, direccionEvento, fechaEvento, curpUsuario, nombreUsuario, connection
                        );

                        if (eventoAgregado)
                        {
                            MessageBox.Show("Evento registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar el evento. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Limpiar los campos del formulario
                        LimpiarFormularioEvento();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error en el formato de los datos ingresados: {ex.Message}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Falta de datos obligatorios: {ex.Message}", "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerarFolio(string nombreEvento, string responsableEvento, DateTime fechaEvento)
        {
            // Tomar los primeros 4 caracteres de cada uno y asegurar que estén en mayúsculas
            string nombreEventoShort = nombreEvento.Length > 4 ? nombreEvento.Substring(0, 4).ToUpper() : nombreEvento.ToUpper();
            string responsableEventoShort = responsableEvento.Length > 4 ? responsableEvento.Substring(0, 4).ToUpper() : responsableEvento.ToUpper();
            string fechaEventoShort = fechaEvento.ToString("ddMM");  // Formato de fecha ddMM

            // Concatenar para formar el folio
            return $"{nombreEventoShort}{responsableEventoShort}{fechaEventoShort}";
        }
        // Método para limpiar los campos específicos del formulario de evento
        private void LimpiarFormularioEvento()
        {
            Fecha_registro.Value = DateTime.Now;
            Descripcion.Clear();

            // Limpiar los ComboBoxes
            NombreEvento.SelectedIndex = -1;
            Tipo.SelectedIndex = -1;
            Responsable_evento.SelectedIndex = -1;
            Escuela.SelectedIndex = -1;
            Fecha_evento.Value = DateTime.Now;
            Fecha_registro.Value = DateTime.Now;
            Fecha_evento.Value = DateTime.Now;

        }
    }
}
