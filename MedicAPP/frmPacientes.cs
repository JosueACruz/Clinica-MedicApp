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
            txtNombreRespobsable.Enabled = false;
            txtParentesco.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fecha = dtFecha.Value.Date;
            string cel = txtNumCel.Text;
            string direccion = txtDireccion.Text;
            string DUI = txtDui.Text;
            bool ingre;
            if(chboxResponsable.Checked == false)
            {
                string responsable = "No";
                string parentesco = "No";
                ingre = objPacienteController.ingresarPaciente(nombre, apellido, fecha, cel, direccion, DUI, responsable, parentesco, dgvPacientes);
                if (ingre)
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtNumCel.Text = "";
                    txtDireccion.Text = "";
                    txtDui.Text = "";
                    txtNombreRespobsable.Text = "";
                    txtParentesco.Text = "";
                }
            }
            else
            {
                string responsable = txtNombreRespobsable.Text;
                string parentesco = txtParentesco.Text;
                ingre = objPacienteController.ingresarPaciente(nombre, apellido, fecha, cel, direccion, DUI, responsable, parentesco, dgvPacientes);
                if (ingre)
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtNumCel.Text = "";
                    txtDireccion.Text = "";
                    txtDui.Text = "";
                    txtNombreRespobsable.Text = "";
                    txtParentesco.Text = "";
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool delet;
            delet = objPacienteController.eliminarPaciente(idPaciente, dgvPacientes);
            if(delet)
            {
                idPaciente = 0;
                seleccionado = 0;
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtNumCel.Text = "";
                txtDireccion.Text = "";
                txtDui.Text = "";
                txtNombreRespobsable.Text = "";
                txtParentesco.Text = "";
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fecha = dtFecha.Value;
            string cel = txtNumCel.Text;
            string direccion = txtDireccion.Text;
            string DUI = txtDui.Text;
            bool actuali;
            if (chboxResponsable.Checked == false)
            {
                string responsable = "No";
                string parentesco = "No";
                actuali = objPacienteController.actualizarPaciente(idPaciente,nombre, apellido, fecha, cel, direccion, DUI, responsable, parentesco, dgvPacientes);
                if (actuali)
                {
                    idPaciente = 0;
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtNumCel.Text = "";
                    txtDireccion.Text = "";
                    txtDui.Text = "";
                    txtNombreRespobsable.Text = "";
                    txtParentesco.Text = "";
                }
            }
            else
            {
                string responsable = txtNombreRespobsable.Text;
                string parentesco = txtParentesco.Text;
                actuali = objPacienteController.actualizarPaciente(idPaciente,nombre, apellido, fecha, cel, direccion, DUI, responsable, parentesco, dgvPacientes);
                if (actuali)
                {
                    idPaciente = 0;
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtNumCel.Text = "";
                    txtDireccion.Text = "";
                    txtDui.Text = "";
                    txtNombreRespobsable.Text = "";
                    txtParentesco.Text = "";
                }
            }
        }

        private void dgvPacientes_Click(object sender, EventArgs e)
        {
            seleccionado = dgvPacientes.SelectedRows.Count;
            if (dgvPacientes.CurrentRow == null)
            {
                dgvPacientes.ClearSelection();
            }
            else
            {
                idPaciente = Convert.ToInt32(dgvPacientes.CurrentRow.Cells["Column1"].Value.ToString());
                txtNombre.Text = dgvPacientes.CurrentRow.Cells["Column2"].Value.ToString();
                txtApellido.Text = dgvPacientes.CurrentRow.Cells["Column3"].Value.ToString();
                dtFecha.Value = DateTime.Parse(dgvPacientes.CurrentRow.Cells["column4"].Value.ToString());
                txtNumCel.Text = dgvPacientes.CurrentRow.Cells["Column5"].Value.ToString();
                txtDireccion.Text = dgvPacientes.CurrentRow.Cells["Column6"].Value.ToString();
                txtDui.Text = dgvPacientes.CurrentRow.Cells["Column7"].Value.ToString();
                txtNombreRespobsable.Text = dgvPacientes.CurrentRow.Cells["Column8"].Value.ToString();
                txtParentesco.Text = dgvPacientes.CurrentRow.Cells["Column9"].Value.ToString();
            }
        }

        private void chboxResponsable_CheckedChanged(object sender, EventArgs e)
        {
            if(chboxResponsable.Checked == false)
            {
                //No necesita responsable
                txtNombreRespobsable.Enabled = false;
                txtParentesco.Enabled = false;
            }
            else if(chboxResponsable.Checked == true)
            {
                //Necesita responsable
                txtNombreRespobsable.Enabled = true;
                txtParentesco.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busc = txtBuscar.Text;
            //arreglar que se pueda buscar por DUI tambien o por apellido
            objPacienteController.buscarPaciente(busc, dgvPacientes);
            dgvPacientes.ClearSelection();
        }
    }
}
