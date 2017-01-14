using System.ComponentModel.DataAnnotations;

namespace Modelo.Modelo
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