using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SivilabApp
{
    public partial class Iniciarsesion : Form
    {
        public Iniciarsesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados
            string nombreUsuario = txbusuario.Text.Trim(); // Quitar espacios en blanco
            string contraseña = txbcontrasena.Text.Trim(); // Quitar espacios en blanco

            // Crear una instancia de Metodos
            Metodos metodos = new Metodos();

            // Validar el usuario
            if (metodos.ValidarUsuario(nombreUsuario, contraseña))
            {
                // Si el usuario es válido, abrir el formulario principal y pasar el nombre de usuario
                SivilabApp form1 = new SivilabApp(nombreUsuario);
                form1.Show();

                // Ocultar el formulario de inicio de sesión
                this.Hide();
            }
            else
            {
                // Si el usuario no es válido, mostrar un mensaje de error
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Iniciarsesion_Load(object sender, EventArgs e)
        {

        }
    }
}