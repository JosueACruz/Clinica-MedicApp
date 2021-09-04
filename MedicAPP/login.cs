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
            ingre = objlogincontroller.BuscarUsuar(username, pass);
            if(ingre)
            {
                this.Hide();
                MenuPrincipal frm = new MenuPrincipal();
                frm.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
