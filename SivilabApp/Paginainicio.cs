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
    public partial class SivilabApp : Form
    {
        private string nombreUsuario;
        public SivilabApp(string nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario; // Guardar el nombre de usuario
        }
        public SivilabApp()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SivilabApp_Load(object sender, EventArgs e)
        {
            // Limpiar el texto del TextBox y mostrar el nombre del usuario
            txbBienvenido.Text = ""; // Borra cualquier texto anterior
            txbBienvenido.Text = $"Hola, {nombreUsuario}!"; // Asignar el nombre del usuario
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Fcita
            Fcita formCita = new Fcita();

            // Mostrar el formulario
            formCita.Show(); // Usa ShowDialog() si quieres que sea modal
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnSolicitante_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FSolicitante
            FSolicitante formSolicitantes = new FSolicitante();

            // Mostrar el formulario
            formSolicitantes.Show(); // Usa ShowDialog() si quieres que sea modal
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual
            this.Close();
        }

        private void btnVacante_Click(object sender, EventArgs e)
        {
            //Crear una instancia del formulario FVacantes
            FVacantes formVacantes = new FVacantes();

            //Mostrar el Formulario
            formVacantes.Show(); 

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txbBienvenido_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDependencia_Click(object sender, EventArgs e)
        {
            //Crear una instancia del formulario FVacantes
            Buscar_Dependencia formDependencia = new Buscar_Dependencia();

            //Mostrar el Formulario
            formDependencia.Show();
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            //Crear una instancia del formulario FVacantes
            RegistroEvento formEventos = new RegistroEvento();

            //Mostrar el Formulario
            formEventos.Show();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reportes formreportes = new Reportes();
            formreportes.Show();
        }
    }
}