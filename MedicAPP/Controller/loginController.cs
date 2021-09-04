using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicAPP.Model;

namespace MedicAPP.Controller
{
    public class loginController
    {
        ModelLogin objModelLogin = new ModelLogin();
        public bool BuscarUsuar(string username, string pass)
        {
            bool ret = false;
            SqlDataReader sdr = objModelLogin.buscarUsuario(username, pass);
            if(sdr.HasRows)
            {
                ret = true;
            }
            return ret;
        }
    }
}
