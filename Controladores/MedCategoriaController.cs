using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class MedCategoriaController
    {
        public IEnumerable<Modelo.MedCategoriaViewModel> GetList()
        {
            using(Modelo.EF.MedicAppEntities db = new Modelo.EF.MedicAppEntities())
            {
                IEnumerable<Modelo.MedCategoriaViewModel> lst = (from d in db.MedicamentoCategoria
                                                                 select new Modelo.MedCategoriaViewModel
                                                                 {
                                                                     Id = d.idCategoria,
                                                                     nombre = d.Nombre
                                                                 }).ToList();
                return lst;
            }
        }
    }
}
