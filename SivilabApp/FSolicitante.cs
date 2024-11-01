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
    public partial class FSolicitante : Form
    {
        public FSolicitante()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRessolicitante_Click(object sender, EventArgs e)
        {

            // Crear una instancia del formulario RegistrarCita
            RegistrarSolicitante frmRegistrarSolicitante = new RegistrarSolicitante();

            // Mostrar el formulario como una ventana
            frmRegistrarSolicitante.Show();

            // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
            // frmRegistrarCita.ShowDialog();
        }
    }
    
}

