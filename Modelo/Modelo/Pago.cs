using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using Modelo.Enumeracion;
using System;

namespace Modelo.Modelo
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Display(Name = "Medio de Pago")]
        public EnumMedioDePAgo MedioDePago { get; set; }        
        public virtual ObservableCollection<Archivo> Archivos { get; set; }
        [Display(Name = "Inmueble")]
        public int InmueblePagoID { get; set; }
        public virtual Inmueble InmueblePago { get; set; }        
        public virtual ObservableCollection<Usuario> ArrendatarioPago { get; set; }
    }
}