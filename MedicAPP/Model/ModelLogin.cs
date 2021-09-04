using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicAPP.Model
{
    public class ModelLogin
    {
        public SqlDataReader buscarUsuario(string username, string pass)
        {
            Conexion cnx = new Conexion();
            string consulta = "select Top 1 * from Medico where Username ='"+username+"' and Clave = '"+pass+"';";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
