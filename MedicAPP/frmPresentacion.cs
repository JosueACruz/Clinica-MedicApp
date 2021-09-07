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
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
            dgvMedicamentos.RowHeadersVisible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);

        }
    }
}
