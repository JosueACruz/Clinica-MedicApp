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
    class ModelCita
    {
        public SqlDataReader cargarCita()
        {
            Conexion cnx = new Conexion();
            string Consulta = "SELECT ci.idCita, ci.idPaciente, (pa. Nombre + ' '+ pa.Apellido) as 'Paciente', ci.Fecha, ci.Hora FROM Cita ci INNER JOIN Paciente pa ON ci.idPaciente = pa.idPaciente;";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }

        public bool insertarCita(int paciente, DateTime fecha, string hora)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "INSERT INTO Cita values ("+paciente+", '"+fecha+"', '"+hora+"')";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la cita" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validando para saber si ya existe la categoria a ingresar
        public bool validar(DateTime fecha, string hora)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "SELECT * FROM Cita where fecha = '"+fecha+"' and Hora = '"+hora+"'";
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
                MessageBox.Show("Error al vaildar la cita " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool actualizarCita(int id, int paciente, DateTime fecha, string hora)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "update Cita set idPaciente = "+ paciente +", Fecha = '"+ fecha +"', Hora = '"+ hora +"' WHERE idCita =  " + id;
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la cita" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarCita(int id)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "delete from cita where idCategoria = '" + id + "'";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la cita" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public SqlDataReader buscarCita(string paciente)
        {
            Conexion cnx = new Conexion();
            string consulta = "SELECT ci.idCita, ci.idPaciente, (pa. Nombre + ' '+ pa.Apellido) as 'Paciente', ci.Fecha, ci.Hora FROM Cita ci INNER JOIN Paciente pa ON ci.idPaciente = pa.idPaciente where pa.Nombre lIKE '"+ paciente +"%' OR pa.Apellido like '"+paciente+"%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
