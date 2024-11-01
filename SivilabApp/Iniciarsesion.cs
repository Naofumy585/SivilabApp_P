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
            // Crear una nueva instancia de Form1
            SivilabApp form1 = new SivilabApp();

            // Mostrar el Form1
            form1.Show();

            // Opcional: Ocultar el formulario actual (el formulario donde está el botón Ingresar)
            this.Hide();
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
