using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicAPP.Model
{
    class ModelPacientes
    {
        public SqlDataReader cargarPaciente()
        {
            Conexion cnx = new Conexion();
            string Consulta = "SELECT * FROM Paciente";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }

        public bool insertaPaciente(string Nombre, string Apellido, DateTime fecha, string cel, string direccion, string DUI, string responsable, string parentesco)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "INSERT INTO Paciente values  ('" + Nombre + "', '"+ Apellido+"', "+ fecha +", '"+cel+"', '"+direccion+"', '"+DUI+"', '"+responsable+"', '"+parentesco+"')";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el paciente " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validando para saber si ya existe la categoria a ingresar
        public bool validar(string DUI)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "SELECT * FROM Paciente where DUI = '" + DUI + "'";
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
                MessageBox.Show("Error al vaildar el paciente " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool actualizarPaciente(int id, string Nombre, string Apellido, DateTime fecha, string cel, string direccion, string DUI, string responsable, string parentesco)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "UPDATE Paciente set Nombre = '"+ Nombre + "', Apellido = '"+Apellido+ "', FechaNacimiento = "+fecha+ ", Celular = '"+cel+ "', Direccion = '"+direccion+ "', DUI = '"+DUI+ "', Responsable = '"+responsable+ "', Parentesco = '"+parentesco+"' WHERE idPaciente = " + id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el paciente " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarPaciente(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "DELETE FROM	Paciente WHERE idPaciente = '" + id + "'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el paciente " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public SqlDataReader buscarPaciente(string paciente)
        {
            Conexion cnx = new Conexion();
            string consulta = "SELECT * FROM Paciente WHERE Nombre like '" + paciente + "%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
