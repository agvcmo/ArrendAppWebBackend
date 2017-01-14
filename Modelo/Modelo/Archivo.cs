using System.ComponentModel.DataAnnotations;
using System;
using Modelo.Enumeracion;

namespace Modelo.Modelo
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