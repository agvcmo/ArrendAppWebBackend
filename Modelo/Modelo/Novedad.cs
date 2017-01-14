using System.ComponentModel.DataAnnotations;

namespace Modelo.Modelo
{
    public class Novedad
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Tipo Daño")]
        public Enumeracion.EnumTipoDaño Tipo { get; set; }
    }
}