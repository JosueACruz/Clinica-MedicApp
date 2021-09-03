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
    public partial class frmConsultaNueva : Form
    {
        public frmConsultaNueva()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            frmReceta frm = new frmReceta();
            frm.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
