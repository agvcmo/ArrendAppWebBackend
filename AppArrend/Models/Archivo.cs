using AppArrend.Enumeracion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models
{
    public class Archivo
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Ruta")]
        public string Ruta { get; set; }
        [Display(Name = "Extención del Archivo")]
        public EnumTipoArchivo Tipo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }       
    }
}