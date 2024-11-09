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
    public partial class Fcita : Form
    {
        public Fcita()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private MySqlConnection connection;
        private void Fcita_Load(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de la clase ConexionSql
                ConexionSql conexion = new ConexionSql();

                // Establecer la conexión
                MySqlConnection con = conexion.EstablecerConexion();

                // Llamar al método BuscarCitas y pasar la conexión abierta
                BuscarCitas(con);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRcita_Click(object sender, EventArgs e)
            {
                // Crear una instancia del formulario RegistrarCita
                RegistrarCita frmRegistrarCita = new RegistrarCita();

                // Mostrar el formulario como una ventana
                frmRegistrarCita.Show();

                // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
                // frmRegistrarCita.ShowDialog();
            }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void BuscarCitas(MySqlConnection connection)
        {
            try
            {
                // Consulta base para seleccionar las citas
                string query = @"
            SELECT CVC_Cita, Nombre_Completo, Curp_Solicitante, Fecha, Hora, Curp_Usuario
            FROM Citas
            WHERE 1 = 1"; // WHERE 1=1 siempre es verdadero, para facilitar agregar condiciones

                // Lista para los parámetros
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Filtrar por Nombre si el CheckBox está seleccionado
                if (Nombre.Checked && !string.IsNullOrEmpty(Nombre_completo.Text))
                {
                    query += " AND Nombre_Completo LIKE @NombreCompleto";
                    parameters.Add(new MySqlParameter("@NombreCompleto", "%" + Nombre_completo.Text + "%"));
                }

                // Filtrar por Fecha si el CheckBox está seleccionado
                if (Fecha.Checked)
                {
                    query += " AND Fecha = @Fecha";
                    parameters.Add(new MySqlParameter("@Fecha", DateTime.Now.Date)); // Usando la fecha actual, ajusta si necesario
                }

                // Crear un objeto MySqlCommand para ejecutar la consulta
                MySqlCommand command = new MySqlCommand(query, connection);

                // Añadir los parámetros a la consulta
                command.Parameters.AddRange(parameters.ToArray());

                // Crear un objeto MySqlDataAdapter para llenar un DataTable con los resultados de la consulta
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                // Crear un objeto DataTable para almacenar los resultados de la consulta
                DataTable citasTable = new DataTable();

                // Llenar el DataTable con los datos del adaptador
                adapter.Fill(citasTable);

                // Limpiar cualquier dato anterior en el DataGridView
                Citas_consulta.Rows.Clear();

                // Asignar el DataTable como origen de datos del control DataGridView
                Citas_consulta.DataSource = citasTable;

                // Mostrar el número de registros en el TextBox
                Capturados_cant.Text = Citas_consulta.Rows.Count.ToString();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al buscar citas: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RBnombre_CheckedChanged(object sender, EventArgs e)
            {

            }

        private void Citas_consulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}