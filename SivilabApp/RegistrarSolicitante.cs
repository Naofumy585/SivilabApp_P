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
    public partial class RegistrarSolicitante : Form
    {
        public RegistrarSolicitante()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txbDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarSolicitante_Load(object sender, EventArgs e)
        {
            LlenarComboVacantes();

        }

        private void BtnGuardarsolicitante_Click(object sender, EventArgs e)
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
                    // Obtener los datos del formulario para la solicitud
                    string apellidoPaterno = ApellidoPaterno.Text;
                    string apellidoMaterno = ApellidoMaterno.Text;
                    string nombreSolicitante = Nombre_solicitante.Text;
                    string rfc = RFc.Text;
                    string curp = Curp.Text;
                    string correo = Correo.Text;
                    string escolaridad = Escolaridad.Text;
                    string genero = Genero.Text;
                    string cvcVacante = Cvcvacante.Text;
                    string telefono = Telefono.Text;
                    string direccion = Direccion.Text;
                    string cvcCedula = CvcCedula.Text;
                    string estado = Estado.Text;
                    string colonia = Colonia.Text;
                    string calle = Calle.Text;
                    string noExterior = No_ext.Text;
                    string ciudad = Ciudad.Text;
                    string codigoPostal = Codigo_Postal.Text;
                    string nacionalidad = Estado_migratori.Text;

                    DateTime fechaNacimiento = Fecha_Nacimiento.Value;  // Asegúrate de que esta fecha esté en el formato correcto

                    // Generar el folio
                    string folio = GenerarFolio(nombreSolicitante, telefono, rfc);

                    // Establecer conexión con la base de datos
                    using (var conexionSql = new ConexionSql())
                    using (MySqlConnection connection = conexionSql.EstablecerConexion())
                    {
                        if (connection == null || connection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("No se pudo abrir la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Llamar al método AgregarSolicitud con todos los datos obtenidos
                        bool solicitudAgregada = metodos.AgregarSolicitud(
                            folio, apellidoPaterno, apellidoMaterno, nombreSolicitante, rfc, curp, correo,
                           cvcVacante, fechaNacimiento, escolaridad, genero, telefono, direccion, cvcCedula, curpUsuario,
                            ciudad, estado, calle, colonia, int.Parse(codigoPostal), nacionalidad, int.Parse(noExterior), nombreUsuario, connection
                        );

                        if (solicitudAgregada)
                        {
                            MessageBox.Show("Solicitud agregada exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar la solicitud. Intente nuevamente.");
                        }

                        // Limpiar los campos del formulario
                        LimpiarFormularioSolicitud();
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
        // Método para limpiar los campos específicos de la solicitud
        private void LimpiarFormularioSolicitud()
        {
            ApellidoPaterno.Clear();
            ApellidoMaterno.Clear();
            Nombre_solicitante.Clear();
            RFc.Clear();
            Curp.Clear();
            Correo.Clear();
            Telefono.Clear();
            Direccion.Clear();
            CvcCedula.Clear();
            Fecha_Nacimiento.Value = DateTime.Now;
            Escolaridad.SelectedIndex = -1;
            Genero.SelectedIndex = -1;

            // Limpiar la contraseña
            Contrasena_usuario.Clear();
        }

        // Método para generar el folio
        public string GenerarFolio(string nombreSolicitante, string telefono, string rfc)
        {
            // Validación y ajuste de longitud para nombre
            string nombreFolio = nombreSolicitante.Length >= 3 ? nombreSolicitante.Substring(0, 3).ToUpper() : nombreSolicitante.ToUpper().PadRight(3, 'X');

            // Validación y ajuste de longitud para teléfono
            string telefonoFolio = telefono.Length >= 2 ? telefono.Substring(telefono.Length - 2) : telefono.PadLeft(2, '0');

            // Validación y ajuste de longitud para RFC
            string rfcFolio = rfc.Length >= 2 ? rfc.Substring(rfc.Length - 2) : rfc.PadLeft(2, 'X');

            // Obtener una cadena de fecha y hora con formato específico
            string fechaHoraFolio = DateTime.Now.ToString("yyMMddHH");

            // Combinar todo y ajustar la longitud total a un máximo de 12 caracteres
            string folio = (nombreFolio + telefonoFolio + rfcFolio + fechaHoraFolio).PadRight(12).Substring(0, 12);

            return folio;
        }

        private void calle_TextChanged(object sender, EventArgs e)
        {

        }
        private void LlenarComboVacantes()
        {
            try
            {
                // Establecer la conexión a la base de datos
                using (var conexionSql = new ConexionSql())
                using (MySqlConnection connection = conexionSql.EstablecerConexion())
                {
                    if (connection == null || connection.State != ConnectionState.Open)
                    {
                        MessageBox.Show("No se pudo abrir la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Definir la consulta SQL
                    string query = "SELECT CvcVacante, Puesto_ofrecido FROM Vacante WHERE CvcVacante IS NOT NULL";

                    // Crear el comando
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Ejecutar la consulta y obtener el lector de datos
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Limpiar el ComboBox antes de llenarlo
                        Cvcvacante.Items.Clear();

                        // Llenar el ComboBox con los resultados
                        while (reader.Read())
                        {
                            // Obtener el valor de CvcVacante (Folio) y Puesto_ofrecido
                            string cvcVacante = reader.GetString("CvcVacante");
                            string puestoOfrecido = reader.GetString("Puesto_ofrecido");

                            // Agregar el puesto ofrecido al ComboBox
                            // Usamos un KeyValuePair donde la clave es el CvcVacante (Folio) y el valor es el Puesto_ofrecido
                            Cvcvacante.Items.Add(new KeyValuePair<string, string>(cvcVacante, puestoOfrecido));
                        }

                        // Establecer el formato de visualización del ComboBox para mostrar solo el Puesto_ofrecido
                        Cvcvacante.DisplayMember = "Value";  // Muestra el Puesto_ofrecido
                        Cvcvacante.ValueMember = "Key";     // Almacena el CvcVacante

                        // Verificar si hay elementos para seleccionar
                        if (Cvcvacante.Items.Count > 0)
                        {
                            // Seleccionar el primer item por defecto (opcional)
                            Cvcvacante.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al cargar las vacantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void Cvcvacante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}