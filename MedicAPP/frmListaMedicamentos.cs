using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicAPP.Controller;

namespace MedicAPP
{
    public partial class frmListaMedicamentos : Form
    {
        MedicamentoController medicController = new MedicamentoController();

        int seleccionado = 0;
        int idMedicamento= 0;

        public frmListaMedicamentos()
        {
            InitializeComponent();
            dgvMedicamentos.RowHeadersVisible = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaMedicamentos_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);
            //Aqui cargar la lista de medicamentos
            medicController.cargarMedicamento(dgvMedicamentos);
            medicController.llenarLaboratorio(cmbLaboratorio);
            medicController.llenarCategoria(cmbCategoria);
            medicController.llenarPresentacion(cmbPresentacion);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
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
                idMedicamento = Convert.ToInt32(dgvMedicamentos.CurrentRow.Cells["Column2"].Value.ToString());
                txtNombre.Text = dgvMedicamentos.CurrentRow.Cells["Column1"].Value.ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string medicamento = txtNombre.Text;
            medicController.buscarMedicamento(medicamento, dgvMedicamentos);
            dgvMedicamentos.ClearSelection();
        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            Console.WriteLine(cmbLaboratorio.SelectedValue);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string medicamento = txtNombre.Text;
            int Laboratorio = (int)cmbLaboratorio.SelectedValue;
            int Presentacion = (int)cmbPresentacion.SelectedValue;
            int Categoria = (int)cmbCategoria.SelectedValue;
            if (medicamento == "" || Laboratorio == 0 || Presentacion == 0 || Categoria == 0)
            {
                MessageBox.Show("Por favor llene todos los campos para ingresar el medicamento", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                bool ingre;
                ingre = medicController.ingresarMedicamento(medicamento, Laboratorio, Presentacion, Categoria, dgvMedicamentos);
                if(ingre)
                {
                    txtNombre.Text = "";
                    txtNombre.Focus();
                    cmbCategoria.SelectedIndex = 0;
                    cmbLaboratorio.SelectedIndex = 0;
                    cmbPresentacion.SelectedIndex = 0;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnPresentacion_Click(object sender, EventArgs e)
        {
            Console.WriteLine(cmbPresentacion.SelectedValue);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Console.WriteLine(cmbCategoria.SelectedValue);
        }
    }
}
