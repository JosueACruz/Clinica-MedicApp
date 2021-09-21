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
    public partial class frmExamenCategoria : Form
    {
        ExamenCategoriaController categoController = new ExamenCategoriaController();

        //VAriables globales del formulario para llenar la seleccion de algun elemento del datagrid 
        int seleccionado = 0;
        int idCate = 0;
        public frmExamenCategoria()
        {
            InitializeComponent();
            dgvExamen.RowHeadersVisible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string categoria = txtCategoria.Text;
            string descripcion = txtDescripcion.Text;
            bool ingre;
            ingre = categoController.ingresarCategoriaMedic(categoria, descripcion, dgvExamen);
            if(ingre)
            {
                txtCategoria.Text = "";
                txtDescripcion.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool delt;
            delt = categoController.eliminarCategoriaMedic(idCate, dgvExamen);
            if (delt)
            {
                txtCategoria.Text = "";
                txtDescripcion.Text = "";
                idCate = 0;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool respon;
            string categoria = txtCategoria.Text;
            string descripcion = txtDescripcion.Text;
            respon = categoController.actualizarCategoriaMedic(idCate, categoria, descripcion, dgvExamen);
            if (respon)
            {
                txtCategoria.Text = "";
                txtDescripcion.Text = "";
                idCate = 0;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoria = txtCategoria.Text;
            categoController.buscarCategoriaMedic(categoria, dgvExamen);
            dgvExamen.ClearSelection();
        }

        private void frmExamenCategoria_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);
            categoController.cargarCategoriaMedic(dgvExamen);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvExamen_Click(object sender, EventArgs e)
        {
            seleccionado = dgvExamen.SelectedRows.Count;
            if (dgvExamen.CurrentRow == null)
            {
                dgvExamen.ClearSelection();
            }
            else
            {
                idCate = Convert.ToInt32(dgvExamen.CurrentRow.Cells["Column2"].Value.ToString());
                txtCategoria.Text = dgvExamen.CurrentRow.Cells["Column1"].Value.ToString();
                txtDescripcion.Text = dgvExamen.CurrentRow.Cells["Column3"].Value.ToString();
            }
        }
    }
}
