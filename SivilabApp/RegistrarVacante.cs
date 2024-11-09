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
    public partial class RegistrarVacante : Form
    {
        public RegistrarVacante()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void cbxTurnoLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
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
                    // Si el usuario es válido, se puede proceder a agregar la vacante
                    string cvcDependencia = Cvcdependencia.Text;
                    string prestaciones = Otras_prestaciones.Text;
                    string tipocontrato = Tipo_contrato.Text;
                    string estatus = Estado_civil.Text;
                    string puesto_ofrecido = Puesto_ofrecido.Text;
                    string salarioM = SalarioM.Text;
                    string no_pla = No_pla.Text;
                    string horas = Horas.Text;
                    string escolaridad = Escolaridad.Text;
                    string sexo = Sexo.Text;
                    string rangoEdad = Rango_edad.Text;
                    string habilidad = Habilidades.Text;
                    bool licencia = Licencia_de_manejo.Checked;
                    bool cartilla = Cartilla.Checked;
                    bool Disviajar = Disponible_viaje.Checked;
                    bool Disafuera = Disponible_viaje.Checked;
                    string tipoVacante = Tipo_de_vacante.Text;
                    string tipoEmp = Modalidad.Text;
                    DateTime vigencia = Vigencia.Value;

                    // Generar CVC de la vacante con los datos del formulario
                    string cvcVacante = GenerarCvcVacante(escolaridad, puesto_ofrecido, tipoVacante, tipoEmp);

                    // Validar que los datos obligatorios no estén vacíos
                    if (string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(cvcDependencia) || string.IsNullOrEmpty(puesto_ofrecido))
                    {
                        MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Establecer conexión con la base de datos
                    using (var conexionSql = new ConexionSql())
                    using (MySqlConnection connection = conexionSql.EstablecerConexion())
                    {
                        if (connection == null || connection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("No se pudo abrir la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        // Llamar a AgregarVacante pasando la conexión abierta y los parámetros
                        Metodos vacanteService = new Metodos();

                        bool vacanteAgregada = vacanteService.AgregarVacante(
                            cvcVacante,      // string cvcVacante
                            vigencia,        // DateTime vigencia
                            contrasena,      // string contrasena
                            prestaciones,    // string prestaciones
                            estatus,         // string estatus
                            tipoVacante,     // string tipoVacante
                            tipoEmp,         // string tipoEmp
                            tipocontrato,    // string tipocontrato
                            puesto_ofrecido, // string puesto_ofrecido
                            cvcDependencia,  // string cvcDependencia
                           decimal.Parse (salarioM),        // string salarioM
                            int.Parse( no_pla),          // string no_pla
                            int.Parse(horas),           // string horas
                            escolaridad,     // string escolaridad
                            sexo,            // string sexo
                            licencia,        // bool licencia
                            cartilla,        // bool cartilla
                            Disviajar,       // bool Disviajar
                            Disafuera,       // bool Disafuera
                            rangoEdad,       // string rangoEdad
                            habilidad,       // string habilidad
                            nombreUsuario,   // string nombreUsuario
                            connection       // MySqlConnection connection
                        );

                        if (vacanteAgregada)
                        {
                            MessageBox.Show("Vacante agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al agregar la vacante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
        public string GenerarCvcVacante(string escolaridad, string puesto_ofrecido, string tipoVacante, string tipoEmp)
        {
            // Validación y ajuste de longitud para escolaridad (3 caracteres)
            string escolaridadcvc = escolaridad.Length >= 3 ? escolaridad.Substring(0, 3).ToUpper() : escolaridad.ToUpper().PadRight(3, 'X');

            // Validación y ajuste de longitud para puesto ofrecido (últimos 2 caracteres)
            string puesto_ofrecidocvc = puesto_ofrecido.Length >= 2 ? puesto_ofrecido.Substring(puesto_ofrecido.Length - 2) : puesto_ofrecido.PadLeft(2, '0');

            // Validación y ajuste de longitud para tipo de vacante (últimos 2 caracteres)
            string tipoVacantecvc = tipoVacante.Length >= 2 ? tipoVacante.Substring(tipoVacante.Length - 2) : tipoVacante.PadLeft(2, 'X');

            // Validación y ajuste de longitud para tipo de empleo (2 caracteres)
            string tipoEmpcvc = tipoEmp.Length >= 2 ? tipoEmp.Substring(0, 2).ToUpper() : tipoEmp.ToUpper().PadRight(2, 'X');

            // Combinar todo y ajustar la longitud total a un máximo de 16 caracteres
            string cvcVacante = (escolaridadcvc + puesto_ofrecidocvc + tipoVacantecvc + tipoEmpcvc).PadRight(16).Substring(0, 16);

            return cvcVacante;
        }

    }
}