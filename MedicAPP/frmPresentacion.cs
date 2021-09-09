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
    public partial class frmPresentacion : Form
    {
        //LLamado al controlador de las presentaciones
        PresentacionMedicamentoController presentacionController = new PresentacionMedicamentoController();

        //Variables globales del formulario
        int seleccionado = 0;
        int idPresentacion = 0;
        public frmPresentacion()
        {
            InitializeComponent();
            dgvMedicamentos.RowHeadersVisible = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);
            presentacionController.cargarPresentacion(dgvMedicamentos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string presentacion = txtPresentacion.Text;
            bool ingre;
            ingre = presentacionController.ingresarPresentacionMedicamento(presentacion, dgvMedicamentos);
            if (ingre)
            {
                txtPresentacion.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool delete;
            delete = presentacionController.eliminarPresentacionMedicamento(idPresentacion, dgvMedicamentos);
            if (delete)
            {
                txtPresentacion.Text = "";
                idPresentacion = 0;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool respon;
            string presentacion= txtPresentacion.Text;
            respon = presentacionController.actualizarPresentacionMedicamento(idPresentacion, presentacion, dgvMedicamentos);
            if (respon)
            {
                txtPresentacion.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string presentacion = txtPresentacion.Text;
            presentacionController.buscarPresentacionMedicamento(presentacion, dgvMedicamentos);
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
                idPresentacion = Convert.ToInt32(dgvMedicamentos.CurrentRow.Cells["Column2"].Value.ToString());
                txtPresentacion.Text = dgvMedicamentos.CurrentRow.Cells["Column1"].Value.ToString();
            }
        }
    }
}
