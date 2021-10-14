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
        int seleccionado = 0;
        int idCita = 0;
        public frmCitas()
        {
            InitializeComponent();
            dgvCitas.RowHeadersVisible = false;
        }

        private void btnCitaNueva_Click(object sender, EventArgs e)
        {
            frmCitaNueva frm = new frmCitaNueva(dgvCitas);
            frm.Show();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            objCitaController.cargarCita(dgvCitas);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool delet;
            delet = objCitaController.eliminarCita(idCita, dgvCitas);
            if(delet)
            {
                txtBuscar.Text = "";
                idCita = 0;
            }
        }

        private void dgvCitas_Click(object sender, EventArgs e)
        {
            seleccionado = dgvCitas.SelectedRows.Count;
            if(dgvCitas.CurrentRow == null)
            {
                dgvCitas.ClearSelection();
            }
            else
            {
                idCita = Convert.ToInt32(dgvCitas.CurrentRow.Cells["Column3"].Value.ToString());
                txtBuscar.Text = dgvCitas.CurrentRow.Cells["Column1"].Value.ToString();
            }
        }

        private void btnConsultaCita_Click(object sender, EventArgs e)
        {
            frmConsultaNueva frmConsulta = new frmConsultaNueva();
            frmConsulta.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtBuscar.Text;
            objCitaController.buscarcita(nombreCliente, dgvCitas);
            dgvCitas.ClearSelection();
            idCita = 0;
        }
    }
}
