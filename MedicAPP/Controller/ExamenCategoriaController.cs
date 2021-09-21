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
    class ExamenCategoriaController
    {
        ModelExamenCategoria objcategoriaModel = new ModelExamenCategoria();

        public void cargarCategoriaMedic(DataGridView dgv)
        {
            SqlDataReader sdr = objcategoriaModel.cargarCategoriaExamen();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    int idCategoria = int.Parse(sdr[0].ToString());
                    string Nombre = sdr[1].ToString();
                    string Descripcion = sdr[2].ToString();
                    dgv.Rows.Add(new object[] { idCategoria, Nombre, Descripcion });
                }
            }
            //return dgv;
        }

        //Metodo para crear una nueva categoria
        public bool ingresarCategoriaMedic(string categoria, string Descripcion, DataGridView dgv)
        {
            if (categoria.Length == 0 || Descripcion.Length == 0)
            {
                MessageBox.Show("Debe ingresar una categoria y su descripcion", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objcategoriaModel.validar(categoria))
                {
                    MessageBox.Show("Ya existe la categoria " + categoria + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objcategoriaModel.insertarCategoriaExamen(categoria, Descripcion);
                    if (ins)
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
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna categoria", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere eliminar esta categoria?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    objcategoriaModel.eliminarCategoriaExamen(id);
                    dgv.Rows.Clear();
                    cargarCategoriaMedic(dgv);
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
        public bool actualizarCategoriaMedic(int id, string categoria, string Descripcion, DataGridView dgv)
        {
            bool ret = false;
            if (id == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna categoria", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ret = false;
            }
            else if (categoria.Length == 0 || Descripcion.Length == 0) 
            {
                MessageBox.Show("Debe ingresar una categoria y su descripcion", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resultado = MessageBox.Show("¿Seguro que quiere editar esta categoria?", "MedicAPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //Debe validarse que se pueda ecribir de igual manera la misma categoria y solo editar la descripcion
                    if (objcategoriaModel.validar(categoria))
                    {
                        
                        MessageBox.Show("Ya existe la categoria " + categoria + ", Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        objcategoriaModel.actualizarCategoriaExamen(id, categoria, Descripcion);
                        dgv.Rows.Clear();
                        cargarCategoriaMedic(dgv);
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
                    string descripcion = sdr[2].ToString();
                    dgv.Rows.Add(new object[] { idCat, cate, descripcion });
                }
            }
        }
    }
}
