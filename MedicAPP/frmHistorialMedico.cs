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
    public partial class frmHistorialMedico : Form
    {
        public frmHistorialMedico()
        {
            InitializeComponent();
        }

        private void btnVerExpediente_Click(object sender, EventArgs e)
        {
            frmExpediente frm = new frmExpediente();
            frm.Show();
        }
    }
}
