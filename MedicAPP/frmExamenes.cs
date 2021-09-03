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
    public partial class frmExamenes : Form
    {
        public frmExamenes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmExamenNuevo frm = new frmExamenNuevo();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmExamenCategoria frm = new frmExamenCategoria();
            frm.Show();
        }
    }
}
