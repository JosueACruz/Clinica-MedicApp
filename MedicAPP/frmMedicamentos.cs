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
    public partial class frmMedicamentos : Form
    {
        public frmMedicamentos()
        {
            InitializeComponent();
        }

        private void btnListaMedicamentos_Click(object sender, EventArgs e)
        {
            frmListaMedicamentos frm = new frmListaMedicamentos();
            frm.Show();
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            //frmMedicamentoNuevo frm = new frmMedicamentoNuevo();
            //frm.Show();
        }

        private void btnCategoriaMedicamento_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.Show();
        }

        private void btnPresentacionMedicamento_Click(object sender, EventArgs e)
        {
            frmPresentacion frm = new frmPresentacion();
            frm.Show();
        }

        private void btnMarcaMedicamento_Click(object sender, EventArgs e)
        {
            frmLaboratorio frm = new frmLaboratorio();
            frm.Show();

        }
    }
}
