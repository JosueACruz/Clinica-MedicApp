using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicAPP
{
    public partial class frmListaMedicamentos : Form
    {
        public frmListaMedicamentos()
        {
            InitializeComponent();
            dgvMedicamentos.RowHeadersVisible = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaMedicamentos_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);
            //Aqui cargar la lista de medicamentos
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
