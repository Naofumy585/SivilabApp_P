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
    public partial class Iniciarsesion : Form
    {
        public Iniciarsesion()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Llamar al método del botón
                btnIngresar.PerformClick();
                e.SuppressKeyPress = true; // Opcional: evitar el sonido de "ding" al presionar Enter
            }
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados y quitar espacios en blanco
            string nombreUsuario = txbusuario.Text.Trim();
            string contrasena = txbcontrasena.Text.Trim();

            // Verificar si el usuario existe
            if (Usuarios.ExisteUsuario(nombreUsuario))
            {
                // Verificar la contraseña
                if (Usuarios.VerificarContrasena(nombreUsuario, contrasena))
                {
                    // Obtener el CURP del usuario
                    string curpUsuario = Usuarios.ObtenerCurpUsuario(nombreUsuario);

                    // Configurar el usuario actual en la sesión
                    Session.UsuarioActual = new Usuario
                    {
                        CurpUsuario = curpUsuario,
                        NombreUsuario = nombreUsuario
                        // Agrega más propiedades si es necesario
                    };

                    // Mostrar mensaje de éxito en el inicio de sesión
                    MessageBox.Show("Inicio de sesión exitoso.");

                    // Abrir el formulario principal y pasar el nombre de usuario
                    SivilabApp form1 = new SivilabApp(nombreUsuario);
                    form1.Show();

                    // Ocultar el formulario de inicio de sesión
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El usuario no existe.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.KeyPreview = true; // Habilitar el formulario para recibir teclas antes de los controles
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // Vincular el evento KeyDown

        }
    }
}