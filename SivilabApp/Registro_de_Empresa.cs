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
    public partial class Registro_de_Empresa : Form
    {
        public Registro_de_Empresa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la contraseña desde el formulario
                string contrasena = Contrasena_usuario.Text;

                // Validar usuario y obtener su CURP
                string nombreUsuario = "";  // Variable para almacenar el nombre de usuario
                string curpUsuario = "";    // Variable para almacenar el CURP del usuario

                // Llamar al método ValidarUsuario
                Metodos metodos = new Metodos();
                bool usuarioValido = metodos.ValidarUsuario(contrasena, out curpUsuario);

                if (usuarioValido)
                {
                    // Si el usuario es válido, se puede proceder a agregar la dependencia
                    string cvcDependencia = CvcDependencia.Text;
                    string nombre = Nombre.Text;
                    string rfcDependencia = RFC_dependencia.Text;
                    string estado = Estado.Text;
                    string colonia = Colonia.Text;
                    string Calle = calle.Text;
                    string telefono = Telefono.Text;
                    string categoria = Actividad_economica.Text;
                    string estatus = Tipo_servicio.Text;
                    string ciudad = Ciudad.Text;
                    string codigoPostal = Codigo_Postal.Text;
                    string correo = Correo.Text;
                    string noTrabajadores = No_trabajadores.Text;
                    string puesto = Puesto.Text;
                    string noExterior = No_ext.Text;
                    string motivoEnt = Observaciones.Text;
                    string diasDuracion = Dias_duracion.Text;
                    DateTime horaEnt = Hora.Value;

                    // Generar el Folio usando la lógica
                    string folio = GenerarFolio(nombre, telefono, rfcDependencia);

                    // Llamar a AgregarDependencia, ahora con el CURP del usuario
                    bool resultado = metodos.AgregarDependencia(
                        cvcDependencia, rfcDependencia, nombre, categoria, telefono, correo, estatus,
                        estado, colonia, Calle, int.Parse(codigoPostal), correo, int.Parse(noTrabajadores),
                        puesto, int.Parse(diasDuracion), motivoEnt, horaEnt, ciudad, int.Parse(noExterior),
                        folio, nombreUsuario, contrasena  // Pasar el nombreUsuario y contrasena correctamente
                    );

                    // Verificar el resultado de la inserción
                    if (resultado)
                    {
                        MessageBox.Show("Dependencia agregada exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la dependencia.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }

                // Limpiar los TextBox y el DateTimePicker
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            // Limpiar todos los controles del formulario
            CvcDependencia.Clear();
            Nombre.Clear();
            RFC_dependencia.Clear();
            calle.Clear();
            Telefono.Clear();
            Codigo_Postal.Clear();
            Correo.Clear();
            No_trabajadores.Clear();
            Puesto.Clear();
            No_ext.Clear();
            Observaciones.Clear();
            Dias_duracion.Clear();
            Hora.Value = DateTime.Now;

            // Limpiar la contraseña
            Contrasena_usuario.Clear();
            Estado.SelectedIndex = -1; // Restablece el ComboBox a no seleccionado
            Colonia.SelectedIndex = -1; // Restablece el ComboBox a no seleccionado
            Actividad_economica.SelectedIndex = -1; // Restablece el ComboBox a no seleccionado
            Tipo_servicio.SelectedIndex = -1; // Restablece el ComboBox a no seleccionado
            Ciudad.SelectedIndex = -1;
        }

        public string GenerarFolio(string nombre, string telefono, string rfc)
        {
            // Validación y ajuste de longitud para nombre
            string nombreFolio = nombre.Length >= 3 ? nombre.Substring(0, 3).ToUpper() : nombre.ToUpper().PadRight(3, 'X');

            // Validación y ajuste de longitud para teléfono
            string telefonoFolio = telefono.Length >= 2 ? telefono.Substring(telefono.Length - 2) : telefono.PadLeft(2, '0');

            // Validación y ajuste de longitud para RFC
            string rfcFolio = rfc.Length >= 2 ? rfc.Substring(rfc.Length - 2) : rfc.PadLeft(2, 'X');

            // Obtener una cadena de fecha y hora con formato específico
            string fechaHoraFolio = DateTime.Now.ToString("yyMMddHH");

            // Combinar todo y ajustar la longitud total a un máximo de 16 caracteres
            string folio = (nombreFolio + telefonoFolio + rfcFolio + fechaHoraFolio).PadRight(16).Substring(0, 16);

            return folio;
        }
        private void Registro_de_Empresa_Load(object sender, EventArgs e)
        {

        }

        private void Actividad_economica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void No_ext_TextChanged(object sender, EventArgs e)
        {

        }
    }
}