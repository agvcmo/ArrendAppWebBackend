using AppArrend.Enumeracion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models
{
    public class Novedad
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Tipo Daño")]
        public EnumTipoDaño Tipo { get; set; }
    }
}