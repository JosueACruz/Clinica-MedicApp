using MedicAPP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicAPP.Controller
{
    class CitaController
    {
        ModelCita objCita = new ModelCita();
        ModelPacientes objPaciente = new ModelPacientes();

        public void cargarCita(DataGridView dgv)
        {
            SqlDataReader sdr = objCita.cargarCita();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idCita = int.Parse(sdr[0].ToString());
                    int idPaciente = int.Parse(sdr[1].ToString());
                    string Paciente = sdr[2].ToString();
                    string Fecha = sdr[3].ToString();
                    string hora = sdr[4].ToString();
                    string AmPm = sdr[5].ToString();
                    dgv.Rows.Add(new object[] { idCita, idPaciente, Paciente, Fecha, hora + ' ' + AmPm });
                }
            }
            //return dgv;
        }

        //Metodo para crear una nueva categoria
        public bool ingresarCita(int paciente, DateTime fecha, string hora, string AmPm, DataGridView dgv)
        {
            if (paciente == 0 || hora.Length == 0 || AmPm.Length == 0)
            {
                MessageBox.Show("Debe agregar datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if( fecha <= DateTime.Now) 
            {
                MessageBox.Show("Por favor ingrese una fecha valida, mayor al dia de hoy", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objCita.validar(fecha, hora, AmPm))
                {
                    MessageBox.Show("Ya existe una cita agendada para la fecha: " + fecha + " y hora: " + hora + " "+ AmPm +", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objCita.insertarCita(paciente, fecha, hora, AmPm);
                    if (ins)
                    {
                        MessageBox.Show("Se registró la cita satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Rows.Clear();
                        cargarCita(dgv);
                        dgv.ClearSelection();
                        return true;
                    }
                }
            }
            return false;
        }

        //Metodo para Eliminar la categoria
        public bool eliminarCita(int id, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna cita", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar esta cita?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objCita.eliminarCita(id);
                    dgv.Rows.Clear();
                    cargarCita(dgv);
                    dgv.ClearSelection();
                    ret = true;
                }
                else if (resultado == DialogResult.No)
                {
                    MessageBox.Show("Se canceló la operación", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv.ClearSelection();
                    ret = false;
                }
            }
            return ret;
        }

        //Metodo para actualizar la categoria
        public bool actualizarCita(int id, int paciente, DateTime fecha, string hora, string AmPm, DataGridView dgv)
        {
            bool ret = false;
            if(id == 0)
            {
                MessageBox.Show("Debe seleccionar una cita", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else if (paciente == 0 || hora.Length == 0)
            {
                MessageBox.Show("Debe agregar datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else if (fecha <= DateTime.Now)
            {
                MessageBox.Show("Por favor ingrese una fecha valida, mayor al dia de hoy", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar esta cita?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (objCita.validar(fecha, hora, AmPm))
                    {
                        MessageBox.Show("Ya existe una cita para el dia: " + fecha+ " a las: "+ hora +" "+AmPm +", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        objCita.actualizarCita(id, paciente, fecha, hora, AmPm);
                        dgv.Rows.Clear();
                        cargarCita(dgv);
                        dgv.ClearSelection();
                        ret = true;
                    }
                }
                else if (resultado == DialogResult.No)
                {
                    MessageBox.Show("Se canceló la operación", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv.ClearSelection();
                    ret = false;
                }
            }
            return ret;
        }

        //Busqueda de Categoria
        public void buscarcita(string paciente, DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader sdr = objCita.buscarCita(paciente);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idCita = int.Parse(sdr[0].ToString());
                    int idPaciente = int.Parse(sdr[1].ToString());
                    string Paciente = sdr[2].ToString();
                    string Fecha = sdr[3].ToString();
                    string hora = sdr[4].ToString();
                    string AmPm = sdr[5].ToString();
                    dgv.Rows.Add(new object[] { idCita, idPaciente, Paciente, Fecha, hora + ' ' + AmPm });
                }
            }
        }

        public void cargarPacientes(ComboBox cmbpacientes)
        {
            SqlDataReader sdr = objPaciente.cargarPaciente();
            if (sdr.HasRows)
            {
                List<Tuple<Int32, String>> lista = new List<Tuple<int, string>>();
                while (sdr.Read())
                {
                    int idPaciente = int.Parse(sdr[0].ToString());
                    string Nombre = sdr[1].ToString();
                    string Apellido = sdr[2].ToString();
                    string fecha = sdr[3].ToString();
                    string celular = sdr[4].ToString();
                    string direccion = sdr[5].ToString();
                    string Dui = sdr[6].ToString();
                    string responsable = sdr[7].ToString();
                    string parentesco = sdr[8].ToString();
                    lista.Add(Tuple.Create<Int32, String>(sdr.GetInt32(0), Nombre + " " + Apellido));
                }
                cmbpacientes.DataSource = lista;
                cmbpacientes.DisplayMember = "Item2";
                cmbpacientes.ValueMember = "Item1";
            }
        }
    }
}
