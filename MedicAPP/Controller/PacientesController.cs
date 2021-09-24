using MedicAPP.Model;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicAPP.Controller
{
    class PacientesController
    {
        ModelPacientes objPaciente = new ModelPacientes();
        public void cargarPaciente(DataGridView dgv)
        {
            SqlDataReader sdr = objPaciente.cargarPaciente();
            if (sdr.HasRows)
            {
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
                    dgv.Rows.Add(new object[] { idPaciente, Nombre, Apellido, fecha, celular, direccion, Dui, responsable, parentesco });
                }
            }
            //return dgv;
        }

        //Metodo para crear una nueva categoria
        public bool ingresarPaciente(string Nombre, string Apellido, DateTime fecha, string cel, string direccion, string DUI, string responsable, string parentesco, DataGridView dgv)
        {
            if (DUI.Length == 0 || Nombre.Length == 0 || Apellido.Length == 0 || cel.Length == 0 || direccion.Length == 0 || responsable.Length == 0 || parentesco.Length == 0)
            {
                MessageBox.Show("Debe ingresar un paciente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objPaciente.validar(DUI))
                {
                    MessageBox.Show("Ya existe el paciente con DUI: " + DUI + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objPaciente.insertaPaciente(Nombre, Apellido, fecha, cel, direccion, DUI, responsable, parentesco);
                    if (ins)
                    {
                        MessageBox.Show("Se registró el paciente satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Rows.Clear();
                        cargarPaciente(dgv);
                        dgv.ClearSelection();
                        return true;
                    }
                }
            }
            return false;
        }

        //Metodo para Eliminar la categoria
        public bool eliminarPaciente(int id, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun paciente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar este paciente?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objPaciente.eliminarPaciente(id);
                    dgv.Rows.Clear();
                    cargarPaciente(dgv);
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
        public bool actualizarPaciente(int id, string Nombre, string Apellido, DateTime fecha, string cel, string direccion, string DUI, string responsable, string parentesco, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun paciente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar este paciente?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objPaciente.actualizarPaciente(id, Nombre, Apellido, fecha, cel,direccion, DUI, responsable, parentesco);
                    dgv.Rows.Clear();
                    cargarPaciente(dgv);
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

        //Busqueda de Categoria
        public void buscarPaciente(string nombre, DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader sdr = objPaciente.buscarPaciente(nombre);
            if (sdr.HasRows)
            {
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
                    dgv.Rows.Add(new object[] { idPaciente, Nombre, Apellido, fecha, celular, direccion, Dui, responsable, parentesco });
                }
            }
        }

    }
}
