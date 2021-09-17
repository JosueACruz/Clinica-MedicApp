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
        ModelLaboratorioMedicamento objLaboratorio = new ModelLaboratorioMedicamento();
        ModelCategoriaMedicamento objCategoria = new ModelCategoriaMedicamento();
        ModelPresentacionMedicamento objPresentacion = new ModelPresentacionMedicamento();

        public void cargarMedicamento(DataGridView dgv)
        {
            SqlDataReader sdr = objMedicamento.cargarMedicamentos();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idMedicamento = int.Parse(sdr[0].ToString());
                    string Medicamento = sdr[1].ToString();
                    int idLaboratorio = int.Parse(sdr[2].ToString());
                    string Laboratorio = sdr[3].ToString();
                    int idPresentacion = int.Parse(sdr[4].ToString());
                    string Presentacion = sdr[5].ToString();
                    int idCategoria = int.Parse(sdr[6].ToString());
                    string Categoria = sdr[7].ToString();
                    dgv.Rows.Add(new object[] { idMedicamento, Medicamento, idLaboratorio, Laboratorio, idPresentacion, Presentacion, idCategoria, Categoria });
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
                    int idLaboratorio = int.Parse(sdr[2].ToString());
                    string Laboratorio = sdr[3].ToString();
                    int idPresentacion = int.Parse(sdr[4].ToString());
                    string Presentacion = sdr[5].ToString();
                    int idCategoria = int.Parse(sdr[6].ToString());
                    string Categoria = sdr[7].ToString();
                    dgv.Rows.Add(new object[] { idMedicamento, Medicamento, idLaboratorio, Laboratorio, idPresentacion, Presentacion, idCategoria, Categoria });
                }
            }
        }

        //llenar combobox laboratorio
        /// <summary>
        /// Para llenar el combobox, hacemos un Tuple, es una estructura de datos que nos permite almacenar hasta 8 valores diferentes
        /// con esto nos aseguramos de crear la lista en la cual se guardaran los datos de la BD
        /// luego de recorrer el DataReader insertamos la lista en el combobox
        /// </summary>
        /// <param name="cmblaboratorio"></param>
        public void llenarLaboratorio(ComboBox cmblaboratorio)
        {            
            SqlDataReader sdr = objLaboratorio.cargarLaboratorioMedicamento();
           
            if (sdr.HasRows)
            {
                //List<object> lista = new List<object>();
                List<Tuple<Int32, String>> lista = new List<Tuple<int, string>>();
                while (sdr.Read())
                {
                    int idLaboratorio = int.Parse(sdr[0].ToString());
                    string Laboratorio = sdr[1].ToString();
                    lista.Add(Tuple.Create<Int32, String>(sdr.GetInt32(0), Laboratorio));
                }
                cmblaboratorio.DataSource = lista;
                cmblaboratorio.DisplayMember = "Item2";
                cmblaboratorio.ValueMember = "Item1";
                
            }
        }

        //llamar presentaciones para combobox
        public void llenarPresentacion(ComboBox cmbpresentacion)
        {
            SqlDataReader sdr = objPresentacion.cargarPresentacioniaMedicamento();

            if (sdr.HasRows)
            {
                //List<object> lista = new List<object>();
                List<Tuple<Int32, String>> lista = new List<Tuple<int, string>>();
                while (sdr.Read())
                {
                    string Presentacion = sdr[1].ToString();
                    lista.Add(Tuple.Create<Int32, String>(sdr.GetInt32(0), Presentacion));
                }
                cmbpresentacion.DataSource = lista;
                cmbpresentacion.DisplayMember = "Item2";
                cmbpresentacion.ValueMember = "Item1";

            }
        }

        //Llenar combobox de categoria
        public void llenarCategoria(ComboBox cmbCategoria)
        {
            SqlDataReader sdr = objCategoria.cargarCategoriaMedicamento();

            if (sdr.HasRows)
            {
                //List<object> lista = new List<object>();
                List<Tuple<Int32, String>> lista = new List<Tuple<int, string>>();
                while (sdr.Read())
                {
                    string Categoria = sdr[1].ToString();
                    lista.Add(Tuple.Create<Int32, String>(sdr.GetInt32(0), Categoria));
                }
                cmbCategoria.DataSource = lista;
                cmbCategoria.DisplayMember = "Item2";
                cmbCategoria.ValueMember = "Item1";

            }
        }
    }
}
