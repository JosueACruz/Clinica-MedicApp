﻿using System;
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
            if (sdr.HasRows)
            {
                //Guardar los datos del usuario en sesion
                sesion.idMedico = int.Parse(sdr[0].ToString());


                //existe el usuario
                ret = true;
            }
            else
            {
                //No existe el usuario
                ret = false;
            }
            return ret;
        }
    }
}
