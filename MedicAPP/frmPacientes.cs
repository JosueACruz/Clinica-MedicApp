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
    public partial class frmPacientes : Form
    {
        PacientesController objPacienteController = new PacientesController();

        int seleccionado = 0;
        int idPaciente = 0;
        public frmPacientes()
        {
            InitializeComponent();
            dgvPacientes.RowHeadersVisible = false;
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

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            objPacienteController.cargarPaciente(dgvPacientes);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void dgvPacientes_Click(object sender, EventArgs e)
        {

        }
    }
}
