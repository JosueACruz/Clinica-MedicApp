using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicAPP.Model
{
    public class ModelPresentacionMedicamento
    {
        //Metodo para extraer la lista de Presentaciones de medicamentos desde la BD
        public SqlDataReader cargarPresentacioniaMedicamento()
        {
            Conexion cnx = new Conexion();
            string Consulta = "select * from MedicamentoPresentacion";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }

        public bool insertarPresentacionMedicamento(string presentacion)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "insert into MedicamentoPresentacion values ('"+presentacion+"')";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al guardar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validando para saber si ya existe la categoria a ingresar
        public bool validar(string presentacion)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "select * from MedicamentoPresentacion where Nombre = '"+presentacion+"'";
                DataSet ds = cnx.Conx(consulta);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    //ya existe
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al vaildar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool actualiarPresentacioMedicamento(int id, string presentacion)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "Update MedicamentoPresentacion set Nombre = '"+presentacion+"' where idPresentacion ="+ id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al editar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarPresentacioMedicamento(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "delete from MedicamentoPresentacion where idPresentacion='" + id + "'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al eliminar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public SqlDataReader buscarPresentacioMedicamento(string presentacion)
        {
            Conexion cnx = new Conexion();
            string consulta = "select idPresentacion, Nombre from MedicamentoPresentacion where Nombre like '" + presentacion + "%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
