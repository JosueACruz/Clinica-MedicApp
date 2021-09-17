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
    class ModelMedicamento
    {
        //Metodo para extraer la lista de medicamentos desde la BD
        public SqlDataReader cargarMedicamentos()
        {
            Conexion cnx = new Conexion();
            string Consulta = "SELECT idMedicamento, med.Nombre, lab.idLaboratorio, lab.Nombre as 'Laboratorio', pres.idPresentacion, pres.Nombre as 'Presentacion', cat.idCategoria, cat.Nombre as 'Categoria' FROM Medicamento med inner join MedicamentoLaboratorio lab ON med.idLaboratorio =lab.idLaboratorio INNER JOIN MedicamentoPresentacion pres ON med.idPresentacion = pres.idPresentacion INNER JOIN MedicamentoCategoria cat ON med.idCategoria = cat.idCategoria;";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }

        public bool insertarMedicamento(string medic, int idLab, int idPresentacion, int idCategoria)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "INSERT INTO Medicamento values ('" + medic +"',"+ idLab +","+ idPresentacion + "," + idCategoria +")";
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
        public bool validar(string medic)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "select * from Medicamento where Nombre = '" + medic + "'";
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

        public bool actualizarMedicamento(int id, string medicamento, int idLab, int idPresentacion, int idCategoria)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "update Medicamento set Nombre = '"+medicamento+"', idLaboratorio = "+idLab+", idPresentacion = "+idPresentacion+", idCategoria = "+idCategoria+" where idMedicamento = " + id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al editar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarMedicamento(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "DELETE FROM Medicamento WHERE idMedicamento = '" + id + "'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al eliminar la categoria" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public SqlDataReader buscarMedicamento(string medicamento)
        {
            Conexion cnx = new Conexion();
            string consulta = "SELECT idMedicamento, med.Nombre, lab.idLaboratorio, lab.Nombre as 'Laboratorio', pres.idPresentacion, pres.Nombre as 'Presentacion', cat.idCategoria, cat.Nombre as 'Categoria' FROM Medicamento med inner join MedicamentoLaboratorio lab ON med.idLaboratorio =lab.idLaboratorio INNER JOIN MedicamentoPresentacion pres ON med.idPresentacion = pres.idPresentacion INNER JOIN MedicamentoCategoria cat ON med.idCategoria = cat.idCategoria WHERE med.Nombre like '" + medicamento + "%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
