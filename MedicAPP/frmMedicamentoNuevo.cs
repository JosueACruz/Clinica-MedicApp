﻿using System;
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
    public partial class frmMedicamentoNuevo : Form
    {
        public frmMedicamentoNuevo()
        {
            InitializeComponent();
        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMedicamentoNuevo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(270, 60);
        }
    }
}
