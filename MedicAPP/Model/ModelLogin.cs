using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicAPP.Model
{
    public class ModelLogin
    {
        Conexion cn = new Conexion();
        public DataSet buscarUsuario(string username, string pass)
        {

            string consulta = "SELECT TOP 1 * FROM Usuario where ";
            DataSet ds = new DataSet(consulta);
            ds = cn.Conx(consulta);
            return ds;
        }
    }
}
