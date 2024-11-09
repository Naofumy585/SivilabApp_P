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
    public partial class ConsultarVacantes : Form
    {
        public ConsultarVacantes()
        {
            InitializeComponent();
        }

        private void txbPuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarVacantes_Load(object sender, EventArgs e)
        {
            // Obtener el valor de búsqueda desde el control (por ejemplo, un TextBox)
            string busqueda = Busqueda.Text.Trim(); // Asegúrate de que "Busqueda" sea el nombre del TextBox para la búsqueda

            // Verificar si el campo de búsqueda está vacío
            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Búsqueda Vacante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Usar el CURP del usuario almacenado en la sesión
            string curpUsuario = Session.CurpUsuario;

            // Llamar al método BuscarVacante con los valores de busqueda y curpUsuario
            BuscarVacante(busqueda, curpUsuario);

            // También puedes llamar a LlenarComboBoxVacantes para llenar el ComboBox
            LlenarComboBoxVacantes(curpUsuario);
        }
        private void LlenarComboBoxVacantes(string curpUsuario)
        {
            try
            {
                using (ConexionSql conexion = new ConexionSql())
                {
                    MySqlConnection connection = conexion.EstablecerConexion();
                    if (connection == null)
                    {
                        MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Consulta para obtener todos los CvcVacante disponibles para el usuario
                    string query = "SELECT CvcVacante FROM Vacante WHERE Curp_usuario = @CurpUsuario";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CurpUsuario", curpUsuario);

                    MySqlDataReader reader = command.ExecuteReader();

                    // Limpiar el ComboBox antes de llenarlo
                    Folio.Items.Clear();

                    // Añadir todos los CvcVacante al ComboBox
                    while (reader.Read())
                    {
                        Folio.Items.Add(reader["CvcVacante"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las vacantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static class Session
        {
            public static string CurpUsuario { get; set; }
        }
        private void Buscar_Click(object sender, EventArgs e)
        {
            // Realizar la búsqueda usando la sesión actual
            string busqueda = Busqueda.Text.Trim();
            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Por favor ingrese un valor de búsqueda.", "Búsqueda Vacante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Usar el CURP del usuario en la búsqueda
            BuscarVacante(busqueda, Session.CurpUsuario);
            LlenarComboBoxVacantes(Session.CurpUsuario);
        }

        private void BuscarVacante(string busqueda, string curpUsuario)
        {
            try
            {
                using (ConexionSql conexion = new ConexionSql())
                {
                    MySqlConnection connection = conexion.EstablecerConexion();
                    if (connection == null)
                    {
                        MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Crear un DataTable para almacenar los resultados
                    DataTable dt = new DataTable();

                    // Consulta para filtrar las vacantes por el CURP del usuario
                    string query = @"
                SELECT CvcVacante, Vigencia, Tipo_de_vacante, Puesto_ofrecido, Turno_laboral, Salario_M, 
                       NO_plazas, Tipo_contrato, Horarios, Escolaridad, Otras_prestaciones, Estado_civil, 
                       Rango_edad, Habilidades, Sexo, Licencia_de_manejo, Cartilla, Disponible_viaje, 
                       Disponible_afuera, CvcDependencia, Curp_usuario, Curp_Solicitante
                FROM Vacante
                WHERE Curp_usuario = @CurpUsuario AND CvcVacante LIKE @Busqueda";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CurpUsuario", curpUsuario);
                    command.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%");

                    // Llenar el DataTable con los resultados de la consulta
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dt);

                    // Verificar si hay resultados
                    if (dt.Rows.Count > 0)
                    {
                        // Asignar el DataTable al DataGridView
                        dataGridView1.DataSource = dt;  // Asegúrate de tener un DataGridView llamado "dataGridView1"
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron vacantes para la búsqueda.", "Búsqueda Vacante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}