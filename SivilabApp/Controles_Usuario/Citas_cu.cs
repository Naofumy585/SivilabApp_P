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
    public partial class Citas_cu : UserControl
    {
        public Citas_cu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Código del evento del pictureBox1
        }

        private void Citas_cu_Load(object sender, EventArgs e)
        {
            // Código del evento Load
        }

        private void btnRcita_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario RegistrarCita
            RegistrarCita registrarCita = new RegistrarCita();

            // Mostrar el formulario como una ventana
            registrarCita.Show();

            // O si prefieres que sea modal
            // frmRegistrarCita.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Código del evento del pictureBox4
        }
    }
}