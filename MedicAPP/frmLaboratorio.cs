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
    public partial class frmLaboratorio : Form
    {
        LaboratorioMedicamentoController labMedicamento = new LaboratorioMedicamentoController();
        int seleccionado = 0;
        int idLab = 0;
        public frmLaboratorio()
        {
            InitializeComponent();
            dgvMedicamentos.RowHeadersVisible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLaboratorio_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);
            labMedicamento.cargarLabratorioMedic(dgvMedicamentos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string laboratorio = txtLaboratorio.Text;
            bool ingre;
            ingre = labMedicamento.ingresarLaboratorioMedic(laboratorio, dgvMedicamentos);
            if(ingre)
            {
                txtLaboratorio.Text = "";
                idLab = 0;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool delet;
            delet = labMedicamento.eliminarLaboratorioMedic(idLab, dgvMedicamentos);
            if(delet)
            {
                txtLaboratorio.Text = "";
                idLab = 0;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool edit;
            string laboratorio = txtLaboratorio.Text;
            edit = labMedicamento.actualizarLaboratorioMedic(idLab, laboratorio, dgvMedicamentos);
            if(edit)
            {
                txtLaboratorio.Text = "";
                idLab = 0;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string laboratorio = txtLaboratorio.Text;
            labMedicamento.buscarCategoriaMedic(laboratorio, dgvMedicamentos);
            dgvMedicamentos.ClearSelection();
        }

        private void dgvMedicamentos_Click(object sender, EventArgs e)
        {
            seleccionado = dgvMedicamentos.SelectedRows.Count;
            if (dgvMedicamentos.CurrentRow == null)
            {
                dgvMedicamentos.ClearSelection();
            }
            else
            {
                idLab = Convert.ToInt32(dgvMedicamentos.CurrentRow.Cells["Column2"].Value.ToString());
                txtLaboratorio.Text = dgvMedicamentos.CurrentRow.Cells["Column1"].Value.ToString();
            }
        }
    }
}
