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
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
        }

        private void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            frmConsultaNueva frm = new frmConsultaNueva();
            frm.Show();
        }

        private void btnConsultaporCita_Click(object sender, EventArgs e)
        {

        }
    }
}
