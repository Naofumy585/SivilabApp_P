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
    public partial class SivilabApp : Form
    {
        public SivilabApp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SivilabApp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpiar cualquier instancia previa de Citas_cu en el formulario
            foreach (Control control in this.Controls)
            {
                if (control is Citas_cu)
                {
                    this.Controls.Remove(control);
                    control.Dispose(); // Liberar recursos del control removido
                }
            }

            // Crear una nueva instancia de Citas_cu
            Citas_cu citasControl = new Citas_cu
            {
                Location = new Point(10, 100), // Establecer ubicación para que aparezca debajo de los botones
                Width = 500,                   // Ajustar ancho del control
                Height = 300                   // Ajustar altura del control
            };

            // Agregar Citas_cu al formulario
            this.Controls.Add(citasControl);
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
    }
}
