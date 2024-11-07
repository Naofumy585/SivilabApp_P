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

        }

        private void BtnGuardarsolicitante_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del formulario
                string apellidoPaterno = ApellidoPaterno.Text; // Suponiendo que el control se llama ApellidoPaterno
                string apellidoMaterno = ApellidoMaterno.Text; // Suponiendo que el control se llama ApellidoMaterno
                string nombreSolicitante = Nombre_solicitante.Text; // Suponiendo que el control se llama Nombre
                string rfc = RFc.Text; // Suponiendo que el control se llama RFC
                string curp = Curp.Text; // Suponiendo que el control se llama CURP
                string correo = Correo.Text; // Suponiendo que el control se llama Correo
                DateTime fechaNacimiento = Fecha_Nacimiento.Value; // Suponiendo que el control se llama FechaNacimiento
                string escolaridad = Escolaridad.Text; // Suponiendo que el control se llama Escolaridad
                string genero = Genero.Text; // Suponiendo que el control se llama Genero
                decimal telefono = decimal.Parse(Telefono.Text); // Suponiendo que el control se llama Telefono
                string direccion = Direccion.Text; // Suponiendo que el control se llama Direccion
                string cvcCedula = CvcCedula.Text; // Suponiendo que el control se llama CVC
                string curpUsuario = Session.UsuarioActual?.CurpUsuario; // Obtén el CURP del usuario en sesión

                // Generar el folio
                string folio = $"{fechaNacimiento.Day.ToString("00")}{fechaNacimiento.Month.ToString("00")}" +
                               $"{(nombreSolicitante.Length >= 2 ? nombreSolicitante.Substring(0, 2) : nombreSolicitante)}" +
                               $"{(apellidoPaterno.Length >= 3 ? apellidoPaterno.Substring(apellidoPaterno.Length - 3) : apellidoPaterno)}" +
                               $"{telefono.ToString().Substring(telefono.ToString().Length - 3)}";

                // Crear una instancia de la clase Metodos
                Metodos metodos = new Metodos();

                // Llamar al método AgregarSolicitud
                bool solicitudAgregada = metodos.AgregarSolicitud(folio, apellidoPaterno, apellidoMaterno, nombreSolicitante, rfc, curp, correo, fechaNacimiento, escolaridad, genero, telefono, direccion, cvcCedula, curpUsuario);

                // Verificar si la solicitud fue agregada correctamente
                if (solicitudAgregada)
                {
                    MessageBox.Show("Solicitud agregada exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al agregar la solicitud. Intente nuevamente.");
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

    }
}