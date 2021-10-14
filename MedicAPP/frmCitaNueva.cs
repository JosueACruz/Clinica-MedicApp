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
    public partial class frmCitaNueva : Form
    {
        CitaController objCitaController = new CitaController();

        DataGridView Dgv;
        public frmCitaNueva(DataGridView dgv)
        {
            InitializeComponent();
            this.Dgv = dgv;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCitaNueva_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);
            objCitaController.cargarPacientes(cmbPaciente);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtFecha.Value;
            string hora = cmbHora.Text;
            int paciente = (int)cmbPaciente.SelectedValue;
            string AmPm = (string)cmbAmPm.Text;
            bool ingre;
            ingre = objCitaController.ingresarCita(paciente, fecha, hora, AmPm, Dgv);
            if(ingre)
            {
                this.Close();
            }
        }
    }
}
