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
    class ExamenController
    {
        ModelExamen objExamen = new ModelExamen();
        ModelExamenCategoria objCategoria = new ModelExamenCategoria();

        public void cargarExamen(DataGridView dgv)
        {
            SqlDataReader sdr = objExamen.cargarExamen();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idExamen = int.Parse(sdr[0].ToString());
                    string Examen = sdr[1].ToString();
                    string Descripcion = sdr[2].ToString();
                    int idCategoria = int.Parse(sdr[3].ToString());
                    string Categoria = sdr[4].ToString();
                    dgv.Rows.Add(new object[] { idExamen, Examen, Descripcion, idCategoria, Categoria });
                }
            }
        }

        public bool ingresarExamen(string examen, string Descripcion, int categoria, DataGridView dgv)
        {
            if (examen.Length == 0 || Descripcion.Length == 0 || string.IsNullOrEmpty(categoria.ToString()))
            {
                MessageBox.Show("Debe ingresar un Examen", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objExamen.validar(examen))
                {
                    MessageBox.Show("Ya existe el examen: " + examen + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objExamen.insertarExamen(examen, Descripcion, categoria);
                    if (ins)
                    {
                        MessageBox.Show("Se registró el examen satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Rows.Clear();
                        cargarExamen(dgv);
                        dgv.ClearSelection();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool eliminarExamen(int id, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun examen", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar este examen?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objExamen.eliminarexamen(id);
                    dgv.Rows.Clear();
                    cargarExamen(dgv);
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

        public bool actualizarExamen(int id, string examen, string Descripcion, int categoria, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ningun examen", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar este examen?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (objExamen.validar(examen))
                    {
                        MessageBox.Show("Ya existe el examen: " + examen + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        objExamen.actualiarExamen(id, examen, Descripcion, categoria);
                        dgv.Rows.Clear();
                        cargarExamen(dgv);
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

        public void buscarExamen(string examen, DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader sdr = objExamen.buscarExamen(examen);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idExamen = int.Parse(sdr[0].ToString());
                    string Examen = sdr[1].ToString();
                    string Descripcion = sdr[2].ToString();
                    int idCategoria = int.Parse(sdr[3].ToString());
                    string Categoria = sdr[4].ToString();
                    dgv.Rows.Add(new object[] { idExamen, Examen, Descripcion, idCategoria, Categoria });
                }
            }
        }

        public void llenarCategoria(ComboBox cmbCategoria)
        {
            SqlDataReader sdr = objCategoria.cargarCategoriaExamen();

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
