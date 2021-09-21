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
    class ModelExamen
    {
        //select ex.idCategoria, ex.Nombre, ex.Descripcion, ec.Nombre as 'Categoria' from Examen ex INNER JOIN ExamenCategoria ec ON ex.idCategoria = ec.idCategoria
        //Metodo para extraer la lista de categoria de medicamentos desde la BD
        public SqlDataReader cargarExamen()
        {
            Conexion cnx = new Conexion();
            string Consulta = "select ex.idCategoria, ex.Nombre, ex.Descripcion, ec.Nombre as 'Categoria' from Examen ex INNER JOIN ExamenCategoria ec ON ex.idCategoria = ec.idCategoria";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }
        public bool insertarMedicamento(string examen, string descripcion, int categoria)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "insert into Examen values ('"+ examen +"', '"+descripcion+"', "+ categoria+")";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el medicamento" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool validar(string examen)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "select * from Examen where Nombre = '" + examen + "'";
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
                MessageBox.Show("Error al vaildar el examen: " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool actualiarMedicamento(int id, string examen, string descripcion, int categoria)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "update Examen set Nombre = '" + examen + "', Descripcion = '"+descripcion+"', idCategoria = '"+categoria+"' where idExamen = " + id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el examen " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarMedicamento(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "delete from Examen where idExamen= '" + id + "'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el examen " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public SqlDataReader buscarMedicamento(string examen)
        {
            Conexion cnx = new Conexion();
            string consulta = "select ex.idCategoria, ex.Nombre, ex.Descripcion, ec.Nombre as 'Categoria' from Examen ex INNER JOIN ExamenCategoria ec ON ex.idCategoria = ec.idCategoria where ex.Nombre like '" + examen + "%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
