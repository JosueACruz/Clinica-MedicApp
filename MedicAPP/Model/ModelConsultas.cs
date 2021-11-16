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
    class ModelConsultas
    {

        //Este probablemente sirva para algun reporte o ver las consultas del dia
        //Ya que aun no tengo formulario para mostrarlo
        public SqlDataReader cargarConsulta()
        {
            Conexion cnx = new Conexion();
            string Consulta = "select co.idConsulta, (pa.Nombre + ' ' + pa.Apellido) as 'Paciente', (me.Nombre + ' ' + me.Apellido) as 'Medico', co.Fecha, co.Hora, co.Edad, co.Peso, co.Altura, co.FrecuenciaCardiaca, co.FrecuenciaRespiratoria, co.TensionArterial, co.Temperatura,co.Motivo, co.Diagnostico from Consulta co INNER JOIN Paciente pa ON co.idPaciente = pa.idPaciente INNER JOIN Medico me ON co.idMedico = ME.idMedico";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(Consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            return sdr;
        }

        //Este es el principal de estos metodos
        //paciente, medico, fecha, hora, edad, peso, altura, frecuencia cardiaca, Frecuencia respiratoria, Tension Arterial, tempetatura, 
        //motivo, diagnostico, AmPm
        public bool insertarConsulta(int paciente, int medico, DateTime fecha, string hora, string AmPm, int edad, double peso, double altura,
                                    int frecuenciaCardiaca, int frecuenciaRespiratoria, int tensionArterial,double temperatura,
                                    string motivo, string diagnostico)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "INSERT INTO Consulta VALUES ("+ paciente +", "+ medico +", '"+ fecha +"', '"+ hora +"', '"+ AmPm +"', "+edad+", "+peso+", "+altura+", "+frecuenciaCardiaca+", "+frecuenciaRespiratoria+", "+tensionArterial+", "+temperatura+", '"+motivo+"', '"+diagnostico+"')";
                DataSet ds = cnx.Conx(consulta);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la consulta" + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Validando para saber si ya existe la consulta a ingresar
        //Estara inactivo por el momento ya que no estoy seguro que se deba validar
        
        public bool validar(DateTime fecha, string hora, string AmPm, int idPaciente)
        {
            try
            {
                Conexion cnx = new Conexion();
                string consulta = "SELECT * FROM Consulta WHERE Fecha = '"+ fecha +"' AND Hora = '"+ hora +"' AND AmPm = '"+ AmPm + "' AND idPaciente = "+ idPaciente;
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
                MessageBox.Show("Error al vaildar la consulta " + ex.Message, "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        

        //Este probablemente sirva para algun reporte, o para mostrar el reporte al final de la consulta
        public SqlDataReader buscarCita(string paciente)
        {
            Conexion cnx = new Conexion();
            string consulta = "SELECT ci.idCita, ci.idPaciente, (pa. Nombre + ' '+ pa.Apellido) as 'Paciente', ci.Fecha, ci.Hora, ci.AmPm FROM Cita ci INNER JOIN Paciente pa ON ci.idPaciente = pa.idPaciente where pa.Nombre lIKE '" + paciente + "%' OR pa.Apellido like '" + paciente + "%'";
            SqlConnection con = cnx.Conectar();
            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
