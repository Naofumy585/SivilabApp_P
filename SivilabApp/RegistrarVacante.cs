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
                // Obtener los datos del formulario
                string cvcVacante = CvcVacante.Text;
                DateTime vigencia = Vigencia.Value;
                string prestaciones = Otras_prestaciones.Text;
                string estatus = Estado_civil.Text;
                string puestoSolicita = Puesto_solicta.Text;
                string curpUsuario = Session.UsuarioActual?.CurpUsuario;
                string salarioM = SalarioM.Text;
                string no_pla = No_pla.Text;
                string horas = Horas.Text;
                string escolaridad = Escolaridad.Text;
                string sexo = Sexo.Text;
                string rangoEdad = Rango_edad.Text;
                bool licencia = Licencia_de_manejo.Checked;
                bool cartilla = Cartilla.Checked;
                string tipoVacante = Tipo.Text;
                string tipoEmp = Modalidad.Text;

                // Crear una instancia de la clase Metodos
                Metodos metodos = new Metodos();

                // Llamar al método AgregarVacante
                bool vacanteAgregada = metodos.AgregarVacante(
                    cvcVacante,
                    curpUsuario,
                    vigencia,
                    prestaciones,
                    estatus,
                    tipoVacante,
                    tipoEmp,
                    puestoSolicita,
                    curpUsuario, // Reemplaza por el ID de la dependencia si está disponible
                    salarioM,
                    no_pla,
                    horas,
                    tipoVacante,
                    tipoEmp,
                    escolaridad,
                    sexo,
                    licencia,
                    cartilla,
                    rangoEdad
                );

                // Verificar si la vacante fue agregada correctamente
                if (vacanteAgregada)
                {
                    MessageBox.Show("Vacante agregada exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al agregar la vacante. Intente nuevamente.");
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
