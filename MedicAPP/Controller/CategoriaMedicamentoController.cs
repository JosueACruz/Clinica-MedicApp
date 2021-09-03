using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using MedicAPP.Model;

namespace MedicAPP.Controller
{
    public class CategoriaMedicamentoController
    {
        ModelCategoriaMedicamento objcategoriaModel = new ModelCategoriaMedicamento();

        //Metodo para mostrar las categorias al abrir el formulario
        /// <summary>
        /// Decimos que los datos que tiene el modelo en la funcion cargar categoriaMedicamento
        /// se guardan en un DataReader
        /// Luego verificamo si tiene datos, y si los tiene lo leera e ingresara los datos en el
        /// DataGridView que nos manda la vista.
        /// </summary>
        /// <param name="dgv"></param>
        public void cargarCategoriaMedic(DataGridView dgv)
        {
            SqlDataReader sdr = objcategoriaModel.cargarCategoriaMedicamento();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idCategoria = int.Parse(sdr[0].ToString());
                    string Nombre = sdr[1].ToString();
                    dgv.Rows.Add(new object[] { idCategoria, Nombre });
                }
            }
            //return dgv;
        }

        //Metodo para crear una nueva categoria
        public bool ingresarCategoriaMedic(string categoria, DataGridView dgv)
        {
            if(categoria.Length == 0)
            {
                MessageBox.Show("Debe ingresar una categoria","MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objcategoriaModel.validar(categoria))
                {
                    MessageBox.Show("Ya existe la categoria "+categoria +", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objcategoriaModel.insertarCategoriaMedicamento(categoria);
                    if(ins)
                    {
                        MessageBox.Show("Se registró la categoria satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Rows.Clear();
                        cargarCategoriaMedic(dgv);
                        dgv.ClearSelection();
                        return true;
                    }
                }
            }
            return false;
        }

        //Metodo para Eliminar la categoria
        public bool eliminarCategoriaMedic(int id, DataGridView dgv)
        {
            bool ret = false;
            if(id == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna categoria", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar esta categoria?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resultado == DialogResult.Yes)
                {
                    objcategoriaModel.eliminarCategoriaMedicamento(id);
                    dgv.Rows.Clear();
                    cargarCategoriaMedic(dgv);
                    dgv.ClearSelection();
                    ret = true;
                }
                else if(resultado == DialogResult.No)
                {
                    MessageBox.Show("Se canceló la operación", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv.ClearSelection();
                    ret = false;
                }
            }
            return ret;
        }


        //Metodo para actualizar la categoria
        public bool actualizarCategoriaMedic(int id, string categoria, DataGridView dgv)
        {
            bool ret = false;
            if(id == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna categoria", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar esta categoria?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(resultado == DialogResult.Yes) 
                {
                    objcategoriaModel.actualiarCategoriaMedicamento(id, categoria);
                    dgv.Rows.Clear();
                    cargarCategoriaMedic(dgv);
                    dgv.ClearSelection();
                    ret = true;
                }
                else if(resultado == DialogResult.No)
                {
                    MessageBox.Show("Se canceló la operación", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgv.ClearSelection();
                    ret = false;
                }
            }
            return ret;
        }

        //Busqueda de Categoria
        public void buscarCategoriaMedic(string categoria, DataGridView dgv)
        {
            dgv.Rows.Clear();
            SqlDataReader sdr = objcategoriaModel.buscarCategoriaMedicamento(categoria);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idCat = int.Parse(sdr[0].ToString());
                    string cate = sdr[1].ToString();
                    dgv.Rows.Add(new object[] { idCat, cate });
                }
            }
        }
    }
}