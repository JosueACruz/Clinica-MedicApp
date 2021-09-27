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
                    dgv.Rows.Add(new object[] { idCita, idPaciente, Paciente, Fecha, hora });
                }
            }
            //return dgv;
        }

        //Metodo para crear una nueva categoria
        public bool ingresarCita(int paciente, DateTime fecha, string hora, DataGridView dgv)
        {
            if (paciente == 0 || hora.Length == 0)
            {
                MessageBox.Show("Debe agregar datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if( fecha > DateTime.Now) 
            {
                MessageBox.Show("Por favor ingrese una fecha valida, mayor al dia de hoy", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objCita.validar(fecha, hora))
                {
                    MessageBox.Show("Ya existe una cita agendada para la fecha: " + fecha + " y hora: " + hora +", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objCita.insertarCita(paciente, fecha, hora);
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
        public bool actualizarCita(int id, int paciente, DateTime fecha, string hora, DataGridView dgv)
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
            else if (fecha > DateTime.Now)
            {
                MessageBox.Show("Por favor ingrese una fecha valida, mayor al dia de hoy", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar esta cita?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (objCita.validar(fecha, hora))
                    {
                        MessageBox.Show("Ya existe una cita para el dia: " + fecha+ " a las: "+ hora +", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        objCita.actualizarCita(id, paciente, fecha, hora);
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
                    dgv.Rows.Add(new object[] { idCita, idPaciente, Paciente, Fecha, hora });
                }
            }
        }
    }
}
