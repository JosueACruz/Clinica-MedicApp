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
    class PresentacionMedicamentoController
    {
        ModelPresentacionMedicamento objpresentacionMedicamento = new ModelPresentacionMedicamento();

        //Funcion para cargar las presentaciones en el datagrid
        public void cargarPresentacion(DataGridView dgv)
        {
            SqlDataReader sdr = objpresentacionMedicamento.cargarPresentacioniaMedicamento();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idPresentacion = int.Parse(sdr[0].ToString());
                    string Nombre = sdr[1].ToString();
                    dgv.Rows.Add(new object[] { idPresentacion, Nombre });
                }
            }
        }

        //Metodo para crear una nueva presentacion de medicamentos
        public bool ingresarPresentacionMedicamento(string presentacion, DataGridView dgv)
        {
            //si viene vacia (creo que debe ir en la vista esta validacion)
            if (presentacion.Length == 0)
            {
                MessageBox.Show("Debe ingresar una presentacion", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Si la presentacion ya existe
                if (objpresentacionMedicamento.validar(presentacion))
                {
                    MessageBox.Show("Ya existe la presentacion " + presentacion+ ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //si no existe ingresamos la presentacion
                {
                    bool ins;
                    ins = objpresentacionMedicamento.insertarPresentacionMedicamento(presentacion);
                    if (ins)
                    {
                        MessageBox.Show("Se registró la presentacion satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Rows.Clear();
                        cargarPresentacion(dgv); //llamamos al metodo cargar presentaciones para que se cargue de nuevo la tabla
                        dgv.ClearSelection();
                        return true;
                    }
                }
            }
            return false;
        }

        //Metodo para eliminar las presentaciones
        public bool eliminarPresentacionMedicamento(int id, DataGridView dgv)
        {
            bool ret = false;
            //Pasams el id para saber si ha seleccionado alguna presentacion
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna presentacion", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar la presentacion?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objpresentacionMedicamento.eliminarPresentacioMedicamento(id);
                    dgv.Rows.Clear();
                    cargarPresentacion(dgv);
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

        //Metodo para actualizar las presentaciones
        public bool actualizarPresentacionMedicamento(int id, string presentacion, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna presentacion", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar la presentacion: "+presentacion +"?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (objpresentacionMedicamento.validar(presentacion))
                    {
                        MessageBox.Show("Ya existe la presentacion " + presentacion + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        objpresentacionMedicamento.actualiarPresentacioMedicamento(id, presentacion);
                        dgv.Rows.Clear();
                        cargarPresentacion(dgv);
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

        //Busqueda de presentacion
        public void buscarPresentacionMedicamento(string presentacion, DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader sdr = objpresentacionMedicamento.buscarPresentacioMedicamento(presentacion);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idPres = int.Parse(sdr[0].ToString());
                    string present = sdr[1].ToString();
                    dgv.Rows.Add(new object[] { idPres, present});
                }
            }
        }
    }
}
