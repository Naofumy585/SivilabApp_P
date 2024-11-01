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
    public partial class Fcita : Form
    {
        public Fcita()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Fcita_Load(object sender, EventArgs e)
        {

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
    }
    
}
