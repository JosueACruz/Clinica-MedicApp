using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicAPP.Model;

namespace MedicAPP.Controller
{
    public class loginController
    {
        ModelLogin objModelLogin = new ModelLogin();
        public void buscarUsuar(string username, string pass)
        {
            DataSet ds = objModelLogin.buscarUsuario(username, pass);
            if(ds.Tables[0].Rows.Count != 0)
            {
                ///Pasamos los datos a sesion
                ///
                //string username = Convert.ToString(ds.Tables[1])


            }
        }
    }
}
