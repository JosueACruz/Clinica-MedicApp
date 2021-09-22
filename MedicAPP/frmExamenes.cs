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
    public partial class frmExamenes : Form
    {
        ExamenController examController = new ExamenController();
        int seleccionado = 0;
        int idExamen = 0;
        public frmExamenes()
        {
            InitializeComponent();
            dgvExamen.RowHeadersVisible = false;
        }
        
        //btnCategoria
        private void button2_Click(object sender, EventArgs e)
        {
            frmExamenCategoria frm = new frmExamenCategoria();
            frm.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string examen = txtExamen.Text;
            string descripcion = txtDescripcion.Text;
            int categoria = (int)cmbCategoria.SelectedValue;
            if(examen == "" || descripcion == "" || categoria == 0)
            {
                MessageBox.Show("Por favor llene todos los campos para ingresar el examen", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool ingre;
                ingre = examController.ingresarExamen(examen, descripcion, categoria, dgvExamen);
                if (ingre)
                {
                    txtExamen.Text = "";
                    txtExamen.Focus();
                    txtDescripcion.Text = "";
                    cmbCategoria.SelectedIndex = 0;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string examen = txtExamen.Text;
            string descripcion = txtDescripcion.Text;
            int categoria = (int)cmbCategoria.SelectedValue;
            if (examen == "" || descripcion == "" || categoria == 0)
            {
                MessageBox.Show("Por favor llene todos los campos para ingresar el examen", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool edit;
                edit = examController.actualizarExamen(idExamen, examen, descripcion, categoria, dgvExamen);
                if (edit)
                {
                    txtExamen.Text = "";
                    txtExamen.Focus();
                    txtDescripcion.Text = "";
                    cmbCategoria.SelectedIndex = 0;
                    idExamen = 0;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool delt;
            delt = examController.eliminarExamen(idExamen, dgvExamen);
            if (delt)
            {
                txtExamen.Text = "";
                txtExamen.Focus();
                txtDescripcion.Text = "";
                cmbCategoria.SelectedIndex = 0;
                idExamen= 0;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string examen = txtExamen.Text;
            examController.buscarExamen(examen, dgvExamen);
            dgvExamen.ClearSelection();
        }

        private void frmExamenes_Load(object sender, EventArgs e)
        {
            examController.cargarExamen(dgvExamen);
            examController.llenarCategoria(cmbCategoria);
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
                idExamen = Convert.ToInt32(dgvExamen.CurrentRow.Cells["Column4"].Value.ToString());
                txtExamen.Text = dgvExamen.CurrentRow.Cells["Column1"].Value.ToString();
                txtDescripcion.Text = dgvExamen.CurrentRow.Cells["Column2"].Value.ToString();
                cmbCategoria.SelectedValue = Convert.ToInt32(dgvExamen.CurrentRow.Cells["Column5"].Value.ToString());
            }
        }
    }
}
