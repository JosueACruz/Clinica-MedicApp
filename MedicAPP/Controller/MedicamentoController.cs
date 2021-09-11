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
    class MedicamentoController
    {

        ModelMedicamento objMedicamento = new ModelMedicamento();

        public void cargarMedicamento(DataGridView dgv)
        {
            SqlDataReader sdr = objMedicamento.cargarMedicamentos();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idMedicamento = int.Parse(sdr[0].ToString());
                    string Medicamento = sdr[1].ToString();
                    string Laboratorio = sdr[2].ToString();
                    string Presentacion = sdr[3].ToString();
                    string Categoria = sdr[4].ToString();
                    dgv.Rows.Add(new object[] { idMedicamento, Medicamento, Laboratorio, Presentacion, Categoria });
                }
            }
        }

        //Metodo para crear un nuevo medicamento
        public bool ingresarMedicamento(string medicamento, int laboratorio, int presentacion, int categoria, DataGridView dgv)
        {
            if (medicamento.Length == 0)
            {
                MessageBox.Show("Debe ingresar un Medicamento", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objMedicamento.validar(medicamento))
                {
                    MessageBox.Show("Ya existe el medicamento " + medicamento + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objMedicamento.insertarMedicamento(medicamento, laboratorio, presentacion, categoria);
                    if (ins)
                    {
                        MessageBox.Show("Se registró el medicamento satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Rows.Clear();
                        cargarMedicamento(dgv);
                        dgv.ClearSelection();
                        return true;
                    }
                }
            }
            return false;
        }

        //Metodo para Eliminar el medicamento
        public bool eliminarMedicamento(int id, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun medicamento", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar este medicamento?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objMedicamento.eliminarMedicamento(id);
                    dgv.Rows.Clear();
                    cargarMedicamento(dgv);
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

        //Metodo para actualizar el medicamento
        public bool actualizarMedicamento(int id, string medicamento, int laboratorio, int presentacion, int categoria, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun medicamento", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar este medicamento?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (objMedicamento.validar(medicamento))
                    {
                        MessageBox.Show("Ya existe el medicamento " + medicamento + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        objMedicamento.actualizarMedicamento(id, medicamento, laboratorio, presentacion, categoria);
                        dgv.Rows.Clear();
                        cargarMedicamento(dgv);
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

        //Busqueda de medicamento
        public void buscarMedicamento(string medicamento, DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader sdr = objMedicamento.buscarMedicamento(medicamento);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idMedicamento = int.Parse(sdr[0].ToString());
                    string Medicamento = sdr[1].ToString();
                    string Laboratorio = sdr[2].ToString();
                    string Presentacion = sdr[3].ToString();
                    string Categoria = sdr[4].ToString();
                    dgv.Rows.Add(new object[] { idMedicamento, Medicamento, Laboratorio, Presentacion, Categoria });
                }
            }
        }
    }
}
