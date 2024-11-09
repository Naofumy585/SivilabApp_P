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
    public partial class FSolicitante : Form
    {
        private MySqlConnection con;

        public FSolicitante()
        {
            InitializeComponent();
            // Inicializar la conexión al formulario
            ConexionSql conexion = new ConexionSql();
            con = conexion.EstablecerConexion(); // Mantener la conexión abierta
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRessolicitante_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario RegistrarSolicitante
            RegistrarSolicitante frmRegistrarSolicitante = new RegistrarSolicitante();

            // Mostrar el formulario como una ventana
            frmRegistrarSolicitante.Show();

            // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
            // frmRegistrarCita.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Llamar al método BuscarSolicitudes y pasar la conexión abierta
                BuscarSolicitudes(con);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarSolicitudes(MySqlConnection connection)
        {
            try
            {
                // Obtener el valor del TextBox de búsqueda
                string busqueda = Busqueda.Text.Trim();

                // Consulta base para seleccionar las solicitudes
                string query = @"
            SELECT Folio, ApellidoPaterno, ApellidoMaterno, Nombre_solicitante, Rfc, Correo, Estado_migratorio, 
                   Fecha_Nacimiento, Escolaridad, Genero, Telefono, Direccion, Cvc_cedula, Curp_Solicitante, Curp, Curp_usuario
            FROM Solicitud
            WHERE 1 = 1"; // WHERE 1=1 siempre es verdadero para facilitar agregar condiciones

                // Lista de parámetros
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Condición dinámica por lo que se escriba en Busqueda.Text
                if (!string.IsNullOrEmpty(busqueda))
                {
                    query += " AND (Folio LIKE @Busqueda OR Rfc LIKE @Busqueda OR Curp LIKE @Busqueda OR Nombre_solicitante LIKE @Busqueda OR " +
                             "ApellidoPaterno LIKE @Busqueda OR ApellidoMaterno LIKE @Busqueda OR Correo LIKE @Busqueda OR Estado_migratorio LIKE @Busqueda OR " +
                             "Fecha_Nacimiento LIKE @Busqueda OR Escolaridad LIKE @Busqueda OR Genero LIKE @Busqueda OR Telefono LIKE @Busqueda OR " +
                             "Direccion LIKE @Busqueda OR Cvc_cedula LIKE @Busqueda OR Curp_Solicitante LIKE @Busqueda OR Curp_usuario LIKE @Busqueda)";

                    // Agregar el parámetro para la búsqueda
                    parameters.Add(new MySqlParameter("@Busqueda", "%" + busqueda + "%"));
                }

                // Crear un objeto MySqlCommand para ejecutar la consulta
                MySqlCommand command = new MySqlCommand(query, connection);

                // Añadir los parámetros a la consulta
                command.Parameters.AddRange(parameters.ToArray());

                // Crear un objeto MySqlDataAdapter para llenar un DataTable con los resultados de la consulta
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                // Crear un objeto DataTable para almacenar los resultados de la consulta
                DataTable solicitudesTable = new DataTable();

                // Llenar el DataTable con los datos del adaptador
                adapter.Fill(solicitudesTable);

                // Limpiar cualquier dato anterior en el DataGridView
                Solicitud_resultado.Rows.Clear();

                // Asignar el DataTable como origen de datos del control DataGridView
                Solicitud_resultado.DataSource = solicitudesTable;

               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al buscar solicitudes: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Busqueda_TextChanged(object sender, EventArgs e)
        {
            // Solo realizar la búsqueda si el TextBox tiene texto
            if (!string.IsNullOrEmpty(Busqueda.Text))
            {
                try
                {
                    // Llamar al método BuscarSolicitudes usando la conexión abierta
                    BuscarSolicitudes(con);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Cuando el formulario se cierra, liberar la conexión
        private void FSolicitante_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void FSolicitante_Load(object sender, EventArgs e)
        {
            try
            {
                // Llamar al método BuscarSolicitudes y pasar la conexión abierta
                BuscarSolicitudes(con);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}