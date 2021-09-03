using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicAPP.Model
{
    public class ModelCategoriaMedicamento
    {
        //Metodo para extraer la lista de categoria de medicamentos desde la BD
        public SqlDataReader cargarCategoriaMedicamento()
        {
            Conexion cnx = new Conexion();
            string Consulta = "select idCategoria, Nombre from MedicamentoCategoria";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }

        public bool insertarCategoriaMedicamento(string cate)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "Insert into MedicamentoCategoria values ('"+cate+"')";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validando para saber si ya existe la categoria a ingresar
        public bool validar(string cate)
        {
            try {
                Conexion cnx = new Conexion();
                string consulta = "select * from MedicamentoCategoria where Nombre = '"+ cate +"'";
                DataSet ds = cnx.Conx(consulta);
                if(ds.Tables[0].Rows.Count != 0)
                {
                    //ya existe
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al vaildar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool actualiarCategoriaMedicamento(int id, string categoria)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "update MedicamentoCategoria set Nombre = '"+categoria+"' where idCategoria = "+id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al editar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarCategoriaMedicamento(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "delete from MedicamentoCategoria where idCategoria = '" + id +"'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public SqlDataReader buscarCategoriaMedicamento(string cate)
        {
            Conexion cnx = new Conexion();
            string consulta = "select idCategoria, Nombre from MedicamentoCategoria where Nombre like '"+cate+"%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
