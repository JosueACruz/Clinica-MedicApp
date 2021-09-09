using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicAPP.Model
{
    class ModelLaboratorioMedicamento
    {
        //Metodo para extraer la lista de laboratorios de la BD
        public SqlDataReader cargarLaboratorioMedicamento()
        {
            Conexion cnx = new Conexion();
            string Consulta = "select * from MedicamentoLaboratorio";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }

        //Insertar en la Base de datos el Laboratorio nuevo
        public bool insertarLaboratorioMedicamento(string laboratorio)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "Insert into MedicamentoLaboratorio values ('" + laboratorio + "')";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al guardar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validacion para saber si ya existe el laboratorio
        public bool validar(string laboratorio)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "select * from MedicamentoLaboratorio where Nombre = '" + laboratorio + "'";
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

        //Metodo para actualizar el nombre de alguno de los laboratorios
        public bool actualizarLaboratorioMedicamento(int id, string laboratorio)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "update MedicamentoLaboratorio set Nombre = '" + laboratorio + "' where idLaboratorio= " + id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al editar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Metodo para eliminar algun laboratorio de la base de datos
        public bool eliminarLaboratorioMedicamento(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "delete from MedicamentoLaboratorio where idLaboratorio = '" + id + "'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al eliminar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Metodo para buscar un laboratorio en especifico
        public SqlDataReader buscarLabratorioMedicamento(string laboratorio)
        {
            Conexion cnx = new Conexion();
            string consulta = "select idLaboratorio, Nombre from MedicamentoLaboratorio where Nombre like '" + laboratorio + "%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
