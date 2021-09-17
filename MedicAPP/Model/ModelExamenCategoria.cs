using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicAPP.Model
{
    class ModelExamenCategoria
    {
        //Metodo para extraer la lista de medicamentos desde la BD
        public SqlDataReader cargarCategoriaExamen()
        {
            Conexion cnx = new Conexion();
            string Consulta = "Select * from ExamenCategoria;";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }


        public bool insertarCategoriaExamen(string Categoria, string Descripcion)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "INSERT INTO ExamenCategoria values ('" + Categoria + "'," + Descripcion + ")";
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
        public bool validar(string categoria)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "Select * from ExamenCategoria where Nombre = '" + categoria + "'";
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
                // MessageBox.Show("Error al vaildar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool actualizarCategoriaExamen(int id, string categoria, string descripcion)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "update ExamenCategoria set Nombre = '" + categoria+ "', idCategoria= " + descripcion + " where idCategoria = " + id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al editar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarCategoriaExamen(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "DELETE FROM ExamenCategoria WHERE idCategoria = '" + id + "'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al eliminar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public SqlDataReader buscarMedicamento(string categoria)
        {
            Conexion cnx = new Conexion();
            string consulta = "Select * from ExamenCategoria WHERE Nombre like '" + categoria + "%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
