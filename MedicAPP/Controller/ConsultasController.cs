using MedicAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicAPP.Controller
{
    class ConsultasController
    {
        ModelConsultas objModelConsultas = new ModelConsultas();

        //Cargar no loagregare aun porque ese sera despues para el reporte o si se piensan ver las consultas
        ///POr el momento es suficiente con insertar, y buscar por id
        ///

        public bool ingresarConsulta(int paciente, int medico, DateTime fecha, string hora, int edad, double peso, double altura,
                                    int frecuenciaCardiaca, int frecuenciaRespiratoria, int tensionArterial, double temperatura,
                                    string motivo, string diagnostico, string AmPm)
        {
            if (paciente == 0 || medico == 0 || fecha < DateTime.Now || hora.Length == 0 || AmPm.Length == 0 || edad == 0 || peso == 0 || altura == 0 ||
                frecuenciaCardiaca == 0|| frecuenciaRespiratoria == 0 || tensionArterial == 0 || tensionArterial == 0 || temperatura == 0 ||
                motivo.Length == 0 || diagnostico.Length == 0)
            {
                MessageBox.Show("Debe ingresar una categoria y su descripcion", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (objModelConsultas.validar(fecha, hora, AmPm, paciente))
                {
                    MessageBox.Show("Ya fue ingresada una consulta de este paciente a las " + hora +" "+ AmPm + " este mismo dia, Favor revisar los datos", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool ins;
                    ins = objModelConsultas.insertarConsulta(paciente, medico, fecha, hora, AmPm, edad, peso, altura, frecuenciaCardiaca,
                                                            frecuenciaRespiratoria, tensionArterial,temperatura, motivo,diagnostico);
                    if (ins)
                    {
                        MessageBox.Show("Se registró la consulta satisfactoriamente", "MedicAPP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
