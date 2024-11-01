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
    public partial class FVacantes : Form
    {
        public FVacantes()
        {
            InitializeComponent();
        }

        private void FVacantes_Load(object sender, EventArgs e)
        {

        }

        private void btnEdiVacante_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario EditarVacante
            EditarVacante frmEditarVacante = new EditarVacante();

            // Mostrar el formulario como una ventana
            frmEditarVacante.Show();

            // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
            // frmEditarVacante.ShowDialog();
        }

        private void btnVacantesEnvio_Click(object sender, EventArgs e)
        {

            // Crear una instancia del formulario VacantesconEnvios
            VacantesconEnvios frmVacantesconEnvios = new VacantesconEnvios();

            // Mostrar el formulario como una ventana
            frmVacantesconEnvios.Show();

            // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
            // frmVacantesconEnvios.ShowDialog();
        }

        private void brnCancelarSeguimiento_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisVacante_Click(object sender, EventArgs e)
        {
            {
                // Crear una instancia del formulario RegistrarVacante
                RegistrarVacante frmRegistrarVacante = new RegistrarVacante();

                // Mostrar el formulario como una ventana
                frmRegistrarVacante.Show();

                // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
                // frmRegistrarVacante.ShowDialog();
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario ConsultarVacantes
            ConsultarVacantes frmConsultarVacantes = new ConsultarVacantes();

            // Mostrar el formulario como una ventana
            frmConsultarVacantes.Show();

            // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
            // frmRegistrarVacante.ShowDialog();
        }

        private void btnDependencias_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario BuscarDependencia
            BuscarDependencia frmBuscarDependencia = new BuscarDependencia();

            // Mostrar el formulario como una ventana
            frmBuscarDependencia.Show();

            // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
            // frmRegistrarVacante.ShowDialog();
        }

        private void btnVacanteSinEnvio_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario BuscarDependencia
            VacantessinEnvios frmVacantessinEnvios = new VacantessinEnvios();

            // Mostrar el formulario como una ventana
            frmVacantessinEnvios.Show();

            // O si prefieres que sea modal (el usuario debe cerrarlo antes de volver al formulario principal)
            // frmRegistrarVacante.ShowDialog();
        }
    }
    
}

