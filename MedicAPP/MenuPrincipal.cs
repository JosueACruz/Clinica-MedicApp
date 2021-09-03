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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            PantallaOK();
        }

        ///Abrir solo un ormulario a la vez
        ///
        private Form formActivado = null;
        private void AbrirFormularioEnWrapper(Form FormHijo)
        {
            if (formActivado != null)
                formActivado.Close();
            formActivado = FormHijo;
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;
            wrapper.Controls.Add(FormHijo);
            wrapper.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
        }

        //Para que no abarque la barra de tareas
        public void PantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        ///--------------------- Dando el aspecto de letras verdes al pasar el mouse por los botones.
        private void cambiarColor(Button btn)
        {
            btn.ForeColor = Color.FromArgb(98, 195, 140);
        }
        private void quitarColor(Button btn)
        {
            btn.ForeColor = Color.White;
        }
        private void seguirBoton(Button sender)
        {
            flecha.Top = sender.Top;
        }
        private void btnCitas_MouseHover(object sender, EventArgs e)
        {
            cambiarColor(btnCitas);
        }

        private void btnCitas_MouseLeave(object sender, EventArgs e)
        {
            quitarColor(btnCitas);
        }

        private void btnPacientes_MouseHover(object sender, EventArgs e)
        {
            cambiarColor(btnPacientes);
        }

        private void btnPacientes_MouseLeave(object sender, EventArgs e)
        {
            quitarColor(btnPacientes);
        }

        private void btnConsultas_MouseHover(object sender, EventArgs e)
        {
            cambiarColor(btnConsultas);
        }

        private void btnConsultas_MouseLeave(object sender, EventArgs e)
        {
            quitarColor(btnConsultas);
        }

        private void btnMedicamentos_MouseHover(object sender, EventArgs e)
        {
            cambiarColor(btnMedicamentos);
        }

        private void btnMedicamentos_MouseLeave(object sender, EventArgs e)
        {
            quitarColor(btnMedicamentos);
        }

        private void btnExamenes_MouseHover(object sender, EventArgs e)
        {
            cambiarColor(btnExamenes);
        }

        private void btnExamenes_MouseLeave(object sender, EventArgs e)
        {
            quitarColor(btnExamenes);
        }

        private void btnCerrarSesion_MouseHover(object sender, EventArgs e)
        {
            cambiarColor(btnCerrarSesion);
        }

        private void btnCerrarSesion_MouseLeave(object sender, EventArgs e)
        {
            quitarColor(btnCerrarSesion);
        }

        private void btnExamenes_Click(object sender, EventArgs e)
        {
            seguirBoton(btnExamenes);
            AbrirFormularioEnWrapper(new frmExamenes());
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            seguirBoton(btnPacientes);
            AbrirFormularioEnWrapper(new frmPacientes());
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            seguirBoton(btnConsultas);
            AbrirFormularioEnWrapper(new frmConsultas());
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            seguirBoton(btnMedicamentos);
            AbrirFormularioEnWrapper(new frmMedicamentos());
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            seguirBoton(btnCitas);
            AbrirFormularioEnWrapper(new frmCitas());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            seguirBoton(btnCerrarSesion);
        }
    }
}
