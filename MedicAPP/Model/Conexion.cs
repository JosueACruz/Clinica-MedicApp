using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicAPP.Model
{
    public class Conexion
    {
        public static string cadenaConexion = MedicAPP.Properties.Settings.Default.cnx;
        SqlConnection cnxCon = new SqlConnection(cadenaConexion);

        //Metodo para conectar a la base de datos

        public SqlConnection Conectar()
        {
            cnxCon.Open();
            Console.WriteLine("Conectado");
            return cnxCon;
        }

        //Metodo para desconectar la Base de Datos
        public void desconectar()
        {
            if(cnxCon.State == System.Data.ConnectionState.Open)
            {
                cnxCon.Close();
                Console.WriteLine("Desconectado");
            }
        }

        //Con este metodo retornamos un Datatable con solo recibir la consulta en String
        public DataTable consultaPorDataTable(string consulta)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sql = new SqlCommand(consulta, this.Conectar());
                SqlDataAdapter odt = new SqlDataAdapter(sql);
                odt.Fill(dt);
                this.desconectar();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error en consulta" + ex.Message);
                return null;
            }
            return dt;
        }
        
        //Metodo para conectar a la BD, recibe un "String de Consulta" y develve un Dataset lleno
        //de datos de la conslta
        public DataSet Conx(string consulta)
        {
            SqlConnection conx = new SqlConnection(cadenaConexion);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(consulta, conx);
            DataSet ds = new DataSet();

            da.SelectCommand = cmd;
            da.Fill(ds);
            conx.Close();
            conx.Dispose();
            return ds;
        }
    }
}
