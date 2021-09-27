using MedicAPP.Controller;
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
    public partial class frmCitas : Form
    {
        CitaController objCitaController = new CitaController();
        public frmCitas()
        {
            InitializeComponent();
            dgvCitas.RowHeadersVisible = false;
        }

        private void btnCitaNueva_Click(object sender, EventArgs e)
        {
            frmCitaNueva frm = new frmCitaNueva();
            frm.Show();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            objCitaController.cargarCita(dgvCitas);
        }
    }
}
