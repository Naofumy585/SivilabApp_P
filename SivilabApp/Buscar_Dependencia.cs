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
    public partial class Buscar_Dependencia : Form
    {
        public Buscar_Dependencia()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Registrar_dependecia_Click(object sender, EventArgs e)
        {
            Registro_de_Empresa For_Rdepemdencia = new Registro_de_Empresa();
            For_Rdepemdencia.Show();
        }

        private void Buscar_Dependencia_Load(object sender, EventArgs e)
        {

        }
    }
}
