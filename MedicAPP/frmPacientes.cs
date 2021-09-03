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
    public partial class frmPacientes : Form
    {
        public frmPacientes()
        {
            InitializeComponent();
        }

        private void btnHistorialMedpaciente_Click(object sender, EventArgs e)
        {
            frmHistorialMedico frm = new frmHistorialMedico();
            frm.Show();
        }

        private void btnNuevaConsulta_Click(object sender, EventArgs e)
        {
            frmConsultaNueva frm = new frmConsultaNueva();
            frm.Show();
        }
    }
}
