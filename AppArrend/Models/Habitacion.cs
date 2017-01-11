using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models
{
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Numero de Armarios")]
        public int Armario { get; set; }
        [Display(Name = "Baño")]
        public bool baño { get; set; }                
    }
}