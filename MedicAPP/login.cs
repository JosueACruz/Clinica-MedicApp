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
    public partial class Form1 : Form
    {
        loginController objlogincontroller = new loginController();
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pass = txtPass.Text;
            bool ingre;
            if (username == "" || pass == "")
            {
                MessageBox.Show("Por favor ingrese sus datos de inicio de sesion", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ingre = objlogincontroller.BuscarUsuar(username, pass);
                if (ingre)
                {
                    this.Hide();
                    MenuPrincipal frm = new MenuPrincipal();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Su usuario o contraseña no es valido", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Text = "";
                    txtPass.Text = "";
                    txtUsername.Focus();
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
