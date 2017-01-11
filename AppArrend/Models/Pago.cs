using AppArrend.Enumeracion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models
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
        public virtual ObservableCollection<Arrendatario> ArrendatarioPago { get; set; }
    }
}