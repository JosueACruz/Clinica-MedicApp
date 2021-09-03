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
    public partial class frmReceta : Form
    {
        public frmReceta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMedicamentos frm = new frmMedicamentos();
            frm.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AgendarCitacs frm = new AgendarCitacs();
            frm.Show();
        }
    }
}
