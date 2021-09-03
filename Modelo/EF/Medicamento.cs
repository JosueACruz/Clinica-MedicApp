//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicamento()
        {
            this.Receta = new HashSet<Receta>();
        }
    
        public int idMedicamento { get; set; }
        public string Nombre { get; set; }
        public int idLaboratorio { get; set; }
        public int idPresentacion { get; set; }
        public int idCategoria { get; set; }
    
        public virtual MedicamentoCategoria MedicamentoCategoria { get; set; }
        public virtual MedicamentoLaboratorio MedicamentoLaboratorio { get; set; }
        public virtual MedicamentoPresentacion MedicamentoPresentacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
