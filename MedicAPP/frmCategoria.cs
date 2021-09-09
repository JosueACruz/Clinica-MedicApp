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
    public partial class frmCategoria : Form
    {
        //Controladores.MedCategoriaController categoriaController = new Controladores.MedCategoriaController();
        CategoriaMedicamentoController categoController = new CategoriaMedicamentoController();

        int seleccionado = 0;
        int idCate = 0;
        public frmCategoria()
        {
            InitializeComponent();
            dgvMedicamentos.RowHeadersVisible = false;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
           this.Location = new Point(270, 60);
            //dgvMedicamentos.DataSource = categoriaController.GetList();
            categoController.cargarCategoriaMedic(dgvMedicamentos);
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string categoria = txtCategoria.Text;
            bool ingre;
            ingre = categoController.ingresarCategoriaMedic(categoria, dgvMedicamentos);
            if (ingre)
            {
                txtCategoria.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool delt;
            delt = categoController.eliminarCategoriaMedic(idCate, dgvMedicamentos);
            if(delt)
            {
                txtCategoria.Text = "";
                idCate = 0;
            }
        }

        private void dgvMedicamentos_Click(object sender, EventArgs e)
        {
            seleccionado = dgvMedicamentos.SelectedRows.Count;
            if(dgvMedicamentos.CurrentRow == null)
            {
                dgvMedicamentos.ClearSelection();
            }
            else
            {
                idCate = Convert.ToInt32(dgvMedicamentos.CurrentRow.Cells["Column2"].Value.ToString());
                txtCategoria.Text = dgvMedicamentos.CurrentRow.Cells["Column1"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool respon;
            string categoria = txtCategoria.Text;
            respon = categoController.actualizarCategoriaMedic(idCate, categoria, dgvMedicamentos);
            if (respon)
            {
                txtCategoria.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoria = txtCategoria.Text;
            categoController.buscarCategoriaMedic(categoria, dgvMedicamentos);
            dgvMedicamentos.ClearSelection();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
