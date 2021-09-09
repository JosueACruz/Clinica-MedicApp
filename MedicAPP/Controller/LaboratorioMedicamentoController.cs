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
    class LaboratorioMedicamentoController
    {
        ModelLaboratorioMedicamento objlaboratorioModel = new ModelLaboratorioMedicamento();

        //Mostrar los laboratorios en el DataGrid
        public void cargarLabratorioMedic(DataGridView dgv)
        {
            SqlDataReader sdr = objlaboratorioModel.cargarLaboratorioMedicamento();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idLaboratorio = int.Parse(sdr[0].ToString());
                    string Nombre = sdr[1].ToString();
                    dgv.Rows.Add(new object[] { idLaboratorio, Nombre });
                }
            }
            //return dgv;
        }

        //Metodo para crear un nuevo laboratorio
        public bool ingresarLaboratorioMedic(string laboratorio, DataGridView dgv)
        {
            if (laboratorio.Length == 0)
            {
                MessageBox.Show("Debe ingresar un laboratorio", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objlaboratorioModel.validar(laboratorio))
                {
                    MessageBox.Show("Ya existe el laboratorio " + laboratorio+ ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objlaboratorioModel.insertarLaboratorioMedicamento(laboratorio);
                    if (ins)
                    {
                        MessageBox.Show("Se registró el laboratorio satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Rows.Clear();
                        cargarLabratorioMedic(dgv);
                        dgv.ClearSelection();
                        return true;
                    }
                }
            }
            return false;
        }

        //Metodo para Eliminar el laboratorio
        public bool eliminarLaboratorioMedic(int id, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun laboratorio", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar este laboratorio?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objlaboratorioModel.eliminarLaboratorioMedicamento(id);
                    dgv.Rows.Clear();
                    cargarLabratorioMedic(dgv);
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

        //Metodo para actualizar el laboratorio
        public bool actualizarLaboratorioMedic(int id, string laboratorio, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun laboratorio", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar este laboratorio?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objlaboratorioModel.actualizarLaboratorioMedicamento(id, laboratorio);
                    dgv.Rows.Clear();
                    cargarLabratorioMedic(dgv);
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

        //Busqueda de laboratorio
        public void buscarCategoriaMedic(string laboratorio, DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader sdr = objlaboratorioModel.buscarLabratorioMedicamento(laboratorio);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idLaboratorio = int.Parse(sdr[0].ToString());
                    string lab = sdr[1].ToString();
                    dgv.Rows.Add(new object[] { idLaboratorio, lab });
                }
            }
        }
    }
}
